using AutoMapper;
using EUC.Models;

namespace EUC.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Questionnaire, QuestionnaireModel>().ReverseMap();
        }
    }
}