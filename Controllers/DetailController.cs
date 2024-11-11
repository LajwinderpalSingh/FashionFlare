using FashionFlare.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FashionFlare.Controllers
{
    // Manages product details and cart operations
    public class DetailController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        // Initializes the controller with product and cart repositories
        public DetailController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        // Shows the detail view for a specific product
        public async Task<IActionResult> Index(int productId)
        {
            var product = await productRepository.FetchById(productId);
            return View("Detail", product);
        }

        // Adds a product to the user's cart and redirects to the cart view
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.ModifyCartDetails(userId, productId, quantity);
            return RedirectToAction("Index", "Cart");
        }
    }
}
