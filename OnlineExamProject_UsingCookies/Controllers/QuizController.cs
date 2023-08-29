using Microsoft.AspNetCore.Mvc;
using OnlineExamProject_UsingCookies.Models;

namespace OnlineExamProject_UsingCookies.Controllers
{
    public class QuizController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Question1()
        {
           
            count = 0;
            var question = new QuestionModel()
            {
                QuestionText = "Which HTTP method is commonly used for submitting form data to the server in ASP.NET Core MVC?",
                Options = new List<string> { "put", "post", "patch", "delete" },
                CorrectAnswer = "post"
            };
            TempData["CorrectAnswer"] = question.CorrectAnswer;
            return View(question);
        }
        [HttpPost]
        public IActionResult Question1(QuestionModel question)
        {
            if (question.SelectedOption == null)
                question.SelectedOption = "";

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(2) // Set the expiration time here
            };
            Response.Cookies.Append("Q1", question.SelectedOption, cookieOptions);

           /* if (IsCookieTimedOut("Q1"))
            {
                return RedirectToAction("SessionTimedOut"); // Redirect to a page indicating session timeout
            }
*/

            // Response.Cookies.Append("Q1", question.SelectedOption);

            if (question.SelectedOption== TempData["CorrectAnswer"].ToString())
            {
                Response.Cookies.Append("Quest1", "y", cookieOptions);

            }
            else
                Response.Cookies.Append("Quest1", "n", cookieOptions);
            return RedirectToAction("Question2");

            
        }

        public IActionResult Question2()
        {

           /* if (IsCookieTimedOut("Q1"))
            {
                return RedirectToAction("SessionTimedOut"); // Redirect to a page indicating session timeout
            }
*/

            var question = new QuestionModel()
            {
                QuestionText = "Which component is responsible for handling user interactions and updating the Model and View?",
                Options = new List<string> { "model", "view", "controller", "class" },
                CorrectAnswer = "controller"
            };
            TempData["CorrectAnswer"] = question.CorrectAnswer;

            return View(question);
        }
        [HttpPost]
        public IActionResult Question2(QuestionModel question)
        {
            if (question.SelectedOption == null)
                question.SelectedOption = "";


            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(2) // Set the expiration time here
            };
            Response.Cookies.Append("Q2", question.SelectedOption, cookieOptions);

          /*  if (IsCookieTimedOut("Q2"))
            {
                return RedirectToAction("SessionTimedOut"); // Redirect to a page indicating session timeout
            }*/


            //Response.Cookies.Append("Q2", question.SelectedOption);
            if (question.SelectedOption == TempData["CorrectAnswer"].ToString())
            {
                Response.Cookies.Append("Quest2", "y", cookieOptions);

            }
            else
                Response.Cookies.Append("Quest2", "n", cookieOptions);
            return RedirectToAction("Question3");


        }
        public IActionResult Question3()
        {



           /* if (IsCookieTimedOut("Q1"))
            {
                return RedirectToAction("SessionTimedOut"); // Redirect to a page indicating session timeout
            }*/


            var question = new QuestionModel()
            {
                QuestionText = "Which component in ASP.NET Core MVC defines the structure of data and provides methods for interacting with it?",
                Options = new List<string> { "model", "view", "controller", "middleware" },
                CorrectAnswer = "model"
            };
            TempData["CorrectAnswer"] = question.CorrectAnswer;

            return View(question);
        }
        [HttpPost]
        public IActionResult Question3(QuestionModel question)
        {
            if (question.SelectedOption == null)
                question.SelectedOption = "";


            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(2) // Set the expiration time here
            };
            Response.Cookies.Append("Q3", question.SelectedOption, cookieOptions);

          /*  if (IsCookieTimedOut("Q3"))
            {
                return RedirectToAction("SessionTimedOut"); // Redirect to a page indicating session timeout
            }*/

            //Response.Cookies.Append("Q3", question.SelectedOption);
            if (question.SelectedOption == TempData["CorrectAnswer"].ToString())
            {
                Response.Cookies.Append("Quest3", "y", cookieOptions);

            }
            else
                Response.Cookies.Append("Quest3", "n", cookieOptions);
            return RedirectToAction("Result");


        }
        static int count = 0;
        public IActionResult Result()
        {
           ViewBag.SelectedAns1 = Request.Cookies["Q1"];
            ViewBag.SelectedAns2 = Request.Cookies["Q2"];
            ViewBag.SelectedAns3 = Request.Cookies["Q3"];

            for(int i=0;i<Request.Cookies.Count;i++)
            {
                string question = "Quest" + (i + 1);
                if (Request.Cookies[question]=="y")
                {
                    
                    count++;
                }
            }
            ViewBag.Score = count;

            return View();
        }
       /* private bool IsCookieTimedOut(string cookieName)
        {
            var lastActivityTime = HttpContext.Session.GetString("LastActivity");
            if (!string.IsNullOrEmpty(lastActivityTime))
            {
                var currentTime = DateTime.Now;
                var sessionTimeout = TimeSpan.FromSeconds(15); // Set the session timeout here

                var lastActivity = DateTime.Parse(lastActivityTime);
                return currentTime - lastActivity > sessionTimeout;
            }

            return false;
        }
        public IActionResult SessionTimedOut()
        {
            return View("SessionTimedOut");
        }*/

    }
}
