namespace PhotoShare.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    public class TagService
    {
        public bool Exist(string tagname)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagname);
            }
        }

        public void AddTag(string tagname)
        {
            var tag = new Tag { Name = tagname };
            using (var context = new PhotoShareContext())
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }
    }
}
