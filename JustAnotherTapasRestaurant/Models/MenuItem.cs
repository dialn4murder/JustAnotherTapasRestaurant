namespace JustAnotherTapasRestaurant.Models
{
    public class MenuItem
    {
        // Creates representation of fields from the database
        public int Id { get; set; }
        public string Item {  get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string? ImageDescription { get; set; }
        public byte[]? ImageData { get; set; }


    }
}
