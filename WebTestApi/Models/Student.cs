using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentLogin { get; set; } = null!;

    public byte[] StudentPassword { get; set; } = null!;
    public virtual string? StudentPasswordStr { get; set; } = null!;

    public virtual ICollection<StudentsTest> StudentsTests { get; } = new List<StudentsTest>();
}
