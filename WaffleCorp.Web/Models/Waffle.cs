namespace WaffleCorp.Web.Models
{
    public class Waffle
    {
        public int Id { get; set; }
        public List<Topping> Toppings { get; set; } = new();

        public decimal Price { get { return Total(); } }

        public WaffleBase WaffleBase { get; set; }

        private decimal Total() => Toppings.Sum(x => x.Price) + WaffleBase.Price;
    }

    public class Topping
    {
        public Topping(SelectionItem item)
        {
            ToppingName = item.Title;
            Price = item.Price;
        }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }
    }

    public class WaffleBase
    {
        public string WaffleShape { get; set; }
        public decimal Price { get; set; }
    }

}
