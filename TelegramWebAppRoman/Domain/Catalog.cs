using System.Text.Json.Serialization;

namespace TelegramWebAppRoman.Domain
{
    public class Catalog : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Item>? Items { get; set; }
    }
}
