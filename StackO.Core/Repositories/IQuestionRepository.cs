using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackO.Core.Models;

namespace StackO.Core.Repositories {
    public interface IQuestionRepository {
        Task<Question> Get (Guid id);
        Task<List<Question>> GetAll ();
        Task<Question> Add (Question question);
        Task<Question> Update (Question question);
        Task<bool> Delete (Guid id);
    }
}