namespace PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife
{
    public class WheelOfLifePlanDataItem
    {
        public int Id { get; set; }

        public int ProblemId { get; set; }

        public string Description { get; set; }

        public bool IsFinished { get; set; }
    }
}
