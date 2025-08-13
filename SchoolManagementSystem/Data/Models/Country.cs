using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Data.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<School> Schools { get; set; } = new List<School>();
}
