using System;
using System.Collections.Generic;

namespace WebTestApi.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Picture { get; set; }

    public int QuestionTypeId { get; set; }

    public int Value { get; set; }

    public virtual ICollection<AnswerVariant> AnswerVariants { get; } = new List<AnswerVariant>();

    //public virtual QuestionType QuestionType { get; set; } = null!;

    //public virtual Test? Test { get; set; }
}
