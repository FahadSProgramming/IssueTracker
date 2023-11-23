using AutoMapper;

namespace IT.Application.Core {
    public class MappingProfile : Profile {
        public MappingProfile() {
        
        #region Customer Profiles
            CreateMap<Customer.Queries.CustomerDto, Domain.Customer>()
            .ForMember(p => p.Rating, x => x.MapFrom(x => x.Rating.GetHashCode()))
            .ReverseMap();
            CreateMap<Customer.Commands.CreateCustomerRequest, Domain.Customer>()
            .ForMember(p => p.Rating, x => x.MapFrom(x => x.Rating.GetHashCode()))
            .ReverseMap();
            CreateMap<Customer.Commands.UpdateCustomerRequest, Domain.Customer>()
            .ForMember(p => p.Rating, x => x.MapFrom(x => x.Rating.GetHashCode()))
            .ReverseMap();
        #endregion
        
        #region Category Profiles
            CreateMap<Domain.Category, Category.Commands.CreateCategoryRequest>().ReverseMap();
            CreateMap<Domain.Category, Category.Commands.UpdateCategoryRequest>().ReverseMap();
        #endregion

        #region SystemUser Profiles
            CreateMap<Domain.SystemUser, SystemUser.LoginUserRequest>().ReverseMap();
            CreateMap<Domain.SystemUser, SystemUser.LoginUserRequest>().ReverseMap();
        #endregion
        }
    }
}