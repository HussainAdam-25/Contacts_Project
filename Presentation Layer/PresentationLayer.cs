using System;
using System.Data;

using BusinessLayer;

namespace Contacts_Solution__Console_app____Find_Contact
{
    class PresentationLayer
    {
        ///////////////////////////////////////////////////////////////////////////
        static void IDExistOrNot(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Console.WriteLine(Contact.ID);
                Console.WriteLine(Contact.FirstName + " " +Contact.LastName);
               
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.CountryID);
                Console.WriteLine(Contact.DateOfBirth);
                Console.WriteLine(Contact.ImagePath);

            }

            else

            {
                Console.WriteLine("ID is Not Exist");

            }

        }


        ///////////////////////////////////////////////////////////////////////////
        static void Find(int ID)
        {
            clsBusinessLayerCountry Contact = clsBusinessLayerCountry.Find(ID);

            if (Contact != null)
            {
                
                Console.WriteLine(Contact.CountryID + " " + Contact.CountryName);

             

            }

            else

            {
                Console.WriteLine($"CountryID [{ID}] is Not Exist ");

            }

        }


        ///////////////////////////////////////////////////////////////////////////
        static void Find(string  CountryName)
        {
            clsBusinessLayerCountry Contact = clsBusinessLayerCountry.Find(CountryName);

            if (Contact != null)
            {

                Console.WriteLine(Contact.CountryID + " " + Contact.CountryName);



            }

            else

            {
                Console.WriteLine($"CountryID [{CountryName}] is Not Exist ");

            }

        }

        ///////////////////////////////////////////////////////////////////////////
        static void AddNewContact()
        {
            clsContact Contact1 = new clsContact();

           
            Contact1.FirstName = "Fher";
            Contact1.LastName = "ali";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);

            }
           

        }


        ///////////////////////////////////////////////////////////////////////////
        static void AddNewCountry()
        {
            clsBusinessLayerCountry Country1 = new clsBusinessLayerCountry();


            Country1.CountryName = "Syria";
         
            if (Country1.Save())
            {
                Console.WriteLine("Country Added Successfully with id=" + Country1.CountryID);

            }

            else
                Console.WriteLine("Country Added Failed with id=" + Country1.CountryID);


        }


        ///////////////////////////////////////////////////////////////////////////
        static void UpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);


            if(Contact1 != null)
            {
                Contact1.FirstName = "Abdo";
                Contact1.LastName = "Hashem";
                Contact1.Email = "abdo@.com";
                Contact1.Phone = "0199650";
                Contact1.Address = "address0";
                Contact1.DateOfBirth = new DateTime(1999, 11, 3, 5, 5, 0);
                Contact1.CountryID = 2;
                Contact1.ImagePath = "";

            }
           

            if (Contact1.Save())
            {
                Console.WriteLine(" Contact updated Successfully " );

            }


        }

        ///////////////////////////////////////////////////////////////////////////
        static void DeleteContact(int ID)
        {
            if(clsContact.DeleteContactdirectly(ID))
            {

                Console.WriteLine("Deleted Is Successfuly.");
            }

            else
                Console.WriteLine("Deleted Is Faield.");
        }

        ///////////////////////////////////////////////////////////////////////////
        static void DeleteCountry(int ID)
        {
            if (clsBusinessLayerCountry.DeleteCuntryDirectly(ID))
            {

                Console.WriteLine("Deleted Is Successfuly.");
            }

            else
                Console.WriteLine("Deleted Is Faield.");
        }


        ///////////////////////////////////////////////////////////////////////////



        //////////////////////////////////////////////////////////////////////////////
        static void ListContacts()
        {
            DataTable dt = clsContact.GetAllContacts();

            Console.WriteLine("Contatcts Data :");


            foreach(DataRow Row in dt.Rows)
            {
                Console.WriteLine($"{Row["ContactID"]}, {Row["FirstName"]} {Row["LastName"]}, {Row["CountryID"]}");

            }


        }


        ///////////////////////////////////////////////////////////////////////////
     
        /// /////////////////////////////////////////////////////////////////////////////
        static void IsContactExist(int ID)
        {
           if(clsContact.IsContactExist(ID))
            {
                Console.WriteLine("Client Is Exist");

            }

           else
            {
                Console.WriteLine("Client Is NOT Exist");

            }

        }


        /// /////////////////////////////////////////////////////////////////////////////
        static void IsCountryExist(int CountryID)
        {
            if (clsBusinessLayerCountry.IsCountryExist(CountryID))
            {
                Console.WriteLine("Country Is Exist");

            }

            else
            {
                Console.WriteLine("Country Is NOT Exist");

            }

        }


        /// /////////////////////////////////////////////////////////////////////////////
        static void IsCountryExist(string CountryName)
        {
            if (clsBusinessLayerCountry.IsCountryExist(CountryName))
            {
                Console.WriteLine("Country Is Exist");

            }

            else
            {
                Console.WriteLine("Country Is NOT Exist");

            }

        }

        ///////////////////////////////////////////////////////////////////////////
        static void UpdateCountry(int ID)
        {
            clsBusinessLayerCountry Country1 = clsBusinessLayerCountry.Find(ID);


            if (Country1 != null)
            {
                Country1.CountryName = "Egypt";
               

            }


            if (Country1.Save())
            {
                Console.WriteLine(" Country updated Successfully ");

            }


            else
            {
                Console.WriteLine(" Country updated Failed ");
            }

        }


        //////////////////////////////////////////////////////////////////////////////
        static void ListCountries()
        {
            DataTable dt = clsBusinessLayerCountry.GetAllCountries();

            Console.WriteLine("Countries Data :");


            foreach (DataRow Row in dt.Rows)
            {
                Console.WriteLine($"{Row["CountryID"]}  , {Row["CountryName"]} ");

            }


        }


        ///////////////////////////////////////////////////////////////////////////
        ///
        /// 

        static void Main(string[] args)
        {
            //Find Method
            IDExistOrNot(2);

            AddNewContact();

            UpdateContact(10);
            DeleteContact(10);

            ListContacts();


            IsContactExist(8);

            ////////////////////////////////////// Functions Countries


            Find(3);

            Find("germany");
            IsCountryExist(7);

            IsCountryExist("United States");


            AddNewCountry();

            UpdateCountry(6);
            DeleteCountry(6);

            ListCountries();


            Console.ReadKey();
        }
    }
}
