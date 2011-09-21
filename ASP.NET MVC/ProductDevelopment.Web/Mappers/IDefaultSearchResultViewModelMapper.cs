using System.Collections.Generic;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Mappers
{
    public interface IDefaultSearchResultViewModelMapper
    {
        IEnumerable<DefectSearchResultsViewModel> CreateSet(IEnumerable<Defect> defects);
    }
}