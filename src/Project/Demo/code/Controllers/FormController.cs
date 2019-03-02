using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}