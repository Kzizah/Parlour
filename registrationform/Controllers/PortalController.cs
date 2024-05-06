using Microsoft.AspNetCore.Mvc;
using registrationform.Models;
using registrationform.Models.Helpers;
using registrationform.Models.Repository;
using System.Globalization;

namespace registrationform.Controllers
{
    public class PortalController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditRepository _auditRepository;
        private readonly string allsessionkeys;
      

        public PortalController(IHttpContextAccessor httpContextAccessor, IAuditRepository AuditRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _auditRepository = AuditRepository;
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        public IActionResult login(LoginViewModel loginViewModel)

        {
            if(loginViewModel.Name=="demoaudit" && loginViewModel.Password == "demoaudit")
            {
                HttpContext.Session.SetInt32(AllSessionKeys.UserId,1);
                HttpContext.Session.SetString(AllSessionKeys.Name,"demoaudit");
                HttpContext.Session.SetString(AllSessionKeys.IsFirstLogin, "N");
                HttpContext.Session.SetInt32(AllSessionKeys.RoleId, 1);
                HttpContext.Session.SetInt32(AllSessionKeys.LangId,1);
                AuditLogin();
                return RedirectToAction("Dashboard","Dashboard");
            }

            return View(loginViewModel);
        }
        private void AuditLogin()
        {
            var objAudit = new AuditModel();
            objAudit.RoleId=Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
            objAudit.ControllerName = "Portal";
            objAudit.ActionName = "Login";
            objAudit.Area = "";
            objAudit.LoggedInAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if(_httpContextAccessor.HttpContext!=null)
                objAudit.IpAddress=Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            objAudit.UserId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.UserId));
            objAudit.PageAccessed = "";
            objAudit.UrlRefferer = "";
            objAudit.SessionId = HttpContext.Session.Id;
            _auditRepository.InsertAuditLogs(objAudit);
        }

        private void AuditLogout()
        {
            var objAudit = new AuditModel();
            objAudit.RoleId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
            objAudit.ControllerName = "Portal";
            objAudit.ActionName = "Logout";
            objAudit.Area = "";
            objAudit.LoggedInAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if (_httpContextAccessor.HttpContext != null)
                objAudit.IpAddress = Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            objAudit.UserId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.UserId));
            objAudit.PageAccessed = "";
            objAudit.UrlRefferer = "";
            objAudit.SessionId = HttpContext.Session.Id;
            _auditRepository.InsertAuditLogs(objAudit);
        }

        public IActionResult logout()
        {
            try
                {
                HttpContext.Session.Clear();

                AuditLogout();
                return RedirectToAction("Login", "Portal");

            }
            catch(Exception)
                {
                throw;
            }
        }
    }
}
