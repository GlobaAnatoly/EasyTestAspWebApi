using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class StudentsTest
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public int StudentId { get; set; }

    public int? Result { get; set; }

    public int AttemtsLeft { get; set; }

    public DateTime? Time { get; set; }

    //public virtual Student Student { get; set; } = null!;

    //public virtual Test? Test { get; set; }
}
