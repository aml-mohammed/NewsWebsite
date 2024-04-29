using Infrastructure.Entities;

namespace NewsWebsiteApi.Dtos
{
    public class newstoReturnDto
    {
        public string Title { get; set; } = null!;
        public string NewsBody { get; set; } = null!;
        public string Image { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
