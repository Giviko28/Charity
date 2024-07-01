let amountButtons = document.querySelectorAll(".amount");
let customButton = document.querySelector(".custom-amount");
let input = document.querySelector("#Donation_Amount");

amountButtons.forEach((btn) => {
    btn.addEventListener("click", () => {
        input.value = btn.textContent;
    })
});

customButton.addEventListener("click", () => {
    input.value = null;
})

