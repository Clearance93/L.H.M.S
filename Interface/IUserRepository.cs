namespace ClinicalApp.Interface
{
    public interface IUserRepository
    {
        string GetUserId();
        bool IsAuthenticated();
    }
} 