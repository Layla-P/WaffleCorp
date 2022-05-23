using Microsoft.AspNetCore.Components;
using WaffleCorp.Web.Models;
using WaffleCorp.Web.Helpers;
using Microsoft.JSInterop;

namespace WaffleCorp.Web.Pages
{

    public class IndexBase : ComponentBase
    {
        public List<SelectionItem> Bases;
        public List<SelectionItem> Toppings;
        public List<SelectionItem> Sauces;
        // Bag object with all waffles
        // Current waffle selection
        public Order Order = new();
        public Waffle CurrentWaffle = new();
        [Inject] private AppJsInterop AppJsInterop { get; set; }


        protected override async Task OnInitializedAsync()
        {
            GetBases();
            GetToppings();
            GetSauces();
            await AppJsInterop.SetBodyId("home");
        }

        public void BaseSelect(SelectionItem baseItem)
        {
            Bases.ForEach(b => b.IsActive = false);
            baseItem.IsActive = true;
            CurrentWaffle.WaffleBase = new()
            {
                WaffleShape = baseItem.Title,
                Price = baseItem.Price
            };
        }

        public void ToppingSelect(SelectionItem toppingItem)
        {
            
            if (!toppingItem.IsActive)
            {
                if (CurrentWaffle.Toppings.Count() < 4)
                {
                    CurrentWaffle.Toppings.Add(new Topping(toppingItem));
                    toppingItem.IsActive = true;
                }
                else
                {
                    ShowToppingsError(toppingItem);
                }
            }
            else
            {

                CurrentWaffle.Toppings.RemoveAll(i => i.ToppingName == toppingItem.Title);
                toppingItem.IsActive = false;
            }

        }




    public void ShowToppingsError(SelectionItem toppingItem)
    {
        Task.Run(async () =>
           {
               toppingItem.IsErrorVisible = true;
               StateHasChanged();
               await Task.Delay(5000);
               toppingItem.IsErrorVisible = false;
               StateHasChanged();
           }
        );
    }

    private void GetBases()
    {
        Bases = new()
            {
                new SelectionItem
                {
                    Title = "Circle",
                    Description = "Like a record, baby, right 'round",
                    Price = 4.00M,
                    ImagePath = "img/Waffle-circle.svg"
                },
                new SelectionItem
                {
                    Title = "Septagon",
                    Description = "Free your apps(etite)",
                    Price = 4.00M,
                    ImagePath = "img/Waffle-septagon.svg"
                },
                new SelectionItem
                {
                    Title = "Parallelogram",
                    Description = "Leans up and to the right",
                    Price = 6.00M,
                    ImagePath = "img/Waffle-parallelogram.svg"
                },
                new SelectionItem
                {
                    Title = "Turtle",
                    Description = "Crannies in a half shell",
                    Price = 6.00M,
                    ImagePath = "img/Waffle-turtle.svg"
                }
            };
    }
    private void GetToppings()
    {
        Toppings = new()
            {
                new SelectionItem
                {
                    Title = "Cherries",
                    Description = "Just \"the pits\"",
                    Price = 4.00M,
                    ImagePath = "img/Toppings-cherries.svg"
                },
                new SelectionItem
                {
                    Title = "Spiders",
                    Description = "More legs = more flavor",
                    Price = 4.00M,
                    ImagePath = "img/Toppings-spider.svg"
                },
                new SelectionItem
                {
                    Title = "Plastic Blocks",
                    Description = "With added nutrients (for color)",
                    Price = 4.00M,
                    ImagePath = "img/Toppings-legos.svg"
                },
                new SelectionItem
                {
                    Title = "Succulents",
                    Description = "Do not water",
                    Price = 6.00M,
                    ImagePath = "img/Toppings-succulents.svg"
                },
                new SelectionItem
                {
                    Title = "Eyeballs",
                    Description = "Imagine what they've seen",
                    Price = 5.00M,
                    ImagePath = "img/Toppings-eyeballs.svg"
                },
                new SelectionItem
                {
                    Title = "Fried Chicken",
                    Description = "Try to resist it",
                    Price = 5.00M,
                    ImagePath = "img/Toppings-chicken.svg"
                },
                new SelectionItem
                {
                    Title = "Popcorn",
                    Description = "Crunch force multiplier",
                    Price = 4.00M,
                    ImagePath = "img/Toppings-popcorn.svg"
                },
                new SelectionItem
                {
                    Title = "Surprise",
                    Description = "What do you have to lose?",
                    Price = 4.00M,
                    ImagePath = "img/Toppings-dice.svg"
                }
            };
    }
    private void GetSauces()
    {
        Sauces = new()
            {
                new SelectionItem
                {
                    Title = "Maple Syrup",
                    Description = "Comes from the tree out back",
                    Price = 2.00M,
                    ImagePath = "img/Sauce-Maple-syrup.svg"
                },
                new SelectionItem
                {
                    Title = "Slime",
                    Description = "Ingredients unknown",
                    Price = 3.00M,
                    ImagePath = "img/Sauce-Slime.svg"
                },
                new SelectionItem
                {
                    Title = "Lava",
                    Description = "Pricier than you'd think; very hot",
                    Price = 12.00M,
                    ImagePath = "img/Sauce-Lava.svg"
                },
                new SelectionItem
                {
                    Title = "Bubbles",
                    Description = "For a cleaner waffle",
                    Price = 6.00M,
                    ImagePath = "img/Sauce-Bubbles.svg"
                }
            };
    }
}
}
