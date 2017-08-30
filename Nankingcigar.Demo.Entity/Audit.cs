namespace Nankingcigar.Demo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Audit")]
    public partial class Audit
    {
        public long Id { get; set; }

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

        public virtual User User1 { get; set; }
    }
}
