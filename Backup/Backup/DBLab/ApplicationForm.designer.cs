namespace DBLabs
{
    partial class ApplicationForm
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
            this.MenuLBL = new System.Windows.Forms.Label();
            this.ShowStaffingButton = new System.Windows.Forms.Button();
            this.AddCourseButton = new System.Windows.Forms.Button();
            this.ShowStudentButton = new System.Windows.Forms.Button();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.ShowCourseButton = new System.Windows.Forms.Button();
            this.addStudentControl1 = new DBLabs.AddStudentControl();
            this.viewStudentControl1 = new DBLabsDLL.ViewStudentControl();
            this.staffGridControl1 = new DBLabsDLL.StaffGridControl();
            this.viewCourseControl1 = new DBLabsDLL.ViewCourseControl();
            this.addCourseControl1 = new DBLabsDLL.AddCourseControl();
            this.SuspendLayout();
            // 
            // MenuLBL
            // 
            this.MenuLBL.AutoSize = true;
            this.MenuLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLBL.Location = new System.Drawing.Point(13, 26);
            this.MenuLBL.Name = "MenuLBL";
            this.MenuLBL.Size = new System.Drawing.Size(38, 13);
            this.MenuLBL.TabIndex = 1;
            this.MenuLBL.Text = "Menu";
            // 
            // ShowStaffingButton
            // 
            this.ShowStaffingButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ShowStaffingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ShowStaffingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowStaffingButton.Location = new System.Drawing.Point(13, 169);
            this.ShowStaffingButton.Name = "ShowStaffingButton";
            this.ShowStaffingButton.Size = new System.Drawing.Size(177, 23);
            this.ShowStaffingButton.TabIndex = 10;
            this.ShowStaffingButton.TabStop = false;
            this.ShowStaffingButton.Text = "View Staffing";
            this.ShowStaffingButton.UseVisualStyleBackColor = false;
            this.ShowStaffingButton.Click += new System.EventHandler(this.ShowStaffingButton_Click);
            // 
            // AddCourseButton
            // 
            this.AddCourseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddCourseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddCourseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCourseButton.Location = new System.Drawing.Point(13, 111);
            this.AddCourseButton.Name = "AddCourseButton";
            this.AddCourseButton.Size = new System.Drawing.Size(177, 23);
            this.AddCourseButton.TabIndex = 6;
            this.AddCourseButton.TabStop = false;
            this.AddCourseButton.Text = "Add Course";
            this.AddCourseButton.UseVisualStyleBackColor = false;
            this.AddCourseButton.Click += new System.EventHandler(this.AddCourseButton_Click);
            // 
            // ShowStudentButton
            // 
            this.ShowStudentButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ShowStudentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ShowStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowStudentButton.Location = new System.Drawing.Point(13, 82);
            this.ShowStudentButton.Name = "ShowStudentButton";
            this.ShowStudentButton.Size = new System.Drawing.Size(177, 23);
            this.ShowStudentButton.TabIndex = 4;
            this.ShowStudentButton.TabStop = false;
            this.ShowStudentButton.Text = "View Student";
            this.ShowStudentButton.UseVisualStyleBackColor = false;
            this.ShowStudentButton.Click += new System.EventHandler(this.ShowstudentButton_Click);
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddStudentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStudentButton.Location = new System.Drawing.Point(13, 53);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(177, 23);
            this.AddStudentButton.TabIndex = 2;
            this.AddStudentButton.TabStop = false;
            this.AddStudentButton.Text = "Add Student";
            this.AddStudentButton.UseVisualStyleBackColor = false;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // ShowCourseButton
            // 
            this.ShowCourseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ShowCourseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ShowCourseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowCourseButton.Location = new System.Drawing.Point(13, 140);
            this.ShowCourseButton.Name = "ShowCourseButton";
            this.ShowCourseButton.Size = new System.Drawing.Size(177, 23);
            this.ShowCourseButton.TabIndex = 8;
            this.ShowCourseButton.TabStop = false;
            this.ShowCourseButton.Text = "View Course";
            this.ShowCourseButton.UseVisualStyleBackColor = false;
            this.ShowCourseButton.Click += new System.EventHandler(this.ShowCourseButton_Click);
            // 
            // addStudentControl1
            // 
            this.addStudentControl1.Location = new System.Drawing.Point(196, 26);
            this.addStudentControl1.Name = "addStudentControl1";
            this.addStudentControl1.Size = new System.Drawing.Size(1087, 533);
            this.addStudentControl1.TabIndex = 11;
            // 
            // viewStudentControl1
            // 
            this.viewStudentControl1.Location = new System.Drawing.Point(196, 26);
            this.viewStudentControl1.Name = "viewStudentControl1";
            this.viewStudentControl1.Size = new System.Drawing.Size(1087, 533);
            this.viewStudentControl1.TabIndex = 12;
            // 
            // staffGridControl1
            // 
            this.staffGridControl1.Location = new System.Drawing.Point(196, 26);
            this.staffGridControl1.Name = "staffGridControl1";
            this.staffGridControl1.Size = new System.Drawing.Size(1087, 533);
            this.staffGridControl1.TabIndex = 13;
            // 
            // viewCourseControl1
            // 
            this.viewCourseControl1.Location = new System.Drawing.Point(196, 26);
            this.viewCourseControl1.Name = "viewCourseControl1";
            this.viewCourseControl1.Size = new System.Drawing.Size(1087, 533);
            this.viewCourseControl1.TabIndex = 14;
            // 
            // addCourseControl1
            // 
            this.addCourseControl1.Location = new System.Drawing.Point(196, 26);
            this.addCourseControl1.Name = "addCourseControl1";
            this.addCourseControl1.Size = new System.Drawing.Size(1087, 533);
            this.addCourseControl1.TabIndex = 15;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 567);
            this.Controls.Add(this.addCourseControl1);
            this.Controls.Add(this.viewCourseControl1);
            this.Controls.Add(this.staffGridControl1);
            this.Controls.Add(this.viewStudentControl1);
            this.Controls.Add(this.addStudentControl1);
            this.Controls.Add(this.ShowStaffingButton);
            this.Controls.Add(this.ShowCourseButton);
            this.Controls.Add(this.AddCourseButton);
            this.Controls.Add(this.ShowStudentButton);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.MenuLBL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ApplicationForm";
            this.Text = "IDT Management System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label MenuLBL;
        private System.Windows.Forms.Button ShowStaffingButton;
        private System.Windows.Forms.Button AddCourseButton;
        private System.Windows.Forms.Button ShowStudentButton;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Button ShowCourseButton;
        private AddStudentControl addStudentControl1;
        private DBLabsDLL.ViewStudentControl viewStudentControl1;
        private DBLabsDLL.StaffGridControl staffGridControl1;
        private DBLabsDLL.ViewCourseControl viewCourseControl1;
        private DBLabsDLL.AddCourseControl addCourseControl1;




    }
}