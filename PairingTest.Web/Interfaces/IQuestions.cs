using System.Threading.Tasks;
using PairingTest.Web.Models;

namespace PairingTest.Web.Interfaces
{
    public interface IQuestions
    {
        Task<QuestionnaireViewModel> GetQuestionsAsync();
    }
}