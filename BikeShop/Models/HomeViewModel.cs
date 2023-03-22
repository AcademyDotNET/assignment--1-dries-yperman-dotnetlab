namespace BikeShop.Models
{
    public class HomeViewModel
    {
        static int count = 0;

        public int GetPicture()
        {
            count = (count % 4) + 1;
            return count;
        }
    }
}
