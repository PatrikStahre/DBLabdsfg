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

            DataTable studentTypeDB = new DataTable();
            DataTable phoneTypeDB = new DataTable();

            dbconn.FillDataTable("SELECT * FROM StudentTyp", studentTypeDB);
            dbconn.FillDataTable("SELECT * FROM ContactTypes", phoneTypeDB);

            StudentTypeCombobox.DataSource = studentTypeDB;
            PhoneTypeCombobox.DataSource = phoneTypeDB;
            StudentTypeCombobox.DisplayMember = "Typ";
            PhoneTypeCombobox.DisplayMember = "ContactType";
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
            if (PhoneNumberTextbox.Text.Length > 0) // validate better
            {
                AddedPhoneNumbers_Readonly.Text += $"{PhoneNumberTextbox.Text} - " + PhoneTypeCombobox.Text;
                AddedPhoneNumbers_Readonly.AppendText(Environment.NewLine);
                phoneNumbers.Add(PhoneNumberTextbox.Text);
                phoneTypes.Add(PhoneTypeCombobox.Text);
                PhoneNumberTextbox.Text = "";
            }
        }

        private void RegisterNewStudentButton_Click(object sender, EventArgs e)
        {
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
                StudentTypeCombobox.Text
                );

            int[] exitCodePhoneNumbers = new int[phoneNumbers.Count];
            exitCodePhoneNumbers = dbconn.addStudentPhoneNoToDB(
            StudentidTextbox.Text,
            phoneNumbers,
            phoneTypes
            );

            //if (exitCodeStudent == 1)
            //{
            //    RegisterStatusTextbox.Text += "1 row updated...";
            //    RegisterStatusTextbox.AppendText(Environment.NewLine);
            //    RegisterStatusTextbox.Text += $"The new student: {StudentidTextbox.Text} ({FirstnameTextbox.Text} {LastnameTextbox.Text}) was successfully added to the database!";
            //    RegisterStatusTextbox.AppendText(Environment.NewLine);
            //}

            if (exitCodeStudent == -1)
            {
                RegisterStatusTextbox.Text += "0 rows updated...";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                RegisterStatusTextbox.Text += $"An error prevented the new student: {StudentidTextbox.Text} ({FirstnameTextbox.Text} {LastnameTextbox.Text}) from being added to the database.";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
                RegisterStatusTextbox.Text += $"Because of this error no phonenumbers where added.";
                RegisterStatusTextbox.AppendText(Environment.NewLine);
            }

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

        private void ClearAddedPhoneNumbersButton_Click(object sender, EventArgs e)
        {
            AddedPhoneNumbers_Readonly.Text = "";
            phoneNumbers.Clear();
            phoneTypes.Clear();
        }
    }
}
