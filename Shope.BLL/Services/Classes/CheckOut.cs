using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Repository.Interface;
using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shope.DAL.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Shope.BLL.Services.Classes
{
    public class CheckOut : ICheckOut
    {
        public CheckOut(ICartRepository cartServices,IorderRepository order,  IEmailSender emailSender,IOrderItemRepository orderItem, IproductRepository iproductRepository)
        {
            CartServices = cartServices;
            this.order = order;
            this.emailSender = emailSender;
            this.orderItem = orderItem;
            this.iproductRepository = iproductRepository;
        }

        private readonly ICartRepository CartServices;
        private readonly IorderRepository order;
        private readonly IEmailSender emailSender;
        private readonly IOrderItemRepository orderItem;
        private readonly IproductRepository iproductRepository;

        public async Task<CheckOutResponse> ProcessPayment(CheckOutRequest request,String userId, HttpRequest Request)
        {
            if (iproductRepository is null)
            {
                throw new ArgumentNullException(nameof(iproductRepository));
            }

            var cartItem = CartServices.GetUserCart(userId);
            if (! cartItem.Any())
            {
                return new CheckOutResponse
                {
                    success = false,
                    message = "cart is empty"
                };
            }
            Order order1 = new Order
            {
                UserId = userId,
                paymentMethode=request.paymentmethode,
                TotalAmount=cartItem.Sum(c=>c.count*c.product.Price)
            };
            await order.addasync(order1);
            if (request.paymentmethode==PaymentMethode.cash)
            {
                return new CheckOutResponse
                {
                    success = true,
                    message = "c y"
                };
            }
            if (request.paymentmethode == PaymentMethode.visa)
            {
                order1.status = OrderStatus.Approved;
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
            {
               
            },
                    Mode = "payment",
                    SuccessUrl = $"{Request.Scheme}://{Request.Host}/api/customer/CheckOut/success/{order1.id}",
                    CancelUrl = $"{Request.Scheme}://{Request.Host}/api/customer/CheckOut/cancel",
                };
                foreach (var item in cartItem)
                {
                    options.LineItems.Add(
                         new SessionLineItemOptions
                         {
                             PriceData = new SessionLineItemPriceDataOptions
                             {
                                 Currency = "USD",
                                 ProductData = new SessionLineItemPriceDataProductDataOptions
                                 {
                                     Name = item.product.Name,
                                     Description = item.product.Description,
                                 },
                                 UnitAmount =(long) item.product.Price,
                             },
                             Quantity = 1,
                         }
                         );
                }
                var service = new SessionService();
                var session = service.Create(options);
                order1.PaymentId = session.Id;
                return new CheckOutResponse
                {
                    success=true,
                    message="paymet session created successfully",
                    url=session.Url,
                    paymentId=session.Id

                };
            }
            return new CheckOutResponse
            {
                success = false,
                message = "invalid"
            };
        }

        public async Task<bool> HandleSuccessPaymentasync(int orderId)
        {
            var Order = await order.getUserById(orderId);
            string subject="";
            string body = "";
            if (Order.paymentMethode== PaymentMethode.visa)
            {
                Order.status = OrderStatus.Approved;
                var carts = CartServices.GetUserCart(Order.UserId);
                List<OrderItem> list = new List<OrderItem>();
                Dictionary<int, int> map = new Dictionary<int, int>();
                foreach (var item in carts)
                {
                    var orderItem1 = new OrderItem
                    {
                        OrderId= orderId,
                        PrductId=item.ProductId,
                        totalPrice=item.count*item.product.Price
                    };
                    list.Add(orderItem1);
                    map.Add(item.ProductId, item.count);
                    
                }
                  await orderItem.AddAsync(list);
                await iproductRepository.DecreaseQuantityAsync(map);
                await CartServices.ClearCart(Order.UserId);
                subject = "Payment successfully";
                body = $"<h2>{Order.TotalAmount}</h2>";
            }
            else if (Order.paymentMethode == PaymentMethode.cash)
            {
                subject = "order  successfully";
                body = $"<h2>{Order.TotalAmount}</h2>";
            }
            await emailSender.SendEmailAsync(Order.User.Email, subject, body);
            return true;
        }

    }
}
