
namespace Blackstone.Models;
public class Blog
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public DateTime PublishDate { get; set; } = DateTime.Now;

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // 外鍵 (Foreign Key)
    public Guid BlogCategoryId { get; set; }
    
    // 導覽屬性：這則新聞所屬的分類
    public virtual BlogCategory? Category { get; set; }
}