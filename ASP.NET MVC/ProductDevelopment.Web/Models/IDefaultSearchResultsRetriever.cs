using System.Collections.Generic;

namespace ProductDevelopment.Web.Models
{
    public interface IDefaultSearchResultsRetriever
    {
        IEnumerable<DefectSearchResultsViewModel> GetSearchResults();
    }
}