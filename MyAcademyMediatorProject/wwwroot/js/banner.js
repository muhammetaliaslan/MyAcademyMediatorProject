$(document).ready(function () {

    let $carousel = $(".banner-carousel");

    function setBg(index) {

        let $slides = $(".banner-carousel .slide-item");
        let bg = $slides.eq(index).data("bg");

        if (bg) {
            $(".banner-section").css("background-color", bg);
            // ❌ body kaldırıldı
        }
    }

    $carousel.on("initialized.owl.carousel", function () {
        setBg(0);
    });

    $carousel.on("translated.owl.carousel", function (event) {
        setBg(event.item.index);
    });

});
$(document).ready(function () {

    // banner carousel vs kodların
    let $carousel = $(".banner-carousel");

    // diğer banner işlemleri...

});

window.addEventListener("scroll", function () {
    var header = document.querySelector(".main-header");

    if (!header) return;

    if (window.scrollY > 50) {
        header.classList.add("scrolled");
    } else {
        header.classList.remove("scrolled");
    }
});