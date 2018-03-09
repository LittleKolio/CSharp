namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Post
    {
        public Post(
            int id, 
            string title, 
            string content, 
            int categoryId, 
            int authorId, 
            IEnumerable<int> repliesIds)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.RepliesIds = new List<int>(repliesIds);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public ICollection<int> RepliesIds { get; set; }

        public override string ToString()
        {
            return string.Format(
                    "{0};{1};{2};{3}",
                    this.Id,
                    this.Title,
                    this.Content,
                    this.CategoryId,
                    this.AuthorId,
                    string.Join(',', this.RepliesIds));
        }
    }
}
