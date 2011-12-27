using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Services
{
    public interface ITwitterStatusService
    {
        TwitterStatusViewModel GetStatus(string userName);
    }
}