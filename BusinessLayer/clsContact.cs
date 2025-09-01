using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsContact
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public int ID
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public DateTime DateOfBirth
        {
            get; set;
        }
        public int CountryID
        {
            get; set;
        }

        public string ImagePath
        {
            get; set;
        }

        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }



        private clsContact(int ID, int CountryID, string FirstName, string LastName, string Email,
            string Phone, string Address, DateTime DateOfBirth, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }

        
        /// //////////////////////////////////////////////////////////////////
       private bool _AddNewContact()
        {
            //Console.WriteLine("");

            this.ID = clsDataAccessLayer.AddNewContactOnDataBase(this.FirstName, this.LastName, this.Address
               , this.Email, this.Phone, this.CountryID, this.DateOfBirth, this.ImagePath);

            return (this.ID != -1);
        }



        //////////////////////////////////////////////////////////////////
        ///
        private bool _UpdateContact()
        {
            //call DataAccess Layer 
            
            return clsDataAccessLayer.UpdateContact(this.ID, this.FirstName, this.LastName, this.Address, this.Email, this.Phone
           , this.CountryID, this.DateOfBirth,  this.ImagePath);

        }
        //////////////////////////////////////////////////////////////////
        //



        public static clsContact Find(int ID)
        {
            string FirstName = "", lastname = "", address = "", phone = "", email = "", ImagePath = "";

            int CountryID = 1;
            DateTime dateOfBirth = DateTime.Now;

            if (clsDataAccessLayer.GetContactInfoByID(ID, ref FirstName, ref lastname, ref address,
                ref email, ref phone, ref CountryID, ref dateOfBirth, ref ImagePath))
            {
                //  Console.WriteLine("ID is found");
                return new clsContact(ID, CountryID, FirstName, lastname, email, phone, address, dateOfBirth, ImagePath);

            }


            else
            {
                //Console.WriteLine("ID is not found");
                return null;
            }

        }

        /////////////////////////////////////////////////////////////////////
      
            public static bool DeleteContactdirectly(int ID)
        {

           return  clsDataAccessLayer.DeleteContact(ID);
        }


        /////////////////////////////////////////////////////////////////////


      public static DataTable GetAllContacts()
        {

           return  clsDataAccessLayer.ListContacts();
        }

        /////////////////////////////////////////////////////////////////////


        public static bool IsContactExist(int ID)
        {

            return clsDataAccessLayer.IsContactExist(ID);
        }

        /////////////////////////////////////////////////////////////////////

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewContact();
                    }
                   
                   

                case enMode.Update:
                    {
                      return _UpdateContact();
                    }
                      

                default:
                    return false;

            }
        }

        /////////////////////////////////////////////////////////////////////
    }
}
