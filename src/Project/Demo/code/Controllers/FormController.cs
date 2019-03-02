using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emotion.Foundation.LexisAnalysis.Services;
using Emotion.Project.Demo.Model;

namespace Emotion.Project.Demo.Controllers
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
            var serv = new XConnectService();
            var c = serv.GetCurrentContact();
            var m = new EmotionManager();
            m.FillEmotionFacet(model.Text);
            return View(model);
        }
    }
}