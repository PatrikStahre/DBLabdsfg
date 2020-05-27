using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBLabs
{
    public class DBConnection : DBLabsDLL.DBConnectionBase
    {
        public SqlConnection myConnection;

        ///*
        // * The constructor
        // */
        public DBConnection()
        {

        }

        /*
         * The function to logon to the database
         * 
         * Parameters:
         *              username    The userid used to login to SQL Server
         *              password    The password for the userid
         *              
         * Return value:
         *              true    successful login
         *              false   Error
         */

        public override bool login(string username, string password)
        {
            //We hardcode the login info so we dont have to enter this info everytime we run the program.
            username = "DVA234_2020_G7";
            password = "DVA234_7";

            string connectionstring = "Data Source=www4.idt.mdh.se;" + "Initial Catalog=DVA234_2020_G7_db;" + $"User Id={username};" + $"Password={password};";
            myConnection = new SqlConnection(connectionstring);

            // We try to open the connection. If the state of the connection is "open" we close it and return true. Otherwise we return false.
            myConnection.Open();

            if (myConnection.State == ConnectionState.Closed)
                return false;

            else if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
                return true;
            }

            else // something has gone wrong that we didnt check for...
                return false;
        }
        /*
         --------------------------------------------------------------------------------------------
         IMPLEMENTATION TO BE USED IN LAB 2. 
         --------------------------------------------------------------------------------------------
        */

        // Here you need to implement your own methods that call the stored procedures 
        // addStudent and addStudentPhoneNo

        // We declare and return the datatable to the method LoadAddStudentControl in AddStudentControl.cs that use the datatables to
        // populate the comboboxes. 
        public DataTable LoadDataTable(string quary)
        {
            DataTable dt = new DataTable();
            string q = quary;
            FillDataTable(q, dt);
            return dt;
        }

        // Helper method that simply fills the datatables with data it recieves after a query to the database. 
        private void FillDataTable(string myQuery, DataTable dt)
        {
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(myQuery, myConnection);
            da.Fill(dt);
            myConnection.Close();
        }

        // The exitcode from the ExecuteNonQuery method is returned to the calling method in AddStudentControl.
        public int addStudentToDB(string studentID, string firstname, string lastname, string gender,
            string streetadress, string zidcode, string city, string country, string birthdate, string Studenttype, string program, string admissionYear)
        {
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("addStudent_p", myConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("StudentID", SqlDbType.NChar, (10)).Value = studentID;
            da.SelectCommand.Parameters.Add("FirstName", SqlDbType.NVarChar, (50)).Value = firstname;
            da.SelectCommand.Parameters.Add("LastName", SqlDbType.NVarChar, (50)).Value = lastname;
            da.SelectCommand.Parameters.Add("Gender", SqlDbType.NVarChar, (6)).Value = gender;
            da.SelectCommand.Parameters.Add("StreetAdress", SqlDbType.NVarChar, (50)).Value = streetadress;
            da.SelectCommand.Parameters.Add("ZipCode", SqlDbType.NChar, (10)).Value = zidcode;
            da.SelectCommand.Parameters.Add("City", SqlDbType.NVarChar, (50)).Value = city;
            da.SelectCommand.Parameters.Add("Country", SqlDbType.NVarChar, (50)).Value = country;
            da.SelectCommand.Parameters.Add("Birthdate", SqlDbType.Date).Value = birthdate;
            da.SelectCommand.Parameters.Add("StudentType", SqlDbType.NVarChar, (20)).Value = Studenttype;
            da.SelectCommand.Parameters.Add("Program", SqlDbType.NVarChar, (30)).Value = program;
            da.SelectCommand.Parameters.Add("ProgramYear", SqlDbType.NVarChar, (30)).Value = admissionYear;

            int exitCode = da.SelectCommand.ExecuteNonQuery();
            myConnection.Close();

            return exitCode;
        }

        // We itterate through each of the phonenumbers and make a call to the stored procedure at each itteration
        // to insert the phonenumbers (along with their types and corresponding studentID). We return the exitcodes so we can show the user the numbers that was
        // successfully added, and the numbers that failed to be added.
        public int[] addStudentPhoneNoToDB(string StudentID, List<string> phoneNumbers, List<string> PhoneTypes)
        {
            int[] exitCodes = new int[phoneNumbers.Count];

            myConnection.Open();
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                SqlDataAdapter da = new SqlDataAdapter("addStudentPhoneNo_p", myConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("StudentID", SqlDbType.NVarChar, (10)).Value = StudentID;
                da.SelectCommand.Parameters.Add("Type", SqlDbType.NVarChar, (30)).Value = PhoneTypes[i];
                da.SelectCommand.Parameters.Add("Number", SqlDbType.NVarChar, (30)).Value = phoneNumbers[i];
                exitCodes[i] = da.SelectCommand.ExecuteNonQuery();
            }
            myConnection.Close();
            return exitCodes;
        }

        /*
         --------------------------------------------------------------------------------------------
         STUB IMPLEMENTATIONS TO BE USED IN LAB 3. 
         --------------------------------------------------------------------------------------------
        */


        /********************************************************************************************
         * DATABASE UPDATING METHODS
         *******************************************************************************************/

        /*
         * Add a prerequisite for a course
         * 
         * Parameters:
         *              cc          CourseCode of the course on which to add a prerequisite
         *              preReqcc    CourseCode of the course that is the prerequisite
         *              
         * Return value:
         *              1           Prerequisite added
         *              Any other   Error
         */
        public override int addPreReq(string cc, string preReqcc)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("spAddPreReq", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HasRequirement", cc);
            cmd.Parameters.AddWithValue("@IsRequirement", preReqcc);
            int exitCode = cmd.ExecuteNonQuery();
            myConnection.Close();

            return exitCode;
        }

        /*
         * Add a course instance for a course
         * 
         * Parameters:
         *              cc          CourseCode of the course on which to add a course instance
         *              year        The year for the course instance
         *              period      The period for the course instance
         *              
         * Return value:
         *              1           Course instance added
         *              Any other   Error
         */
        public override int addInstance(string cc, int year, int period)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("addInstance", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseCode", cc);
            cmd.Parameters.AddWithValue("@YearOfStudy", year);
            cmd.Parameters.AddWithValue("@Period", period);
            int exitCode = cmd.ExecuteNonQuery();
            myConnection.Close();

            if (exitCode != 1)
                MessageBox.Show("Invalid year or period");

            return exitCode;
        }

        /*
         * Add a teacher staffing for a course
         * 
         * Parameters:
         *              pnr         "Personnummer" for the teacher to staff
         *              cc          CourseCode of the course on which to add a teacher
         *              year        The year for the course instance
         *              period      The period for the course instance
         *              hours       The number of hours to staff the teacher
         *              
         * Return value:
         *              1           Teacher staffing added
         *              Any other   Error
         */
        public override int addStaff(string pnr, string cc, int year, int period, int hours) 
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("spAddStaff", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SSN", pnr);
            cmd.Parameters.AddWithValue("@CourseCode", cc);
            cmd.Parameters.AddWithValue("@YearOfStudy", year);
            cmd.Parameters.AddWithValue("@Period", period);
            cmd.Parameters.AddWithValue("@Hours", hours);
            int exitCode = cmd.ExecuteNonQuery();
            myConnection.Close();

            return exitCode;
        }

        /*
         * Add a labassistant staffing for a course
         * 
         * Parameters:
         *              studid      StudentID for the student to staff
         *              cc          CourseCode of the course on which to add a labassistant
         *              year        The year for the course instance
         *              period      The period for the course instance
         *              hours       The number of hours to staff the student
         *              
         * Return value:
         *              1           Labassistant staffing added
         *              Any other   Error
         */
        public override int addLabass(string studid, string cc, int year, int period, int hours, int salary) 
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("spAddLabass", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentID", studid);
            cmd.Parameters.AddWithValue("@CourseCode", cc);
            cmd.Parameters.AddWithValue("@YearOfStudy", year);
            cmd.Parameters.AddWithValue("@Period", period);
            cmd.Parameters.AddWithValue("@Hours", hours);
            cmd.Parameters.AddWithValue("@Salary", salary);
            int exitCode = cmd.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show(exitCode.ToString());

            return exitCode;
        }


        /*
         * Add a new course
         * 
         * Parameters:
         *              cc          CourseCode of the course on which to add a labassistant
         *              name        The name of the course
         *              credits     The number of credits for the course
         *              responsible The "personnummer" of the course responsible staff
         *              
         * Return value:
         *              1           Course added
         *              Any other   Error
         */
        public override int addCourse(string cc, string name, double credits, string responsible) 
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("addCourse", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseCode", cc);
            cmd.Parameters.AddWithValue("@CourseName", name);
            cmd.Parameters.AddWithValue("@Credits", credits);
            cmd.Parameters.AddWithValue("@ResponsibleStaffPnr", responsible);
            int exitCode = cmd.ExecuteNonQuery();
            myConnection.Close();

            return exitCode;
        }


        /********************************************************************************************
         * DATABASE QUERYING METHODS
         *******************************************************************************************/

        /*
         * Get student data for all students
         * 
         * Parameters
         *              None
         * 
         * Return value:
         *              DataTable with the following columns:
         *                  StudentID       VARCHAR     StudentID for Students
         *                  FirstName       VARCHAR     Students First Name
         *                  LastName        VARCHAR     Students Last Name
         *                  Gender          VARCHAR     Students Gender
         *                  StreetAdress    VARCHAR     Students StreetAdress
         *                  ZipCode         VARCHAR     Students "PostNummer"
         *                  BirthDate       DATETIME    Students BirthDate
         *                  StudentType     VARCHAR     Student type (Program Student, Exchange Student etc)
         *                  City            VARCHAR     Students City
         *                  Country         VARCHAR     Students Country
         *                  program         VARCHAR     Name of the program the student is enrolled to
         *                  PgmStartYear    INTEGER     Year the student enrolled to the program
         *                  credits         FLOAT       The number of credits that the student has completed
         */
        public override DataTable getStudentData() 
        {
            return LoadDataTable("SELECT * FROM STUDENTLIST");
        }

        /*
         * Get list of staff
         * 
         * Parameters
         *              None
         *
         * Return value
         *              DataTable with the following columns:
         *                  pnr             VARCHAR     "Personnummer" for the staff
         *                  fullname        VARCHAR     Full name (First name and Last Name) of the staff.
         */
        public override DataTable getStaff() 
        {
            return LoadDataTable("SELECT * FROM STAFFLIST");
        }

        /*
         * Get list of Potential Labasses (i.e. students)
         * 
         * Parameters
         *              None
         *
         * Return value
         *              DataTable with the following columns:
         *                  StudentID       VARCHAR     StudentID for all students
         *                  fullname        VARCHAR     Full name (First name and Last Name) of the students.
         */
        public override DataTable getLabasses()
        {
            return LoadDataTable("SELECT * FROM LABASSISTANTSLIST");
        }

        /*
         * Get course data
         * 
         * Parameters
         *              None
         * 
         * Return value
         *              DataTable with the following columns:
         *                  coursecode      VARCHAR     Course Code
         *                  name            VARCHAR     Name of the Course
         *                  credits         FLOAT       Credits of the course
         *                  courseresponsible VARCHAR   "Personnummer" for the course responsible teacher
         */
        public override DataTable getCourses()
        {
            return LoadDataTable("SELECT * FROM COURSELIST");
        }
        /*
         * Returns the salary costs for a course instance based on the teacher and lab assistent staffing.
         * 
         * Parameters:
         *              cc          CourseCode to the course to calculate the cost
         *              year        The year for the course instance
         *              period      The period for the course instance
         *              
         * Return value:
         *              integer     The cost in currency (SEK)
         */
        public override int getCourseCost(string cc, int year, int period)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("getCourseCost", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseCode", cc);
            cmd.Parameters.AddWithValue("@YearOfStudy", year);
            cmd.Parameters.AddWithValue("@Period", period);
            cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            myConnection.Close();

            int returnValue = (int)cmd.Parameters["@ReturnValue"].Value;

            return returnValue;

        }

        /*
         * Returns the staffed persons (both teachers and lab assistants) for a course instance
         * 
         * Parameters:
         *              cc          CourseCode to the course to show staffing for
         *              year        The year for the course instance
         *              period      The period for the course instance
         *              
         * Return value:
         *              DataTable with the relevant information
         *                  The table should show name, number of hours, the Task in the course and the hourly salary
         */
        public override DataTable getCourseStaffing(string cc, string year, string period) 
        {
            return LoadDataTable($"exec getCourseStaffing '{cc}','{year}','{period}'");
        }

        /*
         * Returns the student course transcript ("Ladokudrag")
         * 
         * Parameters:
         *              studId      StudentID for student to show transcript for
         *              
         * Return value:
         *              DataTable with the relevant information
         *                  See lab-instructions for more information about this DataTable
         */
        public override DataTable getStudentRecord(string studId)
        {
            return LoadDataTable($"exec getStudentRecord '{studId}'");
        }

        /*
         * Returns the a list of all courses that are prerequisites to a course.
         * 
         * Parameters:
         *              cc      Course Code for the course to list prerequisites
         *              
         * Return value:
         *              DataTable with the relevant information
         *                  The Table should show at least coursecode and course name for all prerequisite courses
         */
        public override DataTable getPreReqs(string cc) 
        {
            return LoadDataTable($"exec getPreReqs '{cc}'");
        }


        /*
         * Get course instances for a course
         * 
         * Parameters
         *              cc      Course Code for the course to list course instances
         * 
         * Return value
         *              DataTable with the following columns:
         *                  year            INTEGER     The year of the course instance
         *                  period          INTEGER     The period of the course instance
         *                  instance        VARCHAR     The "Display text" for the instance, e.g. year(period) or similar
         */
        public override DataTable getInstances(string cc) 
        {
            return LoadDataTable($"exec getInstances '{cc}'");
        }

        /*
        * Get list of telephone numbers for a student
        * 
        * Parameters
        *              studId      StudentID for the student
        * 
        * Return value
        *              DataTable with the following columns:
        *                  Type            VARCHAR     The type of telephone number (e.g., Home, Work, Cell etc.)
        *                  Number          VARCHAR     The telephone number
        */
        public override DataTable getStudentPhoneNumbers(string studId)
        {
            return LoadDataTable($"exec getStudentPhoneNumbers '{studId}'");
        }

        /*
        --------------------------------------------------------------------------------------------
         STUB IMPLEMENTATIONS TO BE USED IN LAB 4. 
        --------------------------------------------------------------------------------------------
        */


        /*
        * Get list years which have course instances
        * 
        * Parameters
        *              None      
        * 
        * Return value
        *              DataTable with the following column:
        *                  Year            INTEGER     A unique (no duplicates) list of all years which has course instances
        */
        public override DataTable getStaffingYears()
        {
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Year");
            //dt.Rows.Add(2000);
            //return dt;

            myConnection.Open();

            string myQuery = "SELECT * FROM YEARS_WITH_COURSEINSTANCES";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            myConnection.Close();

            return dt;
        }

        /*
        * Get a matrix of all staffing for a year
        * 
        * Parameters
        *              year     The year to show staffings for      
        * 
        * Return value
        *              DataTable with suitable format
        *                  For more information about the format, see Lab instructions for lab 4
        */
        public override DataTable getStaffingGrid(string year)
        {
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            //DataTable dt = new DataTable();
            //dt.Columns.Add("StaffingGrid");
            //dt.Rows.Add("All will be revealed in lab 4.. :)");
            //return dt;

            myConnection.Open();
            string myQuery = $"exec getStaffingGrid_p '{year}'";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            myConnection.Close();

            return dt;
        }
    }
}
