// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let header = document.querySelector("#header");
let navButton = document.querySelector(".nav-button");
document.addEventListener("scroll", () => {
    if (window.scrollY > 0) {
        header.classList.add("header-fixed");
        header.classList.remove("header-normal");
        navButton.classList.add("nav-button-green")
    } else {
        header.classList.add("header-normal");
        header.classList.remove("header-fixed");
        navButton.classList.remove("nav-button-green")
    }
})
