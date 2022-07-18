namespace WoodFlooringService
{
    partial class WFSCost
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
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWood = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutVAT = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.ttCost = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(113, 12);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(121, 20);
            this.txtArea.TabIndex = 0;
            this.ttCost.SetToolTip(this.txtArea, "Area of flooring to be bought. (Whole numbers only.)");
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Area of Flooring m²";
            // 
            // cmbWood
            // 
            this.cmbWood.FormattingEnabled = true;
            this.cmbWood.Location = new System.Drawing.Point(113, 38);
            this.cmbWood.Name = "cmbWood";
            this.cmbWood.Size = new System.Drawing.Size(121, 21);
            this.cmbWood.TabIndex = 2;
            this.ttCost.SetToolTip(this.cmbWood, "Select the type of wood.");
            this.cmbWood.SelectedIndexChanged += new System.EventHandler(this.cmbWood_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type of Wood";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cost without VAT";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(113, 65);
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.Size = new System.Drawing.Size(121, 20);
            this.txtOut.TabIndex = 4;
            this.ttCost.SetToolTip(this.txtOut, "Displays the cost without VAT");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cost with VAT";
            // 
            // txtOutVAT
            // 
            this.txtOutVAT.Location = new System.Drawing.Point(113, 91);
            this.txtOutVAT.Name = "txtOutVAT";
            this.txtOutVAT.ReadOnly = true;
            this.txtOutVAT.Size = new System.Drawing.Size(121, 20);
            this.txtOutVAT.TabIndex = 6;
            this.ttCost.SetToolTip(this.txtOutVAT, "Displays the cost after VAT.");
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 118);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(222, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.ttCost.SetToolTip(this.btnHelp, "Open the help form.");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // WFSCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 148);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutVAT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWood);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WFSCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WFS - Cost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWood;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutVAT;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolTip ttCost;
    }
}