using System;

namespace Unlockd.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public long? Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
    }
}
