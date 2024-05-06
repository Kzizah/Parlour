﻿using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class AuditModel
    {
        [Key]
        public string AuditId { get; set; }

        public string Area { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RoleId { get; set; }

        public string LangId { get; set; }

        public string IpAddress { get; set; }

        public string IsFirstLogin { get; set; }

        public string LoggedInAt { get; set; }

        public string LoggedOutAt { get; set; }

        public string LoggedInStatus { get; set; }

        public string PageAccessed { get; set; }
        public string SessionId { get; set; }
        public string UrlRefferer { get; set; }

        public string UserId { get; set; }
    }
}
