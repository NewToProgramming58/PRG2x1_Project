
namespace Project_Milestone_2
{
    partial class frmTuckShop
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
            if (disposing && (components != null))
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
            this.tcMainScreen = new System.Windows.Forms.TabControl();
            this.tpLogin = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLoginPassword = new System.Windows.Forms.TextBox();
            this.txbLoginEmail = new System.Windows.Forms.TextBox();
            this.btnNavigateToRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tpRegister = new System.Windows.Forms.TabPage();
            this.txbRegConfirm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txbRegPassword = new System.Windows.Forms.TextBox();
            this.txbRegEmail = new System.Windows.Forms.TextBox();
            this.txbRegSurname = new System.Windows.Forms.TextBox();
            this.txbRegName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.tpEdit = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcMainScreen.SuspendLayout();
            this.tpLogin.SuspendLayout();
            this.tpRegister.SuspendLayout();
            this.tpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMainScreen
            // 
            this.tcMainScreen.Controls.Add(this.tpLogin);
            this.tcMainScreen.Controls.Add(this.tpRegister);
            this.tcMainScreen.Controls.Add(this.tpMenu);
            this.tcMainScreen.Controls.Add(this.tpEdit);
            this.tcMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainScreen.Location = new System.Drawing.Point(0, 0);
            this.tcMainScreen.Name = "tcMainScreen";
            this.tcMainScreen.SelectedIndex = 0;
            this.tcMainScreen.Size = new System.Drawing.Size(800, 450);
            this.tcMainScreen.TabIndex = 0;
            // 
            // tpLogin
            // 
            this.tpLogin.Controls.Add(this.label2);
            this.tpLogin.Controls.Add(this.label1);
            this.tpLogin.Controls.Add(this.txbLoginPassword);
            this.tpLogin.Controls.Add(this.txbLoginEmail);
            this.tpLogin.Controls.Add(this.btnNavigateToRegister);
            this.tpLogin.Controls.Add(this.btnLogin);
            this.tpLogin.Location = new System.Drawing.Point(4, 22);
            this.tpLogin.Name = "tpLogin";
            this.tpLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogin.Size = new System.Drawing.Size(792, 424);
            this.tpLogin.TabIndex = 0;
            this.tpLogin.Text = "Login";
            this.tpLogin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // txbLoginPassword
            // 
            this.txbLoginPassword.Location = new System.Drawing.Point(28, 78);
            this.txbLoginPassword.Name = "txbLoginPassword";
            this.txbLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.txbLoginPassword.TabIndex = 3;
            // 
            // txbLoginEmail
            // 
            this.txbLoginEmail.Location = new System.Drawing.Point(28, 37);
            this.txbLoginEmail.Name = "txbLoginEmail";
            this.txbLoginEmail.Size = new System.Drawing.Size(100, 20);
            this.txbLoginEmail.TabIndex = 2;
            // 
            // btnNavigateToRegister
            // 
            this.btnNavigateToRegister.Location = new System.Drawing.Point(42, 148);
            this.btnNavigateToRegister.Name = "btnNavigateToRegister";
            this.btnNavigateToRegister.Size = new System.Drawing.Size(75, 23);
            this.btnNavigateToRegister.TabIndex = 1;
            this.btnNavigateToRegister.Text = "Register";
            this.btnNavigateToRegister.UseVisualStyleBackColor = true;
            this.btnNavigateToRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(42, 119);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tpRegister
            // 
            this.tpRegister.Controls.Add(this.txbRegConfirm);
            this.tpRegister.Controls.Add(this.label7);
            this.tpRegister.Controls.Add(this.btnRegister);
            this.tpRegister.Controls.Add(this.txbRegPassword);
            this.tpRegister.Controls.Add(this.txbRegEmail);
            this.tpRegister.Controls.Add(this.txbRegSurname);
            this.tpRegister.Controls.Add(this.txbRegName);
            this.tpRegister.Controls.Add(this.label6);
            this.tpRegister.Controls.Add(this.label5);
            this.tpRegister.Controls.Add(this.label4);
            this.tpRegister.Controls.Add(this.label3);
            this.tpRegister.Location = new System.Drawing.Point(4, 22);
            this.tpRegister.Name = "tpRegister";
            this.tpRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegister.Size = new System.Drawing.Size(792, 424);
            this.tpRegister.TabIndex = 1;
            this.tpRegister.Text = "Register";
            this.tpRegister.UseVisualStyleBackColor = true;
            // 
            // txbRegConfirm
            // 
            this.txbRegConfirm.Location = new System.Drawing.Point(28, 251);
            this.txbRegConfirm.Name = "txbRegConfirm";
            this.txbRegConfirm.Size = new System.Drawing.Size(100, 20);
            this.txbRegConfirm.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Confirm Password:";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(31, 286);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txbRegPassword
            // 
            this.txbRegPassword.Location = new System.Drawing.Point(28, 193);
            this.txbRegPassword.Name = "txbRegPassword";
            this.txbRegPassword.Size = new System.Drawing.Size(100, 20);
            this.txbRegPassword.TabIndex = 7;
            // 
            // txbRegEmail
            // 
            this.txbRegEmail.Location = new System.Drawing.Point(28, 137);
            this.txbRegEmail.Name = "txbRegEmail";
            this.txbRegEmail.Size = new System.Drawing.Size(100, 20);
            this.txbRegEmail.TabIndex = 6;
            // 
            // txbRegSurname
            // 
            this.txbRegSurname.Location = new System.Drawing.Point(28, 84);
            this.txbRegSurname.Name = "txbRegSurname";
            this.txbRegSurname.Size = new System.Drawing.Size(100, 20);
            this.txbRegSurname.TabIndex = 5;
            // 
            // txbRegName
            // 
            this.txbRegName.Location = new System.Drawing.Point(28, 36);
            this.txbRegName.Name = "txbRegName";
            this.txbRegName.Size = new System.Drawing.Size(100, 20);
            this.txbRegName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Surname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // tpMenu
            // 
            this.tpMenu.Location = new System.Drawing.Point(4, 22);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(792, 424);
            this.tpMenu.TabIndex = 2;
            this.tpMenu.Text = "Menu";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tpEdit
            // 
            this.tpEdit.Controls.Add(this.panel1);
            this.tpEdit.Controls.Add(this.button2);
            this.tpEdit.Controls.Add(this.button1);
            this.tpEdit.Controls.Add(this.dataGridView1);
            this.tpEdit.Location = new System.Drawing.Point(4, 22);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpEdit.Size = new System.Drawing.Size(792, 424);
            this.tpEdit.TabIndex = 3;
            this.tpEdit.Text = "Edit";
            this.tpEdit.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Edit or add item";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Remove selected item";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(65, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(792, 301);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Category";
            this.Column4.Name = "Column4";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(8, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // frmTuckShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcMainScreen);
            this.Name = "frmTuckShop";
            this.Text = "Tuck Shop";
            this.Load += new System.EventHandler(this.frmTuckShop_Load);
            this.tcMainScreen.ResumeLayout(false);
            this.tpLogin.ResumeLayout(false);
            this.tpLogin.PerformLayout();
            this.tpRegister.ResumeLayout(false);
            this.tpRegister.PerformLayout();
            this.tpEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMainScreen;
        private System.Windows.Forms.TabPage tpLogin;
        private System.Windows.Forms.TabPage tpRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLoginPassword;
        private System.Windows.Forms.TextBox txbLoginEmail;
        private System.Windows.Forms.Button btnNavigateToRegister;
        private System.Windows.Forms.TextBox txbRegConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txbRegPassword;
        private System.Windows.Forms.TextBox txbRegEmail;
        private System.Windows.Forms.TextBox txbRegSurname;
        private System.Windows.Forms.TextBox txbRegName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

