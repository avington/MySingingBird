using System.Collections.Generic;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.ViewModel
{
    public class SearchResultViewModel
    {
        public IList<SearchResponse> Results { get; set; }
    }
}