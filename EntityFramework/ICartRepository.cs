﻿using FashionFlare.Models;

namespace FashionFlare.EntityFramework
{
    public interface ICartRepository
    {
        Task<Cart> FetchCartUsingId(string userId);
        Task DeleteCart(int cartItemId);
        Task ModifyCartDetails(string userId, int productId, int quantity);
        Task CLearCart(string userId);
    }
}
