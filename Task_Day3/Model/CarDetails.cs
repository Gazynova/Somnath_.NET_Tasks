namespace Task_Day3.Model
{
    class CarDetails
    {
        public int ID;
        public string Brand;
        public string Model;
        public DateTime Releaseyear = DateTime.Now;
        private double Price;

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
            get { return Releaseyear; }
            set { Releaseyear = value; }

        }


        public double CarPrice
        {
            get { return Price; }
            set { Price = value; }

        }

        public void GetDetails()
        {
            Console.WriteLine("\nReceiving Car Information:");
            Console.Write("Brand: ");
            Brand = Console.ReadLine();
            Console.Write("ID: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Model: ");
            Model = Console.ReadLine();
            Console.Write("Price: ");
            Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Release Year (yyyy): ");
            //Releaseyear = Convert.ToDateTime(Console.ReadLine());


            //Console.WriteLine($"ID::{CarID}\nBrand::{CarBrand}\nModel::{CarModel}\n::Year::{CarYear}\nPrice::{CarPrice}");



        }

        public CarDetails()
        {
            GetDetails();
        }

        public CarDetails(int id, string brand, string model, double price, DateTime releaseYear)
        {
            this.ID = id;
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.Releaseyear = releaseYear;
        }

        

        public void DisplayDetails()
        {
            Console.WriteLine($"\nCarID::{ID}\nBrandName::{Brand}\nModelName::{Model}\nReleaseYear::{Releaseyear}\nPrice::{Price}");
            //Console.WriteLine("Receiving Car Info:");
        }

    }
}
