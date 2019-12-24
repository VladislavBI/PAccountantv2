using System;
using System.Collections.Generic;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeElementEntity
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Name { get; set; }

        public IEnumerable<WheelOfLifeProblemEntity> Problems { get; set; }

        public IEnumerable<WheelOfLifeMementoEntity> Mementos { get; set; }

        public void ChangeScore(IncrementalChange changeType)
        {
            switch (changeType)
            {
                case IncrementalChange.Increase:
                    Score = Score == 10 ? Score : Score + 1; 
                    break;
                case IncrementalChange.Decrease:
                    Score = Score == 1 ? Score : Score - 1;
                    break;
                default:
                    break;
            }
        }
    }
}
