using AutoMapperAssist;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Mappers
{
    public class DefaultSearchResultViewModelMapper : Mapper<Defect, DefectSearchResultsViewModel>
    {
        public override void DefineMap(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Defect, DefectSearchResultsViewModel>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(orig => orig.CreatorUser.Username))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(orig => orig.AssignedToUser.Username));
        }
    }
}