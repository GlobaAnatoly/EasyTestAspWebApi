using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string TeacherName { get; set; } = null!;

    public string TeacherLogin { get; set; } = null!;

    public byte[] TeacherPassword { get; set; } = null!;
    public virtual string? TeacherPasswordStr { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
