using SafetyBP.Domain.Enums;
using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsCheckList
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public virtual ControlObjectsSurvey Survey { get; set; }
        public CheckListQuestionTypes Type { get; set; }
        public byte IsAlert { get; set; }
        public bool IsPhotoRequired { get; set; }
        public bool IsCritica { get; set; }
        public bool SkipCheck { get; set; }
        public IList<ControlObjectsCheckListNegativeValue> NegativeValues { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}
