namespace Api.DTO
{
    public class ItemModel
    {
        public string  Name { get; set; }

        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}
