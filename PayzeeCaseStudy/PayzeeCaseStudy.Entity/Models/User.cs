using System;
using System.Collections.Generic;

namespace PayzeeCaseStudy.Entity.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public string ApiKey { get; set; } = null!;
}
