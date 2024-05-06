using Azure.Core;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using registrationform.Models.Helpers;
using registrationform.Models.Repository;
using RequestHeaders = Microsoft.AspNetCore.Http.Headers.RequestHeaders;

namespace registrationform.Models.Filters
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        private readonly IAuditRepository _auditRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditFilterAttribute(IAuditRepository auditRepository, IHttpContextAccessor httpContextAccessor)
        {
            _auditRepository = auditRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var objAudit = new AuditModel();
            var controllerName = ((ControllerBase)context.Controller)
                .ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller)
                .ControllerContext.ActionDescriptor.ActionName;
            var actionDescriptorRouteValues = ((ControllerBase)context.Controller)
                .ControllerContext.ActionDescriptor.RouteValues;
            if (actionDescriptorRouteValues.ContainsKey("area"))
            {

                var area = actionDescriptorRouteValues["area"];
                if (area == null)
                {
                    objAudit.Area = Convert.ToString(area);
                }

                var request = context.HttpContext.Request;

                if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.LangId))))
                {

                    objAudit.LangId = Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.LangId));
                }
                else
                {
                    objAudit.LangId = "";
                }

                if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.UserId))))
                {

                    objAudit.UserId = Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.UserId));
                }
                else
                {
                    objAudit.UserId = "";
                }
                if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.RoleId))))
                {

                    objAudit.RoleId = Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
                }
                else
                {
                    objAudit.RoleId = "";
                }
                if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.IsFirstLogin))))
                {

                    objAudit.IsFirstLogin = Convert.ToString(context.HttpContext.Session.GetInt32(AllSessionKeys.IsFirstLogin));
                }
                else
                {
                    objAudit.IsFirstLogin = "";
                }
                objAudit.SessionId = context.HttpContext.Session.Id;

                if (_httpContextAccessor.HttpContext != null)
                    objAudit.IpAddress = Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);

                objAudit.PageAccessed = Convert.ToString(context.HttpContext.Request.Path);

                objAudit.LoggedInStatus = "A";
                objAudit.ControllerName = controllerName;
                objAudit.ActionName = actionName;

                RequestHeaders headers = request.GetTypedHeaders();

                

                Uri uriReferer = headers.Referer;

                if (uriReferer != null)
                {
                    objAudit.UrlRefferer = headers.Referer.AbsoluteUri;
                }
                _auditRepository.InsertAuditLogs(objAudit);

            }
        }
    }
}

        
