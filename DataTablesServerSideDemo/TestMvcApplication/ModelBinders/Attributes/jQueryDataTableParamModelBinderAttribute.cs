using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcApplication.ModelBinders.Attributes
{
    public class jQueryDataTableParamModelBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new jQueryDataTableParamModelBinder();
        }
    }
}