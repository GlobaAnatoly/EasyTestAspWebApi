using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class Test
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; } = new List<Question>();

    public virtual ICollection<StudentsTest> StudentsTests { get; } = new List<StudentsTest>();

    //public virtual Subject Subject { get; set; } = null!;

    //public virtual Teacher Teacher { get; set; } = null!;
}
