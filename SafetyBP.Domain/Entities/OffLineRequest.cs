namespace SafetyBP.Domain.Entities
{
    public class OffLineRequest
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Request { get; set; }
        public string Url { get; set; }
        public int RequestId { get; set; }
        public int OperationId { get; set; }
        public short OrderId { get; set; }
    }
}
