using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AdvisorController : Controller
    {
        // GET: Advisor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Question(int id = 1)
        {
            Question qn = new Question();

            QuestionViewModel qvm = new QuestionViewModel();

            qn = GenerateQuestion(id);

            qvm.NumberOfQuestions = 3;

            qvm.Question = qn;

            return View(qvm);
        }

        public ActionResult SaveData(QuestionViewModel qvm, string direction)
        {
            if(Session["Answers"] == null)
            {
                Dictionary<string, string> answers = new Dictionary<string, string>();
                answers[qvm.Question.QuestionNumber.ToString()] = qvm.SelectedAnswer;

                Session["Answers"] = answers;
            }
            else
            {
                Dictionary<string, string> sessionAnswers = (Dictionary<string, string>)Session["Answers"];

                sessionAnswers[qvm.Question.QuestionNumber.ToString()] = qvm.SelectedAnswer;

                Session["Answers"] = sessionAnswers;
            }

            if (direction == "Next")
                return RedirectToAction("Question", new { id = qvm.Question.QuestionNumber + 1 });

            return RedirectToAction("Submit");
        }

        public Question GenerateQuestion(int questionNumber)
        {
            Question qn = new Question();
            List<Option> options = new List<Option>();

            switch (questionNumber)
            {
                case 1:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What is the status of your existing checking account?";

                    options.Add(new Option { OptionText = "Amount < 0", OptionValue = "A11" });
                    options.Add(new Option { OptionText = "0 < Amount < 200,000", OptionValue = "A12" });
                    options.Add(new Option { OptionText = "Amount >= 200,000", OptionValue = "A13" });
                    options.Add(new Option { OptionText = "No Checking Account", OptionValue = "A14" });

                    qn.Options = options;

                    break;
                case 2:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What is your Credit History?";

                    options.Add(new Option { OptionText = "No credits taken/ all credits paid back duly", OptionValue = "A30" });
                    options.Add(new Option { OptionText = "All credits at this bank paid back duly", OptionValue = "A31" });
                    options.Add(new Option { OptionText = "Existing credits paid back duly till now", OptionValue = "A32" });
                    options.Add(new Option { OptionText = "Delay in paying off in the past", OptionValue = "A33" });
                    options.Add(new Option { OptionText = "Critical account/ other credits existing", OptionValue = "A34" });

                    qn.Options = options;

                    break;

                case 3:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What is the status of your savings account?";

                    options.Add(new Option { OptionText = "Amount < 100,000", OptionValue = "A61" });
                    options.Add(new Option { OptionText = "100,000 < Amount < 500,000", OptionValue = "A62" });
                    options.Add(new Option { OptionText = "500,000 < Amount < 1,000,000", OptionValue = "A63" });
                    options.Add(new Option { OptionText = "Amount > 1,000,000", OptionValue = "A64" });
                    options.Add(new Option { OptionText = "Unknown/No Savings Account", OptionValue = "A65" });

                    qn.Options = options;

                    break;
                case 4:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "For how long have you been working with your current employer?";

                    options.Add(new Option { OptionText = "I'm currently unemployed", OptionValue = "A71" });
                    options.Add(new Option { OptionText = "Duration < 1 year", OptionValue = "A72" });
                    options.Add(new Option { OptionText = "1 year < Duration < 4 years", OptionValue = "A73" });
                    options.Add(new Option { OptionText = "4 years < Duration < 7 years", OptionValue = "A74" });
                    options.Add(new Option { OptionText = "Duration > 7 years", OptionValue = "A75" });

                    qn.Options = options;

                    break;
                case 6:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What is your personal status and sex?";

                    options.Add(new Option { OptionText = "Male: Divorced/Separated", OptionValue = "A91" });
                    options.Add(new Option { OptionText = "Female: Divorced/Separated/Married", OptionValue = "A92" });
                    options.Add(new Option { OptionText = "Male: Single", OptionValue = "A93" });
                    options.Add(new Option { OptionText = "Male: Married/Widowed", OptionValue = "A94" });
                    options.Add(new Option { OptionText = "Female: Single", OptionValue = "A95" });

                    qn.Options = options;

                    break;
                case 7:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What kind of property do you own?";

                    options.Add(new Option { OptionText = "Real Estate", OptionValue = "A121" });
                    options.Add(new Option { OptionText = "Building Society Savings Agreement/Life Insurance", OptionValue = "A122" });
                    options.Add(new Option { OptionText = "Car or Other", OptionValue = "A123" });
                    options.Add(new Option { OptionText = "Unknown/No Property", OptionValue = "A124" });


                    qn.Options = options;

                    break;
                case 8:
                    qn.QuestionNumber = questionNumber;
                    qn.QuestionText = "What is your age?";

                    options.Add(new Option { OptionText = "Real Estate", OptionValue = "A121" });
                    options.Add(new Option { OptionText = "Building Society Savings Agreement/Life Insurance", OptionValue = "A122" });
                    options.Add(new Option { OptionText = "Car or Other", OptionValue = "A123" });
                    options.Add(new Option { OptionText = "Unknown/No Property", OptionValue = "A124" });


                    qn.Options = options;

                    break;
            }

            return qn;
        }

        
    }
}