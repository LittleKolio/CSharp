namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG
            = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
        private static Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var cofig = contents
                .Select(l => l.Split('='))
                .ToDictionary(l => l[0], l => DATA_PATH + l[1]);

            return cofig;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {
                //line format: {Id};{Name};{postId1,postId2,postId3...}
                var args = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var name = args[1];
                var postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }
            return categories;
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                //line format: {Id};{Username};{Password};{postId1,postId2,postId3...}
                var args = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];
                var postIds = args[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                User user = new User(id, username, password, postIds);
                users.Add(user);
            }
            return users;
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                //line format: {Id};{Title};{Content};{CategoryId};{AuthorId};{replyId1,replyId2,replyId3...}
                var args = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = int.Parse(args[3]);
                var authorId = int.Parse(args[4]);
                var repliesIds = args[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Post post = new Post(id, title, content, categoryId, authorId, repliesIds);
                posts.Add(post);
            }
            return posts;
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                //line format: {Id};{Content};{AuthorId};{PostId}
                var args = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postId = int.Parse(args[3]);

                Reply reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }
            return replies;
        }

        public static void Save<T>(IEnumerable<T> data)
        {
            List<string> lines = new List<string>();
            foreach (var token in data)
            {
                lines.Add(token.ToString());
            }

            string type = typeof(T).Name;
            switch (type)
            {
                case "Category": WriteLines(config["categories"], lines.ToArray()); break;
                case "User": WriteLines(config["users"], lines.ToArray()); break;
                case "Post": WriteLines(config["posts"], lines.ToArray()); break;
                case "Reply": WriteLines(config["replies"], lines.ToArray()); break;

                default: break;
            }
        }

        //public static void SaveCategories(List<Category> categories)
        //{
        //    List<string> lines = new List<string>();
        //    foreach (var category in categories)
        //    {
        //        lines.Add(category.ToString());
        //    }
        //    WriteLines(config["categories"], lines.ToArray());
        //}
    }
}