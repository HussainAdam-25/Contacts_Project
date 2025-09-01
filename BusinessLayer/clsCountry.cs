using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DataAccessLayer;

namespace BusinessLayer
{
  public class clsBusinessLayerCountry
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int CountryID
        {

            get; set;
        }


        public string CountryName
        {

            get; set;
        }

        public clsBusinessLayerCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
           Mode= enMode.AddNew;
        }



        private clsBusinessLayerCountry(int CountryID ,string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }


        //////////////////////////////////////////////////////////////////
        //
        //////////////////////////////////////////////////////////////////
        ///
        private bool _UpdateCountry()
        {
            //call DataAccess Layer 
            if (clsDataAccessLayerForCountries.UpdateCountry(this.CountryID, this.CountryName))
            {
                return true;
            }
            else
                return false ;

        }
        /// //////////////////////////////////////////////////////////////////
        private bool _AddNewCountry()
        {
            //Console.WriteLine("");

            this.CountryID = clsDataAccessLayerForCountries.AddNewCountryOnDataBase(this.CountryName);

            return (this.CountryID != -1);
        }

        /// //////////////////////////////////////////////////////////////
    
        public static clsBusinessLayerCountry Find(int CountryID)
        {
            string CountryName = "";


            if (clsDataAccessLayerForCountries.GetCountryInfoByID(CountryID,ref CountryName))
            {
               
                return new clsBusinessLayerCountry(CountryID, CountryName);

            }


            else
            {
                //Console.WriteLine("ID is not found");
                return null;
            }

        }


        /// //////////////////////////////////////////////////////////////

        public static clsBusinessLayerCountry Find(string CountryName)
        {
            int CountryID = -1;


            if (clsDataAccessLayerForCountries.GetCountryInfoByName(ref CountryID, CountryName))
            {

                return new clsBusinessLayerCountry(CountryID, CountryName);

            }


            else
            {
                
                return null;
            }

        }

        /////////////////////////////////////////////////////////////////////
        

        public static bool IsCountryExist(int ID)
        {

            return clsDataAccessLayerForCountries.IsCountryExist(ID);
        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////

        public static bool DeleteCuntryDirectly(int ID)
        {

            return clsDataAccessLayerForCountries.DeleteCountry(ID);
        }

        /////////////////////////////////////////////////////////////////////


        public static DataTable GetAllCountries()
        {

            return clsDataAccessLayerForCountries.ListCountries();
        }


        /////////////////////////////////////////////////////////////////////



        public static bool IsCountryExist(string CountryName)
        {

            return clsDataAccessLayerForCountries.IsCountryExist(CountryName);
        }

        /////////////////////////////////////////////////////////////////////

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewCountry();
                    }



                case enMode.Update:
                    {
                        return _UpdateCountry();
                        
                    }


                default:
                    return false;

            }
        }


        /////////////////////////////////////////////////////////////////////




    }








}
