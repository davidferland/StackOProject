using System;
using System.Collections.Generic;
using StackO.Core.Models;

namespace StackO.Core.Models {
    public class Question : BaseEntity {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public List<Answer> Answers { get; set; }
    }
}