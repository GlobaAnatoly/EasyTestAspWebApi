using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class AnswerVariant
{
    public int Id { get; set; }

    public int IdQuestion { get; set; }

    public string Name { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual Question? IdQuestionNavigation { get; set; } = null!;
}
