using System.Web.Mvc;
using SimpleEcommerce.BL.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        public HomeController()
        {
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            var viewModel = _productService.GetAll();
            return View(viewModel);
        }
    }
}