using System;

namespace StackO.Domain.Entities {
    public class Answer {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
    }
}