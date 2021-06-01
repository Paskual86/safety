using System;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models
{
    public class SafetyCheckListDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDateTime { get; set; }
        public ICollection<SafetyCheckListQuestion> Questions { get; set; }
        public virtual SafetyCheckList CheckList { get; set; }
        public bool IsPendingToSyncronize { get; set; }
        public bool Complete { get; set; }
    }
}
