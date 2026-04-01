namespace MyAcademyMediatorProject.Entities
{
    public class Banner
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string ImageUrl { get; set; }

        public string BgColor { get; set; } = "#FFA500";

        public int OrderNo { get; set; }

        public bool IsActive { get; set; }
    }
}