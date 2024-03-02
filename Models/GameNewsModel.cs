namespace Game_review_project.Models
{
    public class GameNewsModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }

    public enum Category {
        Tripple_A, Indie, Live_Services
    }
}
