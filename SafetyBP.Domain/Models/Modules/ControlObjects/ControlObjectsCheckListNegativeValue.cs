namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsCheckListNegativeValue
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public string Value { get; set; }
        public int ValueType { get; set; }
        public virtual ControlObjectsCheckList CheckLists { get; set; }
    }
}
