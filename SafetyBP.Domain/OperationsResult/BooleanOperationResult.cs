namespace SafetyBP.Domain.OperationsResult
{
    public interface IOperationResult 
    {
        bool Result { get; set; }
        string Message { get; set; }
    }

    public class BooleanOperationResult : IOperationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
