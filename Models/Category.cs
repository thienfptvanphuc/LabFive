using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabFive.Models;

public partial class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vui long khong de trong!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Vui long khong de trong!")]
    public string? Slug { get; set; }
    [Required(ErrorMessage = "Vui long khong de trong!")]
    public string? Des { get; set; }

    public int? Status { get; set; }
}
