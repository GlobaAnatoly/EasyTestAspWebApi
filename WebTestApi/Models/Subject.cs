using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
