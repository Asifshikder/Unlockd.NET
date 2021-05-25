AOS.init();
$(document).ready(function () {

    jQuery('input#IMEI').focus(function () {
        jQuery('p.text-grey').css('font-size', '3rem');
        jQuery('p.text-grey').css('color', 'red');
    }); jQuery('input#IMEI').focusout(function () {
        jQuery('p.text-grey').css('font-size', '1rem');
        jQuery('p.text-grey').css('color', '#999');
    });

    $('#deviceSlider').carousel({
        interval: 2000
    })
});
window.onscroll = function () { myFunction() };
// Get the header
var header = document.getElementById("myHeader");
// Get the offset position of the navbar
var sticky = header.offsetTop;
// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");
    }
    // jQuery('#devices').css('transform','translateY(0)');
}
$('.slider_D').slick({

    slidesToShow: 5,
    nextArrow: '<button class="any-class-name-you-want-next"><i class="fa fa-chevron-left"></i></button>',
    prevArrow: '<button class="any-class-name-you-want-previous"><i class="fa fa-chevron-right"></i></button>',
    responsive: [
        {
            breakpoint: 768,
            settings: {
                arrows: false,

                slidesToShow: 3
            }
        },
        {
            breakpoint: 480,
            settings: {
                arrows: false,

                slidesToShow: 1
            }
        }
    ]
});

