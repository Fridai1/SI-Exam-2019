namespace ConsumerApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public int Doors { get; set; }

        public Car(int id, string licensePlate, string brand, int doors)
        {
            Id = id;
            LicensePlate = licensePlate;
            Brand = brand;
            Doors = doors;
        }

        public Car()
        {
           
        }
    }
}