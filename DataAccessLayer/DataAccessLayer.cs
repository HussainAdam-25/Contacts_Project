using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ContactDB_DataAccessLayer;
using System.Data;

namespace DataAccessLayer
{
    public class clsDataAccessLayer
    {
     //   static string connectionString = "Server=.;Database=contactsDB2;User Id=sa;Password=123456;"; //
      

        public static bool GetContactInfoByID(int ContactID, ref string FirstName,
            ref string lastname, ref string address, ref string email, ref string phone
            , ref int CountryID, ref DateTime dateOfBirth, ref string ImagePath)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    //  CountryID = (int)Reader["ContactID"];
                    FirstName = (string)Reader["FirstName"];
                    lastname = (string)Reader["LastName"];
                    email = (string)Reader["Email"];
                    address = (string)Reader["Address"];
                    phone = (string)Reader["Phone"];
                    CountryID = (int)Reader["CountryID"];
                    dateOfBirth = (DateTime)Reader["DateOfBirth"];
                    ImagePath = Convert.ToString(Reader["ImagePath"]);
                }

                else
                {
                    IsFound = false;

                }

                Reader.Close();


            }


            catch (Exception ex)
            {

            //    IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        ///////////////////////////////////////////////////////////////////////////////


        public static int AddNewContactOnDataBase( string FirstName,
             string lastname,  string address,  string email,  string phone
            ,  int CountryID,  DateTime dateOfBirth, string ImagePath)
        {
          


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Insert Into Contacts (FirstName,lastname,address
                ,email,phone,CountryID,dateOfBirth,ImagePath) 
              Values(@FirstName,@lastname,@address,@email,@phone,@CountryID,@dateOfBirth,@ImagePath)
              SELECT SCOPE_IDENTITY(); "
               ;

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {

                    return insertedID;
                }

                else
                {
                    return -1;

                }


            }


            catch (Exception ex)
            {

                //    IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return -1;
        }

        ////////////////////////////////////////////////////////////////
        
            public static bool UpdateContact(int ContactID, string FirstName,
             string lastname, string address, string email, string phone
            , int CountryID, DateTime dateOfBirth, string ImagePath)
        {
            // bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Update Contacts 
                      set  FirstName=@FirstName,
                          lastname=@lastname,
                          address=@address,
                          email=@email,
                          phone=@phone,
                          CountryID=@CountryID,
                          dateOfBirth=@dateOfBirth,
                          ImagePath=@ImagePath
                         where ContactID=@ContactID ";

             
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();
                int  RowAffected = command.ExecuteNonQuery();

              if(RowAffected >0)
                {
                    return true;

                }

                else
                {
                    return false;

                }


            }


            catch (Exception ex)
            {

                //    IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return false;
        }



        ////////////////////////////////////////////////////////////////

        public static bool DeleteContact(int ContactID)
        {
            // bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Delete Contacts 
                         where ContactID=@ContactID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);
           

            try
            {
                Connection.Open();
                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    return true;

                }

                else
                {
                    return false;

                }


            }


            catch (Exception ex)
            {

                //    IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return false;
        }



        ////////////////////////////////////////////////////////////////

        public static DataTable ListContacts()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select * from Contacts ";


            SqlCommand command = new SqlCommand(query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if(Reader.HasRows)
                {
                    Dt.Load(Reader);

                }

                Reader.Close();
            }


            catch (Exception ex)
            {

               
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return Dt;
        }


        ////////////////////////////////////////////////////////////////

        public static bool IsContactExist(int ContactID)
        {
            bool IsFound = false;
           

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select found=1 from Contacts 
                               where ContactID=@ContactID";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                IsFound = Reader.HasRows;
                

                Reader.Close();
            }


            catch (Exception ex)
            {

                IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }




        ////////////////////Finaly////////////////////
    }
}