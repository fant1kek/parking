
namespace Parking
{
    internal class TruckPlace : IPlaceRental
    {
        private readonly int Price = 150;
        public int RentalTime { get; set; }
        public TruckPlace(int RentalTime)
        {
            this.RentalTime = RentalTime;
        }
        public int GetPrice() => RentalTime * Price;
    }
}
