namespace University.Data.Config
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class ConfigStudents : EntityTypeConfiguration<Student>
    {
        public ConfigStudents()
        {
            this.HasKey(s => s.Id);
        }
    }
}
