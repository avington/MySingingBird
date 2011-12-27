using System.Collections.Generic;
using MySingingBird.Core.Entities;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Services
{
    public interface IAnalyzeStatusesService
    {
        TwitterStatusViewModel Anylize(IList<TwitterStatusItem> response);
    }
}