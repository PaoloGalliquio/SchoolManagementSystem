using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.DTO
{
    public class StudentDTO
    {
        public string IdentityCard { get; set; } = null!;

        public string Names { get; set; } = null!;

        public string Surnames { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public int IdSchool { get; set; }

        public string SchoolName { get; set; } = null!;

        public string FullName
        {
            get
            {
                return string.Join(" ", new[] { Names, Surnames }.Where(s => !string.IsNullOrEmpty(s)));
            }
        }
    }
}
