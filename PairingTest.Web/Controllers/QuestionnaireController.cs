using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestions _questions;

        public QuestionnaireController(IQuestions questions)
        {
            _questions = questions;
        }

        public QuestionnaireController() : this(new Questions())
        {
        }

        public ViewResult Index()
        {
            QuestionnaireViewModel questionnaire = _questions.GetQuestionsAsync().Result;

            return View(questionnaire);
        }
    }
}
