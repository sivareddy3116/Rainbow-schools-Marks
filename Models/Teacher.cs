﻿using System;
using System.Collections.Generic;

namespace RainbowSchoolsApi.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Marks = new HashSet<Mark>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
