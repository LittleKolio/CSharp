﻿namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ForumData
    {
        public ForumData()
        {
            this.Categories = DataMapper.LoadCategories();
            this.Users = DataMapper.LoadUsers();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Reply> Replies { get; set; }

        public void SaveChanges()
        {
            DataMapper.Save<Category>(this.Categories);
            DataMapper.Save<User>(this.Users);
            DataMapper.Save<Post>(this.Posts);
            DataMapper.Save<Reply>(this.Replies);
        }
    }
}
