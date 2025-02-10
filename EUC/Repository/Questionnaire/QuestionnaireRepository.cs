using EUC.Configuration;
using EUC.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EUC.Repository
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        public QuestionnaireRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private readonly ApplicationDbContext _context;

        public async Task<string?> GetQuestionnaireJson(int id)
        {
            Questionnaire? questionnaire = await _context.Questionnaires.FirstOrDefaultAsync(q => q.Id == id);

            if (questionnaire != null)
            {
                return JsonSerializer.Serialize(questionnaire);
            }

            return null;
        }

        public async Task<int?> InsertQuestionnaire(Questionnaire input)
        {
            await _context.AddAsync(input);
            await _context.SaveChangesAsync();

            return input.Id;
        }
    }
}