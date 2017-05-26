using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web
{
    public class Questions : IQuestions
    {
        private static HttpClient client = new HttpClient();
        private readonly string APIEndPoint = ConfigurationManager.AppSettings.Get("QuestionnaireServiceUri");
        
        public async Task<QuestionnaireViewModel> GetQuestionsAsync()
        {
            QuestionnaireViewModel question = null;
            HttpResponseMessage response = client.GetAsync(APIEndPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                question = await response.Content.ReadAsAsync<QuestionnaireViewModel>();
            }
            return question;
        }
    }
}