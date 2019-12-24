using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife
{
    public class WheelOfLifeElementDataItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Score { get; set; }

        public IEnumerable<WheelOfLifeProblemDataItem> Problems { get; set; }
    }
}
