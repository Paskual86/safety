using SafetyBP.Domain.Enums;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models
{
    public class SafetyCheckListQuestion 
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int RelatedId { get; set; }
        public CheckListQuestionTypes Type { get; set; }
        public bool IsAlert { get; set; }
        public bool PhotoRequired { get; set; }
        public bool IsCritica { get; set; }
        public IList<SafetyCheckListNegativeValue> NegativeValues { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsPendingToSyncronize { get; set; }
        public bool DoesNotApply { get; set; }
        public virtual ICollection<SafetyCheckListValueOption> ValueOptions { get; private set; }
        public virtual SafetyCheckListDetail CheckList { get; set; }
        
    }
}
