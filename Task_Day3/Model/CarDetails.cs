using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day3.Model
{
    class CarDetails
    {
        public int ID;
        public string Brand;
        public string Model;
        public DateTime releaseyear = DateTime.Now;
        private double price;

        public int CarID
        {
            get { return ID; }
            set { ID = value; }

        }

        public string CarBrand
        {
            get { return Brand; }
            set { Brand = value; }

        }

        public string CarModel
        {
            get { return Model; }
            set { Model = value; }

        }

        public DateTime CarYear
        {
            get { return releaseyear; }
            set { releaseyear = value; }

        }


        public double CarPrice
        {
            get { return price; }
            set { price = value; }

        }

        public void getDetails()
        {
            Console.WriteLine("Receiving Car Info:");


        }

        public void DisplayDetails()
        {
            Console.WriteLine($"CarID::{CarID}\nBrandName::{Brand}\nModelName::{Model}\nReleaseYear::{releaseyear}\nPrice::{price}");
            //Console.WriteLine("Receiving Car Info:");
        }

    }
}
