using Dapper;
using System.Data.SqlClient;

namespace registrationform.Models.Repository
{
    public class AuditRepository
    {
        private readonly IConfiguration _configuration;

        public AuditRepository(IConfiguration _configuration)
        {
            _configuration =  _configuration;

        }
        public void InsertAuditLogs(AuditModel auditModel)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBContextConnection"));
            try
            {
                con.Open();
                var para = new DynamicParameters();
                para.Add("@UserId", auditModel.UserId);
                para.Add("@IPAddress", auditModel.IpAddress);
                para.Add("@PageAccessed", auditModel.PageAccessed);
                para.Add("@LoggedInAt", auditModel.LoggedInAt);
                para.Add("@LoggedOutAt", auditModel.LoggedOutAt);
                para.Add("@LoginStatus", auditModel.LoggedInStatus);
                para.Add("@ControllerName", auditModel.ControllerName);
                para.Add("@ActionName", auditModel.ActionName);
                para.Add("@UrlRefferer", auditModel.UrlRefferer);
                para.Add("@Area", auditModel.Area);
                para.Add("@RoleId", auditModel.RoleId);
                para.Add("@LangId", auditModel.LangId);
                para.Add("@IsFirstLogin", auditModel.IsFirstLogin);

                con.Execute("Usp_InsertAuditsLogs", para, null,0,System.Data.CommandType.StoredProcedure);


                
            }
            catch (Exception ) {

                throw;
            }
           
        }
    }
}
