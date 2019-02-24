using System.Web.Mvc;

namespace CampaignForProduct.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();            
        }
    }
}