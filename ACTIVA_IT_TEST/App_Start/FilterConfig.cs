﻿using System.Web;
using System.Web.Mvc;

namespace ACTIVA_IT_TEST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
