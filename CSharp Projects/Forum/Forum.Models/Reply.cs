namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Reply
    {
        public Reply(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.AuthorId = authorId;
            this.PostId = postId;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }

        public override string ToString()
        {
            return string.Format(
                    "{0};{1};{2};{3}",
                    this.Id,
                    this.Content,
                    this.AuthorId,
                    this.PostId);
        }
    }
}
