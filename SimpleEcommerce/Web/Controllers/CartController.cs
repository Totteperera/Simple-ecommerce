using SimpleEcommerce.BL.Constants;
using SimpleEcommerce.BL.Services;
using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly OrderRowService _orderRowService;
        public CartController()
        {
            _productService = new ProductService();
            _cartService = new CartService();
            _orderRowService = new OrderRowService();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string id)
        {
            if(string.IsNullOrEmpty(id) ||
                !int.TryParse(id, out var productId) ||
                !ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cartSessionId = GetCartCookieSessionId();
            var product = _productService.Get(productId);
            var cart = _cartService.Get(cartSessionId);

            if(cart == null)
            {
                cart = new Cart
                {
                    SessionId = cartSessionId
                };

                _cartService.Create(cart);
            }
            
            
            var orderRow = _orderRowService.GetFromCartId(cart.ID)?.FirstOrDefault(x => x.ProductID.Equals(productId));

            if(orderRow == null)
            {
                orderRow = new OrderRow
                {
                    CartID = cart.ID,
                    ProductID = product.ID,
                    Quantity = 1
                };
                _orderRowService.Create(orderRow);
            }
            else
            {
                _orderRowService.AddOne(orderRow);
            }
            var viewModel = _cartService.GetViewModel(cartSessionId);
            return PartialView("_cart", viewModel);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var cartSessionId = GetCartCookieSessionId();
            var viewModel = _cartService.GetViewModel(cartSessionId);

            return PartialView("_cart", viewModel);
        }

        private Guid GetCartCookieSessionId()
        {
            var cookie = Request.Cookies[SimpleEcommerceConstants.CartCookieSessionKey];
            if(cookie == null)
            {
                cookie = SetCartCookieSessionId();
            }

            return Guid.Parse(cookie.Value);
        }

        private HttpCookie SetCartCookieSessionId()
        {
            var cookie = new HttpCookie(SimpleEcommerceConstants.CartCookieSessionKey)
            {
                Value = Guid.NewGuid().ToString(),
                Expires = DateTime.Now.AddDays(30)
            };
            Response.SetCookie(cookie);
            Response.Flush();
            return cookie;
        }
    }
}