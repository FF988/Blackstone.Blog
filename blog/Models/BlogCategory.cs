namespace Blackstone.Models;
public class BlogCategory
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    // 使用 string.Empty 避免 Nullable 警告
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // 導覽屬性：一個分類擁有多則新聞
    public virtual ICollection<Blog> BlogItems { get; set; } = new List<Blog>();
}