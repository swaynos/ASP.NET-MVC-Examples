using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication.Models;

namespace TestMvcApplication.ModelBinders
{
    /// <summary>
    /// The model binder building up the jQueryDataTableParamModel to handle particular data in the Request
    /// </summary>
    public class jQueryDataTableParamModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // The main purpose of this model binder is to populate aaSortingCols
            string baseSortColIndex = "iSortCol_";
            string baseSortDirIndex = "sSortDir_";
            jQueryDataTableParamModel model = base.BindModel(controllerContext, bindingContext) as jQueryDataTableParamModel;
            List<int[]> sortingCols = new List<int[]>();
            for (int i = 0; i < model.iSortingCols; i++)
            {
                string sortingColumnString = bindingContext.ValueProvider.GetValue(baseSortColIndex + i.ToString()).AttemptedValue;
                string sortingDirectionString = bindingContext.ValueProvider.GetValue(baseSortDirIndex + i.ToString()).AttemptedValue;
                int sortingColumn = System.Convert.ToInt32(sortingColumnString);
                int sortingDirection = sortingDirectionString.Equals("asc") ? 1 : 0;
                sortingCols.Add(new int[] {
                   sortingColumn, 
                   sortingDirection
                });
            }
            model.aaSortingCols = sortingCols.ToArray();
            return model;
        }
    }
}