using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife
{
    public class WheelOfLifeMementoDataItem
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Score { get; set; }

        public int ElementId { get; set; }
    }
}
