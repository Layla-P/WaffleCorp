// Selection behavior for base + toppings
var selectionCards = document.querySelectorAll(".selection-card");
var pastOrders = document.querySelectorAll(".past-order");
var base = false;
var toppings = false;

selectionCards.forEach(function(elem) {
  elem.addEventListener("click", function() {
    parentDiv = this.parentNode;

    // You can only select one base
    if (parentDiv.id === "base") {
      let elems = document.querySelectorAll("#base .selection-card");

      if (this.classList.contains("active")) {
        [].forEach.call(elems, function(el) {
            el.classList.remove("active");
        });
      }
      else {
        [].forEach.call(elems, function(el) {
          el.classList.remove("active");
        });
        this.classList.toggle('active');
      }
    }

    // You can only select up to four toppings
    else if (parentDiv.id === "toppings"){
      if (this.classList.contains("active")) {
        this.classList.toggle("active");
      }
      else if (parentDiv.querySelectorAll(".active").length === 4 ) {
        // alert("You can only select up to four toppings");
        let alertDiv = document.createElement("div");
        const textnode = document.createTextNode("You can only select up to 4 toppings");
        alertDiv.classList.add("alert-container");
        alertDiv.appendChild(textnode);
        alertDiv.setAttribute("role", "alert");
        this.appendChild(alertDiv);
      }
      else {
        this.classList.toggle('active');
      }
    }
  });
});

// Bag side panel
function openBag() {
  document.querySelector("html").classList.add("hide-scroll");
  document.querySelector(".bag").classList.add("is-active");
  document.querySelector("main").classList.add("bag-is-active");
}
function closeBag() {
  document.querySelector("html").classList.remove("hide-scroll");
  document.querySelector("main").classList.remove("bag-is-active");
  document.querySelector(".bag").classList.remove("is-active");
}
document.querySelector("main").onmousedown = function() {
  closeBag()
};

// Order history slide toggle
function toggleSlide() {
  document.querySelector("this").classList.add("is-visible");
}

pastOrders.forEach(function(elem) {
  elem.addEventListener("click", function() {
    this.classList.toggle('is-visible');
  });
});

// Random headline generator
var rand = Math.floor((Math.random()*29));
const headers = [
  "Create the bespoke waffle masterpiece of your dreams",
  "Put your best waffle forward",
  "Artisanal waffles have arrived",
  "Legendary waffles you can make your own",
  "Curious waffles done your way",
  "Join the waffle revolution",
  "The next generation of waffles",
  "A modern riff on the classic waffle",
  "Craft your own waffley delicious works of art",
  "These aren't your grandmother's waffles",
  "Build your best waffles, faster",
  "Waffles that make you go, \"Hmmmmm\"",
  "Explore the uncranny valley",
  "Waffles all the way down",
  "Get to know the something-for-everyone waffle",
  "Elevate your palette with homespun waffles",
  "The modern lifestyle waffle for modern life",
  "Build the waffle to end all waffles",
  "Experience the Wafflecorp difference",
  "Chaotic creations, waffley good",
  "Think outside the waffle maker",
  "Breakfast of champions. <br>(And lunch/dinner.)",
  "Say goodbye to boring waffles",
  "Free your waffles. Simplify your taste buds.",
  "Say hello to Waffles-as-a-Service",
  "Realize what's waffleble",
  "Take your waffles to the next level",
  "Accelerate your waffle innovation",
  "When you’re here, you’re waffily"
];
if(document.getElementsByTagName("body")[0].id == 'home') {
  console.log(rand)
  window.addEventListener('DOMContentLoaded', (event) => {
    document.getElementById('random-headline').innerHTML = headers[rand];
  });
}
