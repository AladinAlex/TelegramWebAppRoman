namespace TelegramWebAppRoman.Domain
{
    public class Item : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CatalogId { get; set; }
        public Catalog? Catalog { get; set; }
    }
}
