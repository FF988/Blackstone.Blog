# System.ComponentModel.DataAnnotations常用標籤分類與解析

## 資料庫結構標籤 (Schema Mapping)
這些標籤會直接影響 dotnet ef migrations 產生的 SQL 指令。
[Key]: 指定該屬性為資料表的主鍵（Primary Key）。預設名稱為 Id 或 類別名Id 的屬性會自動被視為主鍵，但若名稱不同（例如 BlogCode），則必須標註。
[Required]: 標記為「必填」。在資料庫中會對應 NOT NULL。
[MaxLength(n)]: 限制最大長度。對應資料庫的 nvarchar(n)。
[Column("name", TypeName = "decimal(18,2)")]: 映射到資料庫的特定欄位名稱或型別（例如金融數據常用的 decimal）。
[Table("TableName")]: 指定資料表名稱（預設會用類別名的複數）。
** [ForeignKey("PropName")]: 明確指定外鍵關係。
[NotMapped]: 告訴 EF Core 忽略此屬性，不要在資料庫中建立對應欄位。
## 資料驗證標籤 (Validation)
當使用者提交資料到您的 WebAPI 或 MVC 時，這些標籤會自動觸發 ModelState.IsValid 驗證。
[StringLength(max, MinimumLength = min)]: 同時限制最大與最小長度。
[Range(min, max)]: 限制數值區間（例如新聞排序權重 0~100）。
** [EmailAddress]: 驗證格式是否符合電子郵件。
[Url]: 驗證是否為有效的 URL 格式。
[RegularExpression(@"pattern")]: 使用正規表示式進行複雜驗證。
[Compare("OtherProperty")]: 用於確認密碼與確認密碼是否一致。
## 顯示與格式化標籤 (UI/Display)
主要用於 MVC 或 Razor Pages。
[Display(Name = "顯示名稱")]: 設定前端標籤（Label）或 Table Header 的顯示文字。
[DataType(DataType.Date)]: 指定數據類型（如密碼、日期、多行文字），會影響瀏覽器產生的 HTML Input 類型。
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]: 指定顯示格式。

## 範例：
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models;

[Table("AppBlog")] // 資料庫中，資料表名稱為 AppBlog
public class Blog
{
    [Key]
    public int BlogId { get; set; }

    [Required(ErrorMessage = "標題是必填的")]
    [MaxLength(200)]
    [Display(Name = "新聞標題")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(10, ErrorMessage = "內容不能少於10個字")]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime PublishDate { get; set; } = DateTime.Now;
    
    [Display(Name = "建立日期")]
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    [Display(Name = "最後更新日期")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // 關聯設定
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public virtual BlogCategory? Category { get; set; }
}