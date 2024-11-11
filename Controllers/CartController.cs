using FashionFlare.EntityFramework;
using FashionFlare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FashionFlare.Controllers
{
    // Handles shopping cart operations
    public class CartController : Controller
    {
        private readonly ICartRepository repository;

        // Initializes the controller with a cart repository
        public CartController(ICartRepository cartRepository)
        {
            this.repository = cartRepository;
        }

        // Shows the cart for the current user
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await repository.FetchCartUsingId(userId);
            return View("Cart", cart);
        }

        // Deletes an item from the cart
        public async Task<IActionResult> DeleteItem(int cartItemId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await repository.DeleteCart(cartItemId);
            return RedirectToAction("Index");
        }

        // Updates the quantity of a product in the cart
        public async Task<IActionResult> UpdateQuantity(int ProductId, string change, int quantity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (change == "increase")
            {
                await repository.ModifyCartDetails(userId, ProductId, 1);
            }
            else if (change == "decrease" && quantity > 0)
            {
                await repository.ModifyCartDetails(userId, ProductId, -1);
            }

            return RedirectToAction("Index"); // Refresh cart view
        }
    }
}
