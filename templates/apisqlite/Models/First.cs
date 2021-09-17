namespace ApiSqlite.Models
{
    public class First : Entity
    {
        public string? Name { get; set; }

        public First(string name) {
            Name = name;
        }
    }
}