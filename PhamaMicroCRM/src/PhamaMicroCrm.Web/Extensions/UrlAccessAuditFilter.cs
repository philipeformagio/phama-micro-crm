using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using PhamaMicroCrm.Data.Interfaces;
using System;

namespace PhamaMicroCrm.Web.Extensions
{
    public class UrlAccessAuditFilter : IActionFilter
    {
        private readonly ILogRepository _logRepository;

        public UrlAccessAuditFilter(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string logText = $"Usuário {context.HttpContext.User.Identity.Name} accessou a URL {context.HttpContext.Request.GetDisplayUrl()} as {DateTime.Now.ToString()}";
                _logRepository.Add(new Model.Entities.Log { Text = logText, Type = "UrlAccessAudit" });
                _logRepository.SaveChanges();
            }
        }
    }
}
