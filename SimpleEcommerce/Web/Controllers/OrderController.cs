using SimpleEcommerce.BL.Constants;
using SimpleEcommerce.BL.Mappers;
using SimpleEcommerce.BL.Services;
using SimpleEcommerce.DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly CartService _cartService;
        private readonly OrderService _orderService;
        public OrderController()
        {
            _cartService = new CartService();
            _orderService = new OrderService();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder()
        {
            var sessionId = GetSessionIdCookie();

            if (!ModelState.IsValid || sessionId.Equals(Guid.Empty))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _cartService.CreateOrderModelFromCart(sessionId);

            _orderService.PlaceOrder(order);
            _cartService.Clear(sessionId);

            return RedirectToAction("OrderConfirmation",
                new RouteValueDictionary( new { controller = "Order", action = "OrderConfirmation", id = order.ID }) );

        }

        public ActionResult OrderConfirmation(int id)
        {
            var viewModel = _orderService.GetViewModel(id);
            return View(viewModel);
        }

        private Guid GetSessionIdCookie()
        {
            var cookie = Request.Cookies[SimpleEcommerceConstants.CartCookieSessionKey];
            return cookie != null ? Guid.Parse(cookie.Value) : Guid.Empty;
        }
    }
}