namespace Exercise_02_Extended_Database
{
    public class Person : IPerson
    {
        private long id;
        private string username;

        public Person(long id, string name)
        {
            this.id = id;
            this.username = name;
        }

        public long Id => this.id;
        public string Username => this.username;

        public override string ToString()
        {
            return $"id:{this.Id} - name:{this.Username}";
        }
    }
}
