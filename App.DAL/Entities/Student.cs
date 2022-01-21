using System;
using System.Collections.Generic;

#nullable disable

namespace App.DAL.Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
