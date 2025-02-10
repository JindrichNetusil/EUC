using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static EUC.Models.QuestionnaireEnums;

namespace EUC.Models
{
    [Table("Questionnaire")]
    public class Questionnaire
    {
        public int? Id { get; set; }
        [MaxLength(255)]
        public required string FirstName { get; set; } = string.Empty;
        [MaxLength(255)]
        public required string LastName { get; set; } = string.Empty;
        public required bool HasNoBirthNumber { get; set; }
        [MaxLength(255)]
        public string? BirthNumber { get; set; } = string.Empty;
        public required DateTime Birthday { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Sex Sex { get; set; }
        [MaxLength(255)]
        public required string Email { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Nationality Nationality { get; set; }
    }
}