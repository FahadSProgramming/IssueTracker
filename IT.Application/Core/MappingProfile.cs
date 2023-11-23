using AutoMapper;

namespace IT.Application.Core {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<IT.Application.Customer.Queries.CustomerDto, Domain.Customer>()
            .ForMember(p => p.Rating, x => x.MapFrom(x => x.Rating.GetHashCode()))
            .ReverseMap();
            CreateMap<Customer.Commands.CreateCustomerRequest, Domain.Customer>()
            .ForMember(p => p.Rating, x => x.MapFrom(x => x.Rating.GetHashCode())).ReverseMap();
            CreateMap<Domain.Category, Category.Commands.CreateCategoryRequest>().ReverseMap();
            CreateMap<Domain.Category, Category.Commands.UpdateCategoryRequest>().ReverseMap();
            CreateMap<Domain.SystemUser, SystemUser.LoginUserRequest>().ReverseMap();
            CreateMap<Domain.SystemUser, SystemUser.LoginUserRequest>().ReverseMap();
        }
    }
}