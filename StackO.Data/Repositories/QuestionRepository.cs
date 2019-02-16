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
    public class QuestionRepository : IQuestionRepository {
        private readonly StackODBContext _db;
        public QuestionRepository (StackODBContext db) {
            _db = db;
        }
        public async Task<Question> Get (Guid id) {
            return await _db.Questions
                .Where (q => !q.DeletedOn.HasValue)
                .FirstOrDefaultAsync (p => p.Id == id);
        }
        public async Task<List<Question>> GetAll () {
            return await _db.Questions
                .Where (q => !q.DeletedOn.HasValue)
                .ToListAsync ();
        }
        public async Task<Question> Update (Question question) {
            var questionToUpdate = await _db.Questions
                .SingleAsync (t => t.Id == question.Id);

            if (questionToUpdate == null) {
                throw new NotFoundException (nameof (Question), question.Id);
            }

            questionToUpdate.Title = question.Title;
            questionToUpdate.Body = question.Body;
            questionToUpdate.UpdatedOn = DateTime.UtcNow;

            _db.Update (questionToUpdate);

            await _db.SaveChangesAsync ();

            return questionToUpdate;
        }

        public async Task<Question> Add (Question question) {

            question.CreatedOn = DateTime.UtcNow;
            question.UpdatedOn = DateTime.UtcNow;

            _db.Questions.Add (question);

            await _db.SaveChangesAsync ();
            return question;
        }

        public async Task<bool> Delete (Guid questionId) {
            var question = await _db.Questions
                .SingleAsync (t => t.Id == questionId);

            if (question == null) {
                throw new NotFoundException (nameof (Question), questionId);
            }

            foreach (Answer answer in question.Answers) {
                answer.DeletedOn = DateTime.UtcNow;
            }

            question.DeletedOn = DateTime.UtcNow;

            _db.Questions.Update (question);

            await _db.SaveChangesAsync ();
            return true;
        }
    }
}