using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Data.Data
{
    public class QSpaceDbContext : IdentityDbContext<User>
    {
        public QSpaceDbContext(DbContextOptions<QSpaceDbContext> options)
            : base(options)
        {

        }

        public DbSet<MCQuestionDbEntity> MCQustions { get; set; }
        public DbSet<QuizDbEntity> Quizzes { get; set; }
        public DbSet<SessionDbEntity> Sessions { get; set; }
        public DbSet<StudentDbEntity> Students { get; set; }
        public DbSet<StudentQuestionsDbEntity> StudentsQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<QuizDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<StudentQuestionsDbEntity>().HasKey(x => new { x.QuestionId, x.StudentId});
        }
    }
}
