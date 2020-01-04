using System;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeEntity
    {
        public IEnumerable<WheelOfLifeElementEntity> Elements { get; set; }

        public IEnumerable<WheelOfLifeMementoEntity> Mementos { get; set; }

        public IEnumerable<WheelOfLifeMementoDateValueObject> CreateMementoDates()
        {
            var currentSum = Elements.Sum(e => e.Score);
            var currentWheel = new WheelOfLifeMementoDateValueObject
            {
                Date = DateTime.Now,
                TotalScore = currentSum
            };


            var mementoDates = Mementos.GroupBy(m => m.Date.Date)
                .Select(gm => new WheelOfLifeMementoDateValueObject
                {
                    Date = gm.Key,
                    TotalScore = gm.Sum(m => m.Score)
                }).ToList();

            mementoDates.Add(currentWheel);
            mementoDates = mementoDates.OrderByDescending(md => md.Date).ToList();

            return mementoDates;
        }
    }
}
