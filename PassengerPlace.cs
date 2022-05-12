
namespace Parking
{
    internal class PassengerPlace : IPlaceRental
    {
        private readonly int Price = 100;
        public int RentalTime { get; set; }
        public PassengerPlace(int RentalTime)
        {
            this.RentalTime = RentalTime;
        }
        public int GetPrice() => RentalTime * Price;
    }
}
