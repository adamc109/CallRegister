namespace CallRegisterWeb.Models
{
    public class Email
    {

        public int Id { get; set; }
        public string Agent { get; set; }
        public DateOnly AllocatedDate { get; set; }
        public DateOnly DateDue { get; set; }
        public DateOnly DateCompleted { get; set; }
        public Boolean Internal { get; set; }
        public String ProductType { get; set; }

    }
}
