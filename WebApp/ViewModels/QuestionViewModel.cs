using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class QuestionViewModel
    {
        public int NumberOfQuestions { get; set; }

        public Question Question { get; set; }

        public string SelectedAnswer { get; set; }
    }
}