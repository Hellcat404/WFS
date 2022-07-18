namespace WoodFlooringService
{
    partial class WFSTasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.ttTasks = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(12, 12);
            this.txtTask.MaxLength = 255;
            this.txtTask.Multiline = true;
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(460, 125);
            this.txtTask.TabIndex = 0;
            this.ttTasks.SetToolTip(this.txtTask, "Task to add.");
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(12, 189);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(460, 160);
            this.lstTasks.TabIndex = 1;
            this.ttTasks.SetToolTip(this.lstTasks, "Tasks in database.");
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(374, 143);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(98, 40);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Add Task";
            this.ttTasks.SetToolTip(this.btnAddTask, "Add the task to the database.");
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnDelTask
            // 
            this.btnDelTask.Location = new System.Drawing.Point(12, 143);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(98, 40);
            this.btnDelTask.TabIndex = 3;
            this.btnDelTask.Text = "Delete Task";
            this.ttTasks.SetToolTip(this.btnDelTask, "Delete a task from the database.");
            this.btnDelTask.UseVisualStyleBackColor = true;
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 355);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(460, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Tag = "Open the help form.";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // WFSTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 386);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDelTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.txtTask);
            this.Name = "WFSTasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WFS - Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFSTasks_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolTip ttTasks;
    }
}