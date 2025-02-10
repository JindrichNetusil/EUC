using System.ComponentModel.DataAnnotations;
using static EUC.Models.QuestionnaireEnums;

namespace EUC.Models
{
    public class QuestionnaireModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthNumber { get; set; } = string.Empty;
        public bool HasNoBirthNumber { get; set; } = false;
        public DateTime? Birthday { get; set; } = null;
        public Sex? Sex { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public Nationality? Nationality { get; set; } = null;
        public bool DidAcceptGdpr { get; set; } = false;
    }
}