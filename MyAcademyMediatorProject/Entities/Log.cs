namespace MyAcademyMediatorProject.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string ActionType { get; set; } // Order, Campaign, Contact
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}