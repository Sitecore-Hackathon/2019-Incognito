using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Emotion.Foundation.LexisAnalysis.Mapping;
using Sitecore.Pipelines;

namespace Emotion.Project.Demo.Pipelines.Initialize
{
    public class BundleConfig
    {
        public void Process(PipelineArgs args)
        {
            var bundles = new BundleCollection();
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}