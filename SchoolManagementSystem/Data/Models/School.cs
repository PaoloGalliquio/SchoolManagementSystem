using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Data.Models;

public partial class School
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCountry { get; set; }

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
