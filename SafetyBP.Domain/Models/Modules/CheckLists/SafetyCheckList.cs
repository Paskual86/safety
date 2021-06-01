using SafetyBP.Domain.Interfaces;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models
{
    public class SafetyCheckList : IBaseEntity
    {
        public int Id { get; set; }
        public string Sector { get; set; }
        public ICollection<SafetyCheckListDetail> Details { get; set; }
        public bool PendingToSynchronize { get; set; }
    }
}
