// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let header = document.querySelector("#header");
let navButton = document.querySelector(".nav-button");
let posts = document.querySelectorAll(".post");
let postImages = document.querySelectorAll(".post-image");

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
posts.forEach((p, i) => {
    p.addEventListener("mouseenter", () => {
        postImages[i].classList.add("post-image-hovered");
    })
    p.addEventListener("mouseleave", () => {
        postImages[i].classList.remove("post-image-hovered");
    })
})
