using System;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeMementoEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Score { get; set; }

        public int ElementId { get; set; }
    }
}
