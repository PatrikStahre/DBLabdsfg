namespace DBLabs
{
    partial class AddStudentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddStudentGB = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // AddStudentGB
            // 
            this.AddStudentGB.Location = new System.Drawing.Point(14, 12);
            this.AddStudentGB.Name = "AddStudentGB";
            this.AddStudentGB.Size = new System.Drawing.Size(1051, 507);
            this.AddStudentGB.TabIndex = 54;
            this.AddStudentGB.TabStop = false;
            this.AddStudentGB.Text = "Add Student";
            // 
            // AddStudentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddStudentGB);
            this.Name = "AddStudentControl";
            this.Size = new System.Drawing.Size(1087, 533);
            this.Load += new System.EventHandler(this.LoadAddStudentControl);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddStudentGB;
    }
}
