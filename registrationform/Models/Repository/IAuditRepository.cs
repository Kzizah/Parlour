namespace registrationform.Models.Repository

{
    public interface IAuditRepository
    {
        void InsertAuditLogs(AuditModel AuditModel);
    }
}
