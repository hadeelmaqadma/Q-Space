using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QSpace.Data.Data
{
    public class QSpaceDbContext : IdentityDbContext<User>
    {
        public QSpaceDbContext(DbContextOptions<QSpaceDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration["ConnectionStrings:DefaultConnection"];
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<MCQuestionDbEntity> MCQustions { get; set; }
        public DbSet<QuizDbEntity> Quizzes { get; set; }
        public DbSet<SessionDbEntity> Sessions { get; set; }
        public DbSet<StudentDbEntity> Students { get; set; }
        public DbSet<StudentQuestionsDbEntity> StudentsQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentQuestionsDbEntity>().HasKey(x => new { x.QuestionId, x.StudentId});
            builder.Entity<QuizDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<MCQuestionDbEntity>().HasQueryFilter(x => !x.IsDeleted);
        } 
    }
}
