using System;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models
{
    public class SafetyTaskDetails
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public byte Priority { get; set; }
        public bool IsComplete { get; set; }
        public string Url { get; set; }
        public string Files { get; set; }
        public virtual ICollection<SafetyTaskCheckList> CheckList { get; set; }
        public virtual SafetyTask Task { get; set; }
    }
}
