namespace University.Data.Config
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class ConfigScores : EntityTypeConfiguration<Score>
    {
        public ConfigScores()
        {
            this.HasKey(sc => 
                new { sc.StudentId, sc.CourseId }
            );

            this.HasRequired(sc => sc.Student)
                .WithMany(st => st.Scores)
                .HasForeignKey(sc => sc.StudentId);

            this.HasRequired(sc => sc.Course)
                .WithMany(co => co.Scores)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
