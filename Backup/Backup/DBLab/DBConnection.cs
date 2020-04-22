using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DBLabs
{
    public class DBConnection : DBLabsDLL.DBConnectionBase
    {
       
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
            return true;
        }
/*
 --------------------------------------------------------------------------------------------
 IMPLEMENTATION TO BE USED IN LAB 2. 
 --------------------------------------------------------------------------------------------
*/

    // Here you need to implement your own methods that call the stored procedures 
    // addStudent and addStudentPhoneNo


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
            return 1;
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
            return 1;
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
            return 1;
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
            return 1;
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
            return 1;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Streetadress");
            dt.Columns.Add("ZipCode");
            dt.Columns.Add("Birthdate");
            dt.Columns.Add("StudentType");
            dt.Columns.Add("City");
            dt.Columns.Add("Country");
            dt.Columns.Add("program");
            dt.Columns.Add("PgmStartYear");
            dt.Columns.Add("credits");
            dt.Rows.Add("ssn11001", "Stud", "Studman", "Male", "StudentRoad 1", "773 33", "1985-11-20 00:00:00", "Program Student", "Västerås", "Sweden", "Datavetenskapliga programmet", 2011, 15);
            return dt;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("pnr");
            dt.Columns.Add("fullname");
            dt.Rows.Add("111111-1111", "Test Testson");
            return dt;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("fullname");
            dt.Rows.Add("ssn11001", "Stud Studman");
            return dt;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("coursecode");
            dt.Columns.Add("name");
            dt.Columns.Add("credits");
            dt.Columns.Add("courseresponsible");
            dt.Rows.Add("DVA234", "Databaser", 7.5, "111111-1111");
            return dt;
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
            //Dummy code - Remove!
            return 10000;
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
            //Dummy code - Remove!
            DataTable dt = new DataTable();
            return dt;

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
            //Dummy code - Remove!
            DataTable dt = new DataTable();
            return dt;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("Course Code");
            dt.Columns.Add("Course Name");
            dt.Rows.Add("DVA111", "C# course");
            return dt;
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

            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("year");
            dt.Columns.Add("period");
            dt.Columns.Add("instance");
            dt.Rows.Add(2012, 4, "2012 p4");
            return dt;
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
            //Dummy code - Remove!
            //Please note that you do not use DataTables like this at all when you are using a database!!
            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("Number");
            dt.Rows.Add("Home", "021-121212");
            return dt;
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
            DataTable dt = new DataTable();
            dt.Columns.Add("Year");
            dt.Rows.Add(2000);
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
            DataTable dt = new DataTable();
            dt.Columns.Add("StaffingGrid");
            dt.Rows.Add("All will be revealed in lab 4.. :)");
            return dt;
        }
    }
}
