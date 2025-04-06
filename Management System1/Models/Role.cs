namespace Management_System1.Models
{
    public class Role
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> users { get; set; } = new List<User>();
    }
}
