namespace WinFormClient
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tabAssignments = new System.Windows.Forms.TabPage();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateAss = new System.Windows.Forms.Button();
            this.tbExercise = new System.Windows.Forms.TextBox();
            this.deadlineDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tabHomeworks = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.btnRemoveTT = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.cbScTime = new System.Windows.Forms.ComboBox();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabAssignments.SuspendLayout();
            this.tabHomeworks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabAssignments);
            this.tabControl1.Controls.Add(this.tabHomeworks);
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabLogin.Controls.Add(this.label10);
            this.tabLogin.Controls.Add(this.label3);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Controls.Add(this.btnLogIn);
            this.tabLogin.Controls.Add(this.tbPass);
            this.tabLogin.Controls.Add(this.tbUsername);
            this.tabLogin.Location = new System.Drawing.Point(4, 25);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(376, 316);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "HomeOnP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username :";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(149, 261);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 31);
            this.btnLogIn.TabIndex = 2;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(138, 183);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(100, 22);
            this.tbPass.TabIndex = 1;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(138, 115);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 22);
            this.tbUsername.TabIndex = 0;
            // 
            // tabAssignments
            // 
            this.tabAssignments.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabAssignments.Controls.Add(this.cbSubject);
            this.tabAssignments.Controls.Add(this.label8);
            this.tabAssignments.Controls.Add(this.label7);
            this.tabAssignments.Controls.Add(this.label6);
            this.tabAssignments.Controls.Add(this.label5);
            this.tabAssignments.Controls.Add(this.label4);
            this.tabAssignments.Controls.Add(this.btnCreateAss);
            this.tabAssignments.Controls.Add(this.tbExercise);
            this.tabAssignments.Controls.Add(this.deadlineDate);
            this.tabAssignments.Controls.Add(this.startDate);
            this.tabAssignments.Controls.Add(this.tbTitle);
            this.tabAssignments.Location = new System.Drawing.Point(4, 25);
            this.tabAssignments.Name = "tabAssignments";
            this.tabAssignments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssignments.Size = new System.Drawing.Size(376, 316);
            this.tabAssignments.TabIndex = 1;
            this.tabAssignments.Text = "Assignments";
            // 
            // cbSubject
            // 
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(267, 47);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(98, 24);
            this.cbSubject.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Title :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Exercise : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Subject :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Deadline :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Start Date :";
            // 
            // btnCreateAss
            // 
            this.btnCreateAss.Location = new System.Drawing.Point(102, 285);
            this.btnCreateAss.Name = "btnCreateAss";
            this.btnCreateAss.Size = new System.Drawing.Size(169, 23);
            this.btnCreateAss.TabIndex = 5;
            this.btnCreateAss.Text = "Create Assignment";
            this.btnCreateAss.UseVisualStyleBackColor = true;
            this.btnCreateAss.Click += new System.EventHandler(this.btnCreateAss_Click);
            // 
            // tbExercise
            // 
            this.tbExercise.Location = new System.Drawing.Point(8, 143);
            this.tbExercise.Multiline = true;
            this.tbExercise.Name = "tbExercise";
            this.tbExercise.Size = new System.Drawing.Size(357, 136);
            this.tbExercise.TabIndex = 4;
            // 
            // deadlineDate
            // 
            this.deadlineDate.Location = new System.Drawing.Point(206, 115);
            this.deadlineDate.Name = "deadlineDate";
            this.deadlineDate.Size = new System.Drawing.Size(159, 22);
            this.deadlineDate.TabIndex = 3;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(206, 77);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(159, 22);
            this.startDate.TabIndex = 2;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(102, 17);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(159, 22);
            this.tbTitle.TabIndex = 0;
            // 
            // tabHomeworks
            // 
            this.tabHomeworks.Controls.Add(this.dataGridView1);
            this.tabHomeworks.Controls.Add(this.comboBox1);
            this.tabHomeworks.Location = new System.Drawing.Point(4, 25);
            this.tabHomeworks.Name = "tabHomeworks";
            this.tabHomeworks.Padding = new System.Windows.Forms.Padding(3);
            this.tabHomeworks.Size = new System.Drawing.Size(376, 316);
            this.tabHomeworks.TabIndex = 2;
            this.tabHomeworks.Text = "Homeworks";
            this.tabHomeworks.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(357, 242);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(357, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabSchedule
            // 
            this.tabSchedule.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabSchedule.Controls.Add(this.btnRemoveTT);
            this.tabSchedule.Controls.Add(this.label9);
            this.tabSchedule.Controls.Add(this.btnSaveSchedule);
            this.tabSchedule.Controls.Add(this.cbScTime);
            this.tabSchedule.Controls.Add(this.calendar);
            this.tabSchedule.Location = new System.Drawing.Point(4, 25);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedule.Size = new System.Drawing.Size(376, 316);
            this.tabSchedule.TabIndex = 3;
            this.tabSchedule.Text = "Schedule";
            // 
            // btnRemoveTT
            // 
            this.btnRemoveTT.Location = new System.Drawing.Point(99, 285);
            this.btnRemoveTT.Name = "btnRemoveTT";
            this.btnRemoveTT.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTT.TabIndex = 4;
            this.btnRemoveTT.Text = "Remove";
            this.btnRemoveTT.UseVisualStyleBackColor = true;
            this.btnRemoveTT.Click += new System.EventHandler(this.btnRemoveTT_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Select Time :";
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.Location = new System.Drawing.Point(213, 285);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSchedule.TabIndex = 2;
            this.btnSaveSchedule.Text = "Save";
            this.btnSaveSchedule.UseVisualStyleBackColor = true;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // cbScTime
            // 
            this.cbScTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScTime.FormattingEnabled = true;
            this.cbScTime.Location = new System.Drawing.Point(154, 238);
            this.cbScTime.Name = "cbScTime";
            this.cbScTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbScTime.Size = new System.Drawing.Size(172, 24);
            this.cbScTime.TabIndex = 1;
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(64, 12);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(76, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Default credentials: Anna:2222";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 345);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "HomeOnP";
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabAssignments.ResumeLayout(false);
            this.tabAssignments.PerformLayout();
            this.tabHomeworks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabAssignments;
        private System.Windows.Forms.TabPage tabHomeworks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateAss;
        private System.Windows.Forms.TextBox tbExercise;
        private System.Windows.Forms.DateTimePicker deadlineDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.ComboBox cbScTime;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemoveTT;
        private System.Windows.Forms.Label label10;
    }
}

