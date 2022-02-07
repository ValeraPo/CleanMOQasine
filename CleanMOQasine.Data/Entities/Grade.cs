namespace CleanMOQasine.Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Order Order { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            Grade grade = (Grade)obj;
            if (grade.Id != Id
                || grade.IsAnonymous != IsAnonymous
                || grade.Comment != Comment
                || grade.Rating != Rating
                || grade.IsDeleted != IsDeleted
                )
                return false;
            return true;//ored eql
        }

        public override string ToString()
        {
            return $"{Id} {IsAnonymous} {Comment} {Rating} {IsDeleted}";
        }
    }
}
