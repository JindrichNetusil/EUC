using AutoMapper;
using EUC.Models;
using EUC.Repository;

namespace EUC.Services
{
    public class QuestionnaireService(IQuestionnaireRepository repository, IMapper mapper) : IQuestionnaireService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQuestionnaireRepository _repository = repository;

        public async Task<int?> InsertQuestionnaire(QuestionnaireModel input)
        {
            if (IsQuestionnaireModelValid(input))
            {
                Questionnaire questionnaire = _mapper.Map<Questionnaire>(input);

                int? id = await _repository.InsertQuestionnaire(questionnaire);
                questionnaire.Id = id;

                return questionnaire.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<string?> GetQuestionnaireJson(int id)
        {
            return await _repository.GetQuestionnaireJson(id);
        }

        public static bool IsQuestionnaireModelValid(QuestionnaireModel model)
        {
            return ValidationService.IsQuestionnaireModelValid(model);
        }
    }
}