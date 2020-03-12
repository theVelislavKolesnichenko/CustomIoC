using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Client.Model
{
    public class ResultList
    {
        public int Id;
        [Mapper("FirstName")]
        public string Title;
        public string Age { get; set; }
        public Status Status { get; set; }
        [Mapper("LastName")]
        public string SubTitle { get; set; }

        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum Status
    {
        Active,
        InActive
    }
}
