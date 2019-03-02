using System.Web.Mvc;
using Emotion.Feature.Rules.Model;
using Emotion.Foundation.LexisAnalysis.Services;

namespace Emotion.Feature.Controls.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Feedback()
        {
            var model = new Feedback();
            return View(model);
        }

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