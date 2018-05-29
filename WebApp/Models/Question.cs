using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Question
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }

        public List<Option> Options { get; set; }


    }
}