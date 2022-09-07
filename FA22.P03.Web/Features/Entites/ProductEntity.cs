namespace FA22.P02.Web.Features
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}