using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity
{
    [Table("AuditLog")]
    public class AuditLog : Entity<long>
    {
        public long? UserId { get; set; }

        [StringLength(256)]
        public string ServiceName { get; set; }

        [StringLength(256)]
        public string MethodName { get; set; }

        [StringLength(1024)]
        public string Parameters { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExecutionTime { get; set; }

        public int? ExecutionDuration { get; set; }

        [StringLength(64)]
        public string ClientIpAddress { get; set; }

        [StringLength(128)]
        public string ClientName { get; set; }

        [StringLength(256)]
        public string BrowserInfo { get; set; }

        [StringLength(2000)]
        public string Exception { get; set; }

        public long? ImpersonatorUserId { get; set; }

        [StringLength(2000)]
        public string CustomData { get; set; }

        public virtual User User { get; set; }

        public virtual User Impersonator { get; set; }

        public static AuditLog CreateFromAuditInfo(AuditInfo auditInfo)
        {
            var exceptionMessage = auditInfo.Exception?.ToString();
            return new AuditLog
            {
                UserId = auditInfo.UserId,
                ServiceName = auditInfo.ServiceName.TruncateWithPostfix(256),
                MethodName = auditInfo.MethodName.TruncateWithPostfix(256),
                Parameters = auditInfo.Parameters.TruncateWithPostfix(1024),
                ExecutionTime = auditInfo.ExecutionTime,
                ExecutionDuration = auditInfo.ExecutionDuration,
                ClientIpAddress = auditInfo.ClientIpAddress.TruncateWithPostfix(64),
                ClientName = auditInfo.ClientName.TruncateWithPostfix(128),
                BrowserInfo = auditInfo.BrowserInfo.TruncateWithPostfix(256),
                Exception = exceptionMessage.TruncateWithPostfix(2000),
                ImpersonatorUserId = auditInfo.ImpersonatorUserId,
                CustomData = auditInfo.CustomData.TruncateWithPostfix(2000)
            };
        }

        public override string ToString()
        {
            return $"AUDIT LOG: {ServiceName}.{MethodName} is executed by user {UserId} in {ExecutionDuration} ms from {ClientIpAddress} IP address.";
        }
    }
}