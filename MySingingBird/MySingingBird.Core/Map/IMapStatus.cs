using System.Collections.Generic;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Map
{
    public interface IMapStatus
    {
        IList<TwitterStatusItem> Map(string jsonResponse);
    }
}