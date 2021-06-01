using SafetyBP.Domain.Enums;

namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsQuestion
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public virtual ControlObjectsSurvey Survey { get; set; }
        public CheckListQuestionTypes Type { get; set; }
        public byte IsAlert { get; set; }
        public byte IsPhotoRequired { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}
