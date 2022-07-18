using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class MySQL
{
    //Credentials for the mysql connection. Change these to match your connection.
	private string server = "localhost";
    private string database = "wf";
    private string user = "root";
    private string password = "";

    MySqlConnection conn;

    //Constructor run on startup. Creates the connection string and connection using credentials above.
    public MySQL(){ 
        string connStr = "Server="+server+";Uid="+user+";Database="+database+";Pwd="+password;
        conn = new MySqlConnection(connStr);

        Init();
    }

    //Initialisation run on start up. This can be used for creating tables on startup.
    private void Init(){
        if (!Connect()) { return; }
        CreateTable("CREATE TABLE IF NOT EXISTS `tasks` (`id` INT(11) NOT NULL AUTO_INCREMENT,`task` VARCHAR(255) NULL DEFAULT NULL,PRIMARY KEY (`id`))COLLATE='latin1_swedish_ci'ENGINE=InnoDB;");
        CreateTable("CREATE TABLE IF NOT EXISTS `customers` (`id` INT(11) NOT NULL AUTO_INCREMENT,`surname` VARCHAR(50) NOT NULL,`forename` VARCHAR(50) NOT NULL,`address1` VARCHAR(50) NOT NULL,`address2` VARCHAR(50) NULL DEFAULT NULL,`town` VARCHAR(50) NOT NULL,`postcode` VARCHAR(50) NOT NULL,`tel` VARCHAR(50) NOT NULL,`email` VARCHAR(50) NOT NULL,`dob` DATE NOT NULL,PRIMARY KEY (`id`))COLLATE='latin1_swedish_ci'ENGINE=InnoDB;");
        CreateTable("CREATE TABLE IF NOT EXISTS `users` (`id` INT(11) NOT NULL AUTO_INCREMENT,`user` VARCHAR(50) NOT NULL,`pass` VARCHAR(50) NOT NULL,PRIMARY KEY (`id`))COLLATE='latin1_swedish_ci'ENGINE=InnoDB;");
        CreateTable("CREATE TABLE IF NOT EXISTS `wood` (`id` INT(11) NOT NULL AUTO_INCREMENT,`name` VARCHAR(50) NOT NULL,`cost` DOUBLE NOT NULL DEFAULT '0',PRIMARY KEY (`id`))COLLATE='latin1_swedish_ci'ENGINE=InnoDB;");
        Disconnect();
    }

    //Attempt to connect to the mysql database.
    public bool Connect(){ 
        Console.WriteLine("(MYSQL) Attempting to connect to " + server + " on database: " + database);
        try{
            conn.Open();
            Console.WriteLine("(MYSQL) Successfully connected!");
            return true;
        }catch(Exception e){ 
            Console.WriteLine("(MYSQL) ERROR: Connection failed! " + e.Message);
            return false;
        }
    }

    //Attempt to disconnect from the mysql database.
    public void Disconnect(){
        Console.WriteLine("(MYSQL) Attempting to disconnect from " + server + " on database " + database);
        try{
            conn.Close();
            Console.WriteLine("(MYSQL) Successfully disconnected!");
        } catch(Exception e){
            Console.WriteLine("(MYSQL) ERROR: Disconnection failed! " + e.Message);
        }
    }

    //Inputs:
    //Search String - Example: "SELECT * FROM table" OR "SELECT * FROM table WHERE id = @0"
    //Search Parameters - Example: userID, username, password - This input is only required if you need a prepared statement using @s
    //Outputs:
    //Dictionary<int, Dictionary<string, string>> - The integer is used to select which row to check, the second dictionary stores the field name and its value.
    public Dictionary<int, Dictionary<string, string>> Search(string searchStr, params string[] searchParams){ 
        Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
        Dictionary<string, string> readerRes;

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = searchStr;
        cmd.Prepare();
        for(int i = 0; i < searchParams.Length; i++){
            cmd.Parameters.AddWithValue("@"+i, searchParams[i]);
        }
        int curLine = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
            readerRes = new Dictionary<string, string>();
            for(int i = 0; i < reader.FieldCount; i++){
                readerRes.Add(reader.GetName(i), reader[i].ToString());
            }
            result.Add(curLine, readerRes);
            curLine++;
        }
        reader.Close();
        return result;
    }

    //Inputs:
    //Insert String - Example: "INSERT INTO table (id, username, password) VALUES (1, johndoe, john123)" OR "INSERT INTO table (id, username, password) VALUES (@0, @1, @2)"
    //Insert Parameters - Example: userID, username, password - Only required if you are using a repared statement using @s
    public void Insert(string insertStr, params string[] insertParams){ 
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = insertStr;
        cmd.Prepare();
        for(int i = 0; i<insertParams.Length; i++){
            cmd.Parameters.AddWithValue("@" + i, insertParams[i]);
        }
        cmd.ExecuteNonQuery();
    }

    //Inputs:
    //Update String - Example: "UPDATE table SET id = 1, username = johndoe, password = john123" OR "UPDATE table SET id = @0, username = @1, password = @2"
    //Update Parameters - Example: userID, username, password - Only required if you are using a repared statement using @s
    public void Update(string updateStr, params string[] updateParams){ 
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = updateStr;
        cmd.Prepare();
        for(int i = 0; i < updateParams.Length; i++){
            cmd.Parameters.AddWithValue("@" + i, updateParams[i]);
        }
        cmd.ExecuteNonQuery();
    }

    //Inputs:
    //Remove String - Example: "DELETE FROM table" OR "DELETE FROM table WHERE id = 1" OR "DELETE FROM table WHERE id = @0"
    //Remove Parameters - Example: userID - Only required if you are using a repared statement using @s
    public void Remove(string removeStr, params string[] removeParams){ 
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = removeStr;
        cmd.Prepare();
        for(int i = 0; i < removeParams.Length; i++){
            cmd.Parameters.AddWithValue("@" + i, removeParams[i]);
        }
        cmd.ExecuteNonQuery();
    }

    //Inputs:
    //Create String - Example: "CREATE TABLE `table` (`id` INT(11) NOT NULL AUTO_INCREMENT,`user` VARCHAR(50) NOT NULL,`pass` VARCHAR(50) NOT NULL,PRIMARY KEY (`id`))COLLATE='latin1_swedish_ci'ENGINE=InnoDB;"
    //Create Parameters - Not really required unless the string is a prepared statement with @s
    public void CreateTable(string createStr, params string[] createParams){ 
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = createStr;
        cmd.Prepare();
        for(int i = 0; i < createParams.Length; i++){
            cmd.Parameters.AddWithValue("@" + i, createParams[i]);
        }
        cmd.ExecuteNonQuery();
        Console.WriteLine("(MYSQL) Table created! or not, I'm not a cop.");
    }
}