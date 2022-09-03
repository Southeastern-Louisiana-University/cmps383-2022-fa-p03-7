namespace FA22.P02.Web.Features
{


    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string? Condition { get; set; }
        public ICollection<ItemListing> ItemListings { get; set; }

    }
}
