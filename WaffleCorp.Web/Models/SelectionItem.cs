namespace WaffleCorp.Web.Models
{
    public class SelectionItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsErrorVisible { get; set; }
    }
}
