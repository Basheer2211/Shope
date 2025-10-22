using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository.Class;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Classes
{
    public class CartServieces : ICartServices
    {
        public CartServieces(ICartRepository cartRepository)
        {
            CartRepository = cartRepository;
        }

        private readonly ICartRepository CartRepository; 

        public bool AddTocart(CartRequest request, string userId)
        {
            Cart NewItem = new Cart
            {
                UserId=userId,
                ProductId=request.ProductId,
                count=1,
            };
            return CartRepository.add(NewItem) >0;
        }

        public cartSymmaryResponse Getcart(string userId)
        {
            var cartItems= CartRepository.GetUserCart(userId);
            var response = new cartSymmaryResponse
            {
                items = cartItems.Select(c1 => new CartResponse
                {
                    ProductId = c1.ProductId,
                    Name = c1.product.Name,
                    count = c1.count,
                    Price = c1.product.Price,

                }
                ).ToList()
            };
            return response;
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            return await CartRepository.ClearCart(userId);
        }
    }
}
