using PAccountant2.BLL.Domain.Entities.WheelOfLife.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeEntity
    {
        private readonly IWheelOfLifeScoreHandler scoreHandler;

        public WheelOfLifeEntity()
        {
            this.scoreHandler = new WheelOfLifeScoreHandler();
        }


        public IEnumerable<WheelOfLifeElementEntity> Elements { get; set; }

        public IEnumerable<WheelOfLifeMementoEntity> Mementos { get; set; }

        public IEnumerable<WheelOfLifeMementoDateValueObject> CreateMementoDates()
        {
            var mementoDates = scoreHandler.GetAllWheelScores(Elements, Mementos);

            return mementoDates;
        }
    }
}
