using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson08DF.Models;

public partial class Publisher
{
    [Display(Name = "Mã nhà xuất bản")]
    public int PublisherId { get; set; }

    [Display(Name = "Tên nhà xuất bản")]
    [Required(ErrorMessage = "Vui lòng nhập tên nhà xuất bản")]
    [StringLength(200, ErrorMessage = "Tên nhà xuất bản không được vượt quá 200 ký tự")]
    public string? PublisherName { get; set; }

    [Display(Name = "Điện thoại")]
    [StringLength(30, ErrorMessage = "Số điện thoại không được vượt quá 30 ký tự")]
    public string? Phone { get; set; }

    [Display(Name = "Địa chỉ")]
    [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự")]
    public string? Address { get; set; }

    [Display(Name = "Danh sách sách")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
