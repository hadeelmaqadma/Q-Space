namespace QSpace.Data.DbEntities
{
    public class QuizDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}