namespace E_USED.Dtos
{
    public class FilterProductModel
    {
        public int CategoryId { get; set; } = 0;
        public string ProductName { get; set; }
        public int CityId { get; set; } = 0;
        public int Skip { get; set; }
        public int Count { get; set; }
        public int Take { get; set; }
    }
}
