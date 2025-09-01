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
    
    public class clsDataAccessLayerForCountries
    {

        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;


                    CountryName = Convert.ToString(Reader["CountryName"]);

                }

                else
                {
                    IsFound = false;

                }

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

        //////////////////////////////////////////////////////////////////////////

        public static bool GetCountryInfoByName(ref int CountryID, string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;


                    CountryID = (int)Reader["CountryID"];

                }

                else
                {
                    IsFound = false;

                }

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

        //////////////////////////////////////////////////////////////////////////


        public static int AddNewCountryOnDataBase(string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"insert Into Countries (CountryName)
                     values (@CountryName) 
                       SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

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

               
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }
            return -1;

        }


        ////////////////////////////////////////////////////////////////
        
        public static bool IsCountryExist(int CountryID)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select found=2 from Countries 
                               where CountryID=@CountryID";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);


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


        ////////////////////////////////////////////////////////////////
        
        public static bool IsCountryExist(string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select found=2 from Countries 
                               where CountryName=@CountryName";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);


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


        ////////////////////////////////////////////////////////////////

        public static bool UpdateCountry(int CountryID , string CountryName)
        {
             bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Update Countries 
                      set  CountryName=@CountryName
                         where CountryID=@CountryID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CountryID", CountryID);


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

                   IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        ////////////////////////////////////////////////////////////////

        public static bool DeleteCountry(int CountryID)
        {
             bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Delete Countries 
                         where CountryID=@CountryID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);


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

                 IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        ////////////////////////////////////////////////////////////////

        public static DataTable ListCountries()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select * from Countries ";


            SqlCommand command = new SqlCommand(query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
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


        //////////////////////////////////////////////////////////////////////////
        ///


    }




}

