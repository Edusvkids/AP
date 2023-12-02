$(function () {

    "use strict"

    var init = "No items yet!";
    var counter = 0;

    // Initial Cart
    $(".counter").html(init);

    // Add Items To Basket
    function addToBasket() {
        counter++;
        $(".counter").html(counter).animate({
            'opacity': '0'
        }, 300, function () {
            $(".counter").delay(300).animate({
                'opacity': '1'
            })
        })
    }

    // Add To Basket Animation
    
});







