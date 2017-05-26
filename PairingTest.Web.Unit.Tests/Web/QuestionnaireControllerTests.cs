using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            const string expectedTitle = "My expected questions";
            List<string> expectedText = new List<string>()
            {
                "Hello world", "foobar"
            };

            Mock<IQuestions> fakeQuestionsMock = new Mock<IQuestions>();

            fakeQuestionsMock.Setup(quest => quest.GetQuestionsAsync())
                .Returns(Task.FromResult(new QuestionnaireViewModel()
                {
                    QuestionnaireTitle = expectedTitle,
                    QuestionsText = expectedText
                }));

            QuestionnaireController questionsController = new QuestionnaireController(fakeQuestionsMock.Object);

            //Act
            QuestionnaireViewModel result = (QuestionnaireViewModel)questionsController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(result.QuestionsText[0], Is.EqualTo(expectedText[0]));
            Assert.That(result.QuestionsText[1], Is.EqualTo(expectedText[1]));
        }
    }
}