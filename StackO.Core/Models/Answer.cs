using System;
using StackO.Core.Models;
namespace StackO.Core.Models {
    public class Answer : BaseEntity {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
    }
}