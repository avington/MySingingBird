using System.Collections.Generic;
using MySingingBird.Core.Entities;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Services
{
    public interface ITwitterSearchService
    {
        IList<SearchResponse> Search(SearchRequest search);
        TwitterSearchViewModel Initialize();
        IList<SearchResponse> GoSearch(TwitterSearchViewModel request);
    }
}