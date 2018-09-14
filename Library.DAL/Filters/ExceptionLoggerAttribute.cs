using Library.DAL.Context;
using Library.Entities.Models;
using System;
using System.Web.Mvc;

namespace Library.DAL.Filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionDetail exceptionDetail = new ExceptionDetail()
            {
                ExceptionMessage = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };

            using (ApplicationContext db = new ApplicationContext())
            {
                db.ExceptionDetails.Add(exceptionDetail);
                db.SaveChanges();
            }

            filterContext.ExceptionHandled = true;
        }
    }
}
