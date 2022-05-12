
namespace Parking
{
    internal class GetCarInfo : IGetCarInfo
    {
        public string carName;
        public string carNumber;
        public GetCarInfo(string carName, string carNumber)
        {
            this.carName = carName;
            this.carNumber = carNumber;
        }
        public void CarInfo()
        {

        }
    }
}
