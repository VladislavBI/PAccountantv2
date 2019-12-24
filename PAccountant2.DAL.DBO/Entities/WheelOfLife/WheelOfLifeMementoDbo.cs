using System;
using System.Collections.Generic;
using PAccountant2.DAL.DBO.ManyToMany;

namespace PAccountant2.DAL.DBO.Entities.WheelOfLife
{
    public class WheelOfLifeMementoDbo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ICollection<WheelOfLifeElementMementoDbo> ElementMementos { get; set; }
    }
}
