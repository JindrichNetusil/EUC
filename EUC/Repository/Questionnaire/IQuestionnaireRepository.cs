using EUC.Models;

namespace EUC.Repository
{
    public interface IQuestionnaireRepository
    {
        Task<string?> GetQuestionnaireJson(int id);
        Task<int?> InsertQuestionnaire(Questionnaire input);
    }
}