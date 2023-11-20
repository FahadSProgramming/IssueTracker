using AutoMapper;
using IT.Application.Category;

namespace IT.Application.Core {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Domain.Category, Category.Commands.CreateCategory>().ReverseMap();
        }
    }
}