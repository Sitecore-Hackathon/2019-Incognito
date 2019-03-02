using System.Web.Mvc;
using Emotion.Feature.Rules.Model;
using Emotion.Foundation.LexisAnalysis.Services;

namespace Emotion.Feature.Controls.Controllers
{
    /// <summary>
    /// Controller that demonstrate usage of API for 
    /// </summary>
    public class FormController : Controller
    {
        public ActionResult Feedback()
        {
            var model = new Feedback();
            return View(model);
        }

        /// <summary>
        /// Simple form that process text data and get emotions as outcome
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Feedback(Feedback model)
        {
            if (!string.IsNullOrEmpty(model.Text))
            {
                var m = new EmotionManager();
                m.FillEmotionFacet(model.Text);
            }

            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }
    }
}