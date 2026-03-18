namespace MyAcademyMediatorProject.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public string Title { get; set; }       // Başlık
        public string Subtitle { get; set; }    // Alt başlık
        public string ImageUrl { get; set; }    // Görsel yolu
        public bool IsActive { get; set; }      // Aktif/pasif
    }
}