using SafetyBP.Domain.Interfaces;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models
{
    public class SafetyTask : IBaseEntity
    {
        public int Id { get; set; }
        public string Sector { get; set; }
        public ICollection<SafetyTaskDetails> Details { get; set; }
        public bool PendingToSynchronize { get; set; }
        public virtual SafetyTaskAdditionalData AdditionalData { get; set; }
    }
}
