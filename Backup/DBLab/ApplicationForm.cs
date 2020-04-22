using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBLabs
{
    public partial class ApplicationForm : Form
    {

        private DBConnection dbconn;

        public ApplicationForm(ref DBConnection dbconn)
        {
            InitializeComponent();
            this.dbconn = dbconn;
            DBLabsDLL.DBConnectionBase dbconn2 = this.dbconn;
            DBLabsDLL.LoginForm login =new DBLabsDLL.LoginForm(ref dbconn2);
            login.ShowDialog();
            addStudentControl1.AddStudentControlSettings(ref dbconn);
            addStudentControl1.Visible = false;
            viewStudentControl1.ViewStudentControlSettings(ref dbconn2);
            viewStudentControl1.Visible = false;
            addCourseControl1.AddCourseControlSettings(ref dbconn2);
            addCourseControl1.Visible = false;
            viewCourseControl1.ViewCourseControlSettings(ref dbconn2);
            viewCourseControl1.Visible = false;
            staffGridControl1.StaffGridControlSettings(ref dbconn2);
            staffGridControl1.Visible = false;
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            viewStudentControl1.Visible = false;
            addStudentControl1.Visible = true;
            addCourseControl1.Visible = false;
            viewCourseControl1.Visible = false;
            staffGridControl1.Visible = false;
            AddStudentButton.Font = new Font(AddStudentButton.Font.Name, AddStudentButton.Font.Size, FontStyle.Bold);
            ShowStudentButton.Font = new Font(ShowStudentButton.Font.Name, ShowStudentButton.Font.Size, FontStyle.Regular);
            AddCourseButton.Font = new Font(AddCourseButton.Font.Name, AddCourseButton.Font.Size, FontStyle.Regular);
            ShowCourseButton.Font = new Font(ShowCourseButton.Font.Name, ShowCourseButton.Font.Size, FontStyle.Regular);
            ShowStaffingButton.Font = new Font(ShowStaffingButton.Font.Name, ShowStaffingButton.Font.Size, FontStyle.Regular);
            addStudentControl1.ResetAddStudentControl();
        }

        private void ShowstudentButton_Click(object sender, EventArgs e)
        {
            viewStudentControl1.Visible = true;
            addStudentControl1.Visible = false;
            addCourseControl1.Visible = false;
            viewCourseControl1.Visible = false;
            staffGridControl1.Visible = false;
            AddStudentButton.Font = new Font(AddStudentButton.Font.Name, AddStudentButton.Font.Size, FontStyle.Regular);
            ShowStudentButton.Font = new Font(ShowStudentButton.Font.Name, ShowStudentButton.Font.Size, FontStyle.Bold);
            AddCourseButton.Font = new Font(AddCourseButton.Font.Name, AddCourseButton.Font.Size, FontStyle.Regular);
            ShowCourseButton.Font = new Font(ShowCourseButton.Font.Name, ShowCourseButton.Font.Size, FontStyle.Regular);
            ShowStaffingButton.Font = new Font(ShowStaffingButton.Font.Name, ShowStaffingButton.Font.Size, FontStyle.Regular);
            viewStudentControl1.ResetViewStudentControl();
        }

        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            viewStudentControl1.Visible = false;
            addStudentControl1.Visible = false;
            addCourseControl1.Visible = true;
            viewCourseControl1.Visible = false;
            staffGridControl1.Visible = false;
            AddStudentButton.Font = new Font(AddStudentButton.Font.Name, AddStudentButton.Font.Size, FontStyle.Regular);
            ShowStudentButton.Font = new Font(ShowStudentButton.Font.Name, ShowStudentButton.Font.Size, FontStyle.Regular);
            AddCourseButton.Font = new Font(AddCourseButton.Font.Name, AddCourseButton.Font.Size, FontStyle.Bold);
            ShowCourseButton.Font = new Font(ShowCourseButton.Font.Name, ShowCourseButton.Font.Size, FontStyle.Regular);
            ShowStaffingButton.Font = new Font(ShowStaffingButton.Font.Name, ShowStaffingButton.Font.Size, FontStyle.Regular);
            addCourseControl1.ResetAddCourseControl();
        }

        private void ShowCourseButton_Click(object sender, EventArgs e)
        {
            viewStudentControl1.Visible = false;
            addStudentControl1.Visible = false;
            addCourseControl1.Visible = false;
            viewCourseControl1.Visible = true;
            staffGridControl1.Visible = false;
            AddStudentButton.Font = new Font(AddStudentButton.Font.Name, AddStudentButton.Font.Size, FontStyle.Regular);
            ShowStudentButton.Font = new Font(ShowStudentButton.Font.Name, ShowStudentButton.Font.Size, FontStyle.Regular);
            AddCourseButton.Font = new Font(AddCourseButton.Font.Name, AddCourseButton.Font.Size, FontStyle.Regular);
            ShowCourseButton.Font = new Font(ShowCourseButton.Font.Name, ShowCourseButton.Font.Size, FontStyle.Bold);
            ShowStaffingButton.Font = new Font(ShowStaffingButton.Font.Name, ShowStaffingButton.Font.Size, FontStyle.Regular);
            viewCourseControl1.ResetViewCourseControl();
        }

        private void ShowStaffingButton_Click(object sender, EventArgs e)
        {
            viewStudentControl1.Visible = false;
            addStudentControl1.Visible = false;
            addCourseControl1.Visible = false;
            viewCourseControl1.Visible = false;
            staffGridControl1.Visible = true;
            AddStudentButton.Font = new Font(AddStudentButton.Font.Name, AddStudentButton.Font.Size, FontStyle.Regular);
            ShowStudentButton.Font = new Font(ShowStudentButton.Font.Name, ShowStudentButton.Font.Size, FontStyle.Regular);
            AddCourseButton.Font = new Font(AddCourseButton.Font.Name, AddCourseButton.Font.Size, FontStyle.Regular);
            ShowCourseButton.Font = new Font(ShowCourseButton.Font.Name, ShowCourseButton.Font.Size, FontStyle.Regular);
            ShowStaffingButton.Font = new Font(ShowStaffingButton.Font.Name, ShowStaffingButton.Font.Size, FontStyle.Bold);
            staffGridControl1.ResetStaffGridControl();
        }
    }
}
