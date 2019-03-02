using System.Web.Mvc;

namespace Emotion.Feature.Controls.Controllers
{
    /// <summary>
    /// Controller with demo controls to have ability to show personalization
    /// </summary>
    public class CardController : Controller
    {
        /// <summary>
        /// Image banner
        /// </summary>
        /// <returns></returns>
        public ActionResult ImageBanner()
        {
            return View();
        }

        /// <summary>
        /// Text banner
        /// </summary>
        /// <returns></returns>
        public ActionResult TextBanner()
        {
            return View();
        }
    }
}