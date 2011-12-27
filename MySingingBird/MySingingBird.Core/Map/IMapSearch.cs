using System.Collections.Generic;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Map
{
    public interface IMapSearch
    {
        IList<SearchResponse> Map(string jsonResponse);
    }
}