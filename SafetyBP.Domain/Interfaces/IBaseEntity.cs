namespace SafetyBP.Domain.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string Sector { get; set; }
        bool PendingToSynchronize { get; set; }
    }
}
