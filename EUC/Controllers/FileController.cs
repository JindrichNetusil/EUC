using EUC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EUC.Controllers
{
    [Route("api/download")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public FileController(IQuestionnaireService questionnaireService)
        {
            QuestionnaireService = questionnaireService;
        }

        IQuestionnaireService QuestionnaireService { get; set; }

        [HttpGet("file/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                var filePath = Path.Combine("wwwroot/files", fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

                return File(fileBytes, "application/octet-stream", fileName);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("questionnaire/{questionnaireId}")]
        public async Task<IActionResult> GetQuestionnaireJsonData([FromRoute] int questionnaireId)
        {
            var json = await QuestionnaireService.GetQuestionnaireJson(questionnaireId);

            if (json != null)
            {
                var bytes = Encoding.UTF8.GetBytes(json);
                var stream = new MemoryStream(bytes);

                return File(stream, "application/json", "questionnaire.json");
            }
            else
            {
                return NotFound();
            }
        }
    }
}