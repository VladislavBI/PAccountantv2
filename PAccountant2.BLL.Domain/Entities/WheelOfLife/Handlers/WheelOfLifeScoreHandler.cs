using System;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife.Handlers
{
    class WheelOfLifeScoreHandler : IWheelOfLifeScoreHandler
    {

        public IEnumerable<WheelOfLifeMementoDateValueObject> GetAllWheelScores(
            IEnumerable<WheelOfLifeElementEntity> elements,
            IEnumerable<WheelOfLifeMementoEntity> mementos)
        {

            if (elements == null || !elements.Any())
            {
                throw new NullReferenceException("elements were not sent");
            }

            var mementosScores = new List<WheelOfLifeMementoDateValueObject>();

            var currentScore = GetWheelScore(elements, DateTime.Now);
            mementosScores.Add(currentScore);

            var mementoGroupedScores = GetAllMementosScores(mementos);
            mementosScores.AddRange(mementoGroupedScores);

            return mementosScores;
        }

        private IEnumerable<WheelOfLifeMementoDateValueObject> GetAllMementosScores(IEnumerable<WheelOfLifeMementoEntity> mementos)
        {
            List<WheelOfLifeMementoDateValueObject> mementosScores = new List<WheelOfLifeMementoDateValueObject>();

            var groupedMementos = mementos.GroupBy(m => m.Date);

            foreach (var mementosGroup in groupedMementos)
            {
                var mementosScore = GetMementoScore(mementosGroup);

                mementosScores.Add(mementosScore);
            }

            mementosScores = mementosScores.OrderByDescending(m => m.Date).ToList();

            return mementosScores;
        }

        private WheelOfLifeMementoDateValueObject GetMementoScore(IGrouping<DateTime, WheelOfLifeMementoEntity> mementosGroup)
        {
            var mementosToElements = mementosGroup.Select(m => new WheelOfLifeElementEntity
            {
                Score = m.Score
            });

            // ReSharper disable once PossibleNullReferenceException
            var mementosDate = mementosGroup.FirstOrDefault().Date;

            var mementosScore = GetWheelScore(mementosToElements, mementosDate);
            return mementosScore;
        }

        private WheelOfLifeMementoDateValueObject GetWheelScore(IEnumerable<WheelOfLifeElementEntity> elements, DateTime wheelDate)
        {
            var currentScore = elements.Sum(e => e.Score);

            var currentWheel = new WheelOfLifeMementoDateValueObject
            {
                Date = wheelDate,
                TotalScore = currentScore
            };

            return currentWheel;
        }
    }

}
