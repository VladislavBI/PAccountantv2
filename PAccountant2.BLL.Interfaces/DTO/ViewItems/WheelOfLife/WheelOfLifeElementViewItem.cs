using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife
{
    public class WheelOfLifeElementViewItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public IEnumerable<WheelOfLifeProblemViewItem> Problems { get; set; }
    }
}
