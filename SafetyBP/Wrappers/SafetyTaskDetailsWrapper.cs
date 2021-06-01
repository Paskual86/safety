using SafetyBP.Domain.Models;
using System.Collections.Generic;

namespace SafetyBP.Wrappers
{
    public class SafetyTaskDetailsWrapper : ModelWrapper<SafetyTaskDetails>
    {
        public SafetyTaskDetailsWrapper(SafetyTaskDetails model) : base(model)
        {

        }

        public ICollection<SafetyTaskCheckList> CheckList
        {
            get { return GetValue<ICollection<SafetyTaskCheckList>>(); }
            set { SetValue(value); }
        }
    }
}
