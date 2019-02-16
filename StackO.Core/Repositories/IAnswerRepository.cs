 using System.Collections.Generic;
 using System.Threading.Tasks;
 using System;
 using StackO.Core.Models;

 namespace StackO.Core.Repositories {
     public interface IAnswerRepository {
         Task<Answer> Get (Guid id);
         Task<List<Answer>> GetByQuestionId (Guid questionId);
         Task<List<Answer>> GetAll ();
         Task<Answer> Add (Answer answer);
         Task<Answer> Update (Answer answer);
         Task<bool> Delete (Guid id);
     }
 }