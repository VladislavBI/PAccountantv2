using PAccountant2.DAL.DBO.ManyToMany;
using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities.WheelOfLife
{
    public class WheelOfLifeElementDbo
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Name { get; set; }

        public ICollection<WheelOfLifeProblemDbo> Problems { get; set; }

        public ICollection<WheelOfLifeElementMementoDbo> ElementMementos { get; set; }


    }
}
