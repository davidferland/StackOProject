using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackO.Core.Infrastructure.Exceptions;
using StackO.Core.Models;
using StackO.Core.Repositories;
using StackO.Data.Context;

namespace StackO.Data.Repositories {
    public class AnswerRepository : IAnswerRepository {

        private readonly StackODBContext _db;
        public AnswerRepository (StackODBContext db) {
            _db = db;
        }
        public async Task<Answer> Get (Guid id) {
            return await _db.Answers
                .Where (a => !a.DeletedOn.HasValue)
                .FirstOrDefaultAsync (p => p.Id == id);
        }

        public async Task<List<Answer>> GetByQuestionId (Guid questionId) {
            return await _db.Answers
                .Where (a => a.QuestionId.Equals (questionId) && !a.DeletedOn.HasValue)
                .ToListAsync ();
        }
        public async Task<List<Answer>> GetAll () {
            return await _db.Answers
                .Where (a => !a.DeletedOn.HasValue)
                .ToListAsync ();
        }
        public async Task<Answer> Update (Answer answer) {
            var answerToUpdate = await _db.Answers
                .SingleAsync (t => t.Id == answer.Id);

            if (answerToUpdate == null) {
                throw new NotFoundException (nameof (Answer), answer.Id);
            }

            answerToUpdate.QuestionId = answer.QuestionId;
            answerToUpdate.Body = answer.Body;
            answerToUpdate.UpdatedOn = DateTime.UtcNow;

            _db.Update (answerToUpdate);

            await _db.SaveChangesAsync ();
            return answerToUpdate;
        }

        public async Task<Answer> Add (Answer answer) {
            var question = await _db.Questions
                .SingleAsync (t => t.Id == answer.QuestionId);

            if (question == null) {
                throw new NotFoundException (nameof (Question), answer.QuestionId);
            }

            answer.CreatedOn = DateTime.UtcNow;
            answer.UpdatedOn = DateTime.UtcNow;

            _db.Answers.Add (answer);

            await _db.SaveChangesAsync ();
            return answer;
        }

        public async Task<bool> Delete (Guid answerId) {
            var Answer = await _db.Answers
                .SingleAsync (t => t.Id == answerId);

            if (Answer == null) {
                throw new NotFoundException (nameof (Answer), answerId);
            }

            Answer.DeletedOn = DateTime.UtcNow;

            _db.Answers.Update (Answer);

            await _db.SaveChangesAsync ();
            return true;
        }
    }
}