using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBLabs
{
    public partial class AddStudentControl : UserControl
    {
        private DBConnection dbconn;
        private List<string> phoneNumbers;
        private List<string> phoneTypes;

        public AddStudentControl()
        {
            /*
             * Constructor the control
             * 
             * You DONT need to edit this constructor.
             * 
             */
            phoneNumbers = new List<string>();
            phoneTypes = new List<string>();
            InitializeComponent();
        }

        public void AddStudentControlSettings(ref DBConnection dbconn)
        {
            /*
             * Since UserControls cannot take arguments to the constructor 
             * this function is called after the constructor to perform this.
             * 
             * You DONT need to edit this function.
             * 
             */
            this.dbconn = dbconn;
        }


        private void LoadAddStudentControl(object sender, EventArgs e)
        {
            /*
             * This function contains all code that needs to be executed when the control is first loaded
             * 
             * You need to edit this code. 
             * Example: Population of Comboboxes and gridviews etc.
             * 
             */

            ResetAddStudentControl();
            // We call a method in the DBConnection.cs class so that DBConnection is responsible for all
            // contact with the database.
            DataTable studentTypeDB = dbconn.LoadTypes("StudentTyp");
            DataTable phoneTypeDB = dbconn.LoadTypes("TelefonNoTyp");
            DataTable programTypeDB = dbconn.LoadTypes("Program");
           

            StudentTypeCombobox.DataSource = studentTypeDB;
            PhoneTypeCombobox.DataSource = phoneTypeDB;
            ProgramCombobox.DataSource = programTypeDB;
            StudentTypeCombobox.DisplayMember = "Typ";
            PhoneTypeCombobox.DisplayMember = "Types";
            ProgramCombobox.DisplayMember = "ProgramName";
        }
        public void ResetAddStudentControl(bool clearLog = true)
        {
            /*
             * This function contains all code that needs to be executed when the control is reloaded
             * 
             * You need to edit this code. 
             * Example: Emptying textboxes and gridviews
             * 
             */
            phoneNumbers.Clear();
            phoneTypes.Clear();
            StudentidTextbox.ResetText();
            FirstnameTextbox.ResetText();
            LastnameTextbox.ResetText();
            GenderTextbox.ResetText();
            StreetadressTextbox.ResetText();
            ZipcodeTextbox.ResetText();
            CityTextbox.ResetText();
            CountryTextbox.ResetText();
            BirthdateDatepicker.Value = BirthdateDatepicker.MaxDate;
            PhoneNumberTextbox.ResetText();
            AddedPhoneNumbers_Readonly.ResetText();

            if (clearLog)
                RegisterStatusTextbox.ResetText();
        }

        private void AddNumberButton_Click(object sender, EventArgs e)
        {
            if (PhoneNumberTextbox.Text.Length > 0)
            {
                AddedPhoneNumbers_Readonly.Text += $"{PhoneNumberTextbox.Text} - " + PhoneTypeCombobox.Text;
                AddedPhoneNumbers_Readonly.AppendText(Environment.NewLine);
                phoneNumbers.Add(PhoneNumberTextbox.Text);
                phoneTypes.Add(PhoneTypeCombobox.Text);
                PhoneNumberTextbox.ResetText();
            }
        }

        // When the user presses the Register-button we first call the addStudentToDB function in DBConnection to insert the student into the database,
        // then, once the student exists in the database, we insert the phonenumbers that references that students studentid.
        private void RegisterNewStudentButton_Click(object sender, EventArgs e)
        {
            string program = "";
            string admissionYear = "";
            if (ProgramLabel.Visible == true)
            {
                program = ProgramCombobox.Text;
                admissionYear = YearOfAdmissionTextbox.Text;
            }

            int exitCodeStudent = dbconn.addStudentToDB(
                StudentidTextbox.Text,
                FirstnameTextbox.Text,
                LastnameTextbox.Text,
                GenderTextbox.Text,
                StreetadressTextbox.Text,
                ZipcodeTextbox.Text,
                CityTextbox.Text,
                CountryTextbox.Text,
                string.Format($"{BirthdateDatepicker.Value.Year + "-" + BirthdateDatepicker.Value.Month + "-" + BirthdateDatepicker.Value.Day}"),
                StudentTypeCombobox.Text,
                program,
                admissionYear
                );

            int[] exitCodePhoneNumbers = new int[phoneNumbers.Count];
            exitCodePhoneNumbers = dbconn.addStudentPhoneNoToDB(
            StudentidTextbox.Text,
            phoneNumbers,
            phoneTypes
            );

            // If the insertion into the database failed we update the log textbox.
            if (exitCodeStudent == -1)
            {
                RegisterStatusTextbox.Text += "0 rows updated...";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                RegisterStatusTextbox.Text += $"An error prevented the new student: {StudentidTextbox.Text} ({FirstnameTextbox.Text} {LastnameTextbox.Text}) from being added to the database.";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                RegisterStatusTextbox.Text += $"Because of this error no phonenumbers where added.";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
            }

            // If the insertion succeeded we also update the log textbox, one time for the student insertion and one time for each of the
            // added phonenumbers, since the success of the phonenumber insertions are somewhat independent from the student insertion.
            // (It only requires that the newly added student exists so that it can reference the student ID).
            else if (exitCodeStudent == 1)
            {
                RegisterStatusTextbox.Text += "1 row updated...";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                RegisterStatusTextbox.Text += $"The new student: {StudentidTextbox.Text} ({FirstnameTextbox.Text} {LastnameTextbox.Text}) was successfully added to the database!";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                for (int i = 0; i < exitCodePhoneNumbers.Length; i++)
                {
                    if (exitCodePhoneNumbers[i] == 1)
                    {
                        RegisterStatusTextbox.Text += $"Phone number {phoneNumbers[i]} - {phoneTypes[i]} added to the database.";
                        RegisterStatusTextbox.AppendText(Environment.NewLine);
                    }
                    else if (exitCodePhoneNumbers[i] == -1)
                    {
                        RegisterStatusTextbox.Text += $"Error. Phone number {phoneNumbers[i]} not added to database.";
                        RegisterStatusTextbox.AppendText(Environment.NewLine);
                    }
                }
                ResetAddStudentControl(false);
            }
        }

        // Clears the lists that store the phonenumbers and phonetypes, and resets the textbox.
        private void ClearAddedPhoneNumbersButton_Click(object sender, EventArgs e)
        {
            AddedPhoneNumbers_Readonly.ResetText();
            phoneNumbers.Clear();
            phoneTypes.Clear();
        }

        // If the selected student type is "Programstudent", show the type of programs. Otherwise hide the label and combobox.
        private void StudentTypeCombobox_TextChanged(object sender, EventArgs e)
        {
            YearOfAdmissionTextbox.ResetText();
            if (StudentTypeCombobox.Text == "Programstudent")
            {
                ProgramLabel.Visible = true;
                ProgramCombobox.Visible = true;
                YearOfAdmissionLabel.Visible = true;
                YearOfAdmissionTextbox.Visible = true;
            }
            else
            {
                ProgramLabel.Visible = false;
                ProgramCombobox.Visible = false;
                YearOfAdmissionLabel.Visible = false;
                YearOfAdmissionTextbox.Visible = false;
            }
        }
    }
}
