using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson08DF.Models;

public partial class Category
{
    [Display(Name = "Mã loại sách")]
    public int CategoryId { get; set; }

    [Display(Name = "Tên loại sách")]
    [Required(ErrorMessage = "Vui lòng nhập tên loại sách")]
    [StringLength(100, ErrorMessage = "Tên loại sách không được vượt quá 100 ký tự")]
    public string? CategoryName { get; set; }

    [Display(Name = "Danh sách sách")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
