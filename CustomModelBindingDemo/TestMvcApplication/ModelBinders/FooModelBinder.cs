using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication.Models;

namespace TestMvcApplication.ModelBinders
{
    /// <summary>
    /// The model binder building up the FooModel. This model binder will handle the following for us:
    /// * Populating nested lookup types based on their reference.
    /// * Server side validation of our business rules.
    /// </summary>
    public class FooModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// Binds the model by using the specified controller context and binding context.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns>The model</returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Let's apply the default model binder before doing anything else.
            FooModel model = base.BindModel(controllerContext, bindingContext) as FooModel;

            // Let's lookup our Wonder
            model.Wonder = DataAccess.DummyDataAccess.GetWonders().Single(t => t.Id.Equals(model.Wonder.Id));

            // Let's enforce a business rules.
            // Rule: The start date must be before the end date
            // Ideally, property names should not be hard coded like this.
            bool areDatesNull = controllerContext.HttpContext.Request.Form["TravelStartDate"] == null || controllerContext.HttpContext.Request.Form["TravelEndDate"] == null;
            if (!areDatesNull && model.TravelStartDate > model.TravelEndDate)
            {
                bindingContext.ModelState.AddModelError("TravelStartDate", "The Starting Date of Travel cannot fall before the Ending Date of Travel.");
            }
            // Rule: If the travel dates fall outside of when the Wonder was completed, this model is invalid
            if (!areDatesNull && model.TravelStartDate < model.Wonder.DateFinished && model.TravelEndDate < model.Wonder.DateFinished)
            {
                bindingContext.ModelState.AddModelError("Wonder", "Travel could not have occured for this wonder on those dates.");
            }

            return model;
        }
    }
}