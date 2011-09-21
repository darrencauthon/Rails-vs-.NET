using System.Collections.Generic;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Mappers;

namespace ProductDevelopment.Web.Models
{
    public class DefaultSearchResultsRetriever : IDefaultSearchResultsRetriever
    {
        private readonly IDefaultSearchResultViewModelMapper defaultSearchResultViewModelMapper;
        private readonly IRepository<Defect> defectRepository;

        public DefaultSearchResultsRetriever(IDefaultSearchResultViewModelMapper defaultSearchResultViewModelMapper,
                                             IRepository<Defect> defectRepository)
        {
            this.defaultSearchResultViewModelMapper = defaultSearchResultViewModelMapper;
            this.defectRepository = defectRepository;
        }

        public IEnumerable<DefectSearchResultsViewModel> GetSearchResults()
        {
            var defects = defectRepository.All();
            return defaultSearchResultViewModelMapper.CreateSet(defects);
        }
    }
}