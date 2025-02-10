using EUC.Models;

namespace EUC.Services
{
    public interface IQuestionnaireService
    {
        Task<string?> GetQuestionnaireJson(int id);
        Task<int?> InsertQuestionnaire(QuestionnaireModel input);
    }
}