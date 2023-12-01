



const productDetails = [
    {
        name: "Puñado de monedas",
        price: 0.99,
        imageUrl: "https://i.pinimg.com/564x/8b/78/5b/8b785b35d844eecb0f6e44312aec04b2.jpg",
        qty: 10,
        heading: "80 monedas",
    },

    {
        name: " Pila de monedas",
        price: 4.99,
        imageUrl: "https://i.pinimg.com/564x/8b/78/5b/8b785b35d844eecb0f6e44312aec04b2.jpg",
        qty: 15,
        heading: " 550 monedas",

    },


    {
        name: " Bolsa de monedas",
        price: 9.99,
        imageUrl: "https://i.pinimg.com/564x/8b/78/5b/8b785b35d844eecb0f6e44312aec04b2.jpg",
        qty: 20,
        heading: "1,200 monedas",
    },

    {
        name: "Saco de monedas",
        price: 19.99,
        imageUrl:
            "https://i.pinimg.com/564x/8b/78/5b/8b785b35d844eecb0f6e44312aec04b2.jpg",
        qty: 35,
        heading: " 2,500 monedas",
    },

    {
        name: "  Caja de monedas ",
        price: 49.99,
        imageUrl:
            "https://i.pinimg.com/564x/8b/78/5b/8b785b35d844eecb0f6e44312aec04b2.jpg",
        qty: 25,
        heading: " 6,500 monedas",
    }];


const cartDetails = [];







function qtyChange(event, handler) {
    let btnClicked = event.parentElement.parentElement;
    let isPresent = btnClicked.classList.contains("btn-add");
    let itemName = isPresent ?
        btnClicked.parentElement.parentElement.getElementsByClassName(
            "product-name")[
            0].innerText :
        btnClicked.parentElement.getElementsByClassName("name")[0].innerText;
    let productNames = document.getElementsByClassName("product-name");
    for (let name of productNames) {
        if (itemName == name.innerText) {
            let productBtn = name.parentElement.parentElement.getElementsByClassName(
                "qty-change")[
                0];
            cartDetails.forEach((item, i) => {
                if (itemName == item.name) {
                    if (handler == "add" && item.qty < 10) {
                        item.qty += 1;
                        btnClicked.innerHTML = QtyBtn(item.qty);
                        productBtn.innerHTML = QtyBtn(item.qty);
                    } else if (handler == "sub") {
                        item.qty -= 1;
                        btnClicked.innerHTML = QtyBtn(item.qty);
                        productBtn.innerHTML = QtyBtn(item.qty);
                        if (item.qty < 1) {
                            cartDetails.splice(i, 1);
                            productBtn.innerHTML = AddBtn();
                            productBtn.classList.toggle("qty-change");
                        }
                    } else {
                        document.getElementsByClassName("purchase-cover")[0].style.display =
                            "block";
                        document.getElementsByClassName("stock-limit")[0].style.display =
                            "flex";
                        sideNav(0);
                    }
                }
            });
        }
    }
    RenderCart();
    CartIsEmpty();
    CartItemsTotal();
}



function AddBtn() {
    href = " https://buy.stripe.com/test_bIY03IecIaao86c8wB"
}



function Product(product = {}) {
    let { name, price, imageUrl, heading, des } = product;
    return `
<div class='card'>
  <div class='top-bar'>
    <i class='fab fa-apple'></i>
    <em class="stocks"></em>
  </div>
  <div class='img-container'>
    <img class='product-img' src='${imageUrl}' alt='' />
    <div class='out-of-stock-cover'><span>Out Of Stock</span></div>
  </div>
  <div class='details'>
    <div class='name-fav'>
      <strong class='product-name'>${name}</strong>
      <button onclick='this.classList.toggle("fav")' class='heart'><i class='fas fa-heart'></i></button>
    </div>
    <div class='wrapper'>
      <h5>${heading}</h5>
      
    </div>
    <div class='purchase'>
      <p class='product-price'>$ ${price}</p>
      <span class='btn-add'>${AddBtn()}</span>
    </div>
  </div>
</div>`;
}

function CartItems(cartItem = {}) {
    let { name, price, imgSrc, qty } = cartItem;
    return `
<div class='cart-item'>
  <div class='cart-img'>
    <img src='${imgSrc}' alt='' />
  </div>
  <strong class='name'>${name}</strong>
  <span class='qty-change'>${QtyBtn(qty)}</span>
  <p class='price'>₹ ${price * qty}</p>
  <button onclick='removeItem(this)'><i class='fas fa-trash'></i></button>
</div>`;
}

function Banner() {
    return `
<div class='banner'>
  <ul class="box-area">
  <li></li>
  <li></li>
  <li></li>
  <li></li>
  <li></li>
  <li></li>
  </ul>
  <div class='main-cart'>${DisplayProducts()}</div>

  <div class='nav'>
    <button onclick='sideNav(1)'><i class='fas fa-shopping-cart' style='font-size:2rem;'></i></button>
    <span class= 'total-qty'>0</span>
  </div>
  <div onclick='sideNav(0)' class='cover'></div>
  <div class='cover purchase-cover'></div>
  <div class='cart'>${CartSideNav()}</div>
  <div class='stock-limit'>
    <em>You Can Only Buy 10 Items For Each Product</em>
    <button class='btn-ok' onclick='limitPurchase(this)'>Okay</button>
  </div>
<div  class='order-now'></div>
</div>`;
}

function CartSideNav() {
    return `
<div class='side-nav'>
  <button onclick='sideNav(0)'><i class=''></i></button>
  <h2>Cart</h2>
  <div class='cart-items'></div>
  <div class='final'>
    <strong>Total: ₹ <span class='total'>0</span>.00/-</strong>
    <div class='action'>
      <button onclick='buy(1)' class='btn buy'>Purchase <i class='fas fa-credit-card' style='color:#6665dd;'></i></button>
      <button onclick='clearCart()' class='btn clear'>Clear Cart <i class='fas fa-trash' style='color:#bb342f;'></i></button>
    </div>
  </div>
</div>`;
}






function DisplayProducts() {
    let products = productDetails.map(product => {
        return Product(product);
    });
    return products.join("");
}

function DisplayCartItems() {
    let cartItems = cartDetails.map(cartItem => {
        return CartItems(cartItem);
    });
    return cartItems.join("");
}

function RenderCart() {
    document.getElementsByClassName(
        "cart-items")[
        0].innerHTML = DisplayCartItems();
}

function SwitchBtns(found) {
    let element = found.getElementsByClassName("btn-add")[0];
    element.classList.toggle("qty-change");
    let hasClass = element.classList.contains("qty-change");
    found.getElementsByClassName("btn-add")[0].innerHTML = hasClass ?
        QtyBtn() :
        AddBtn();
}

function ToggleBackBtns() {
    let btns = document.getElementsByClassName("btn-add");
    for (let btn of btns) {
        if (btn.classList.contains("qty-change")) {
            btn.classList.toggle("qty-change");
        }
        btn.innerHTML = AddBtn();
    }
}

function CartIsEmpty() {
    let emptyCart = `<span class='empty-cart'>Looks Like You Haven't Added Any Product In The Cart</span>`;
    if (cartDetails.length == 0) {
        document.getElementsByClassName("cart-items")[0].innerHTML = emptyCart;
    }
}


function Stocks() {
    cartDetails.forEach(item => {
        productDetails.forEach(product => {
            if (item.name == product.name && product.qty >= 0) {
                product.qty -= item.qty;
                if (product.qty < 0) {
                    product.qty += item.qty;
                    document.getElementsByClassName("invoice")[0].style.height = "180px";
                    document.getElementsByClassName(
                        "order-details")[
                        0].innerHTML = `<em class='thanks'>Stocks Limit Exceeded</em>`;
                } else if (product.qty == 0) {
                    OutOfStock(product, 1);
                } else if (product.qty <= 5) {
                    OutOfStock(product, 0);
                }
            }
        });
    });
}

function OutOfStock(product, handler) {
    let products = document.getElementsByClassName("card");
    for (let items of products) {
        let stocks = items.getElementsByClassName("stocks")[0];
        let name = items.getElementsByClassName("product-name")[0].innerText;
        if (product.name == name) {
            if (handler) {
                items.getElementsByClassName("out-of-stock-cover")[0].style.display =
                    "flex";
                stocks.style.display = "none";
            } else {
                stocks.innerText = "Only Few Left";
                stocks.style.color = "orange";
            }
        }
    }
}

function App() {
    return `
<div>
  ${Banner()}
</div>`;
}

document.getElementById("app").innerHTML = App();