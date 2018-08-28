namespace University.Data.Config
{
    using University.Models;
    using System.Data.Entity.ModelConfiguration;

    public class ConfigCourses : EntityTypeConfiguration<Course>
    {
        public ConfigCourses()
        {
            this.HasKey(c => c.Id);
        }
    }
}
