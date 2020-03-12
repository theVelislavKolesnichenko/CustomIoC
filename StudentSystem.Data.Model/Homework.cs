using Framework.DataAccess.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Model
{
    public class Homework : IUnitState
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTime Deadline { get; set; }
        public Guid CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        #region IUnitState Members

        public UnitState UnitState { get; set; }

        #endregion
    }
}
