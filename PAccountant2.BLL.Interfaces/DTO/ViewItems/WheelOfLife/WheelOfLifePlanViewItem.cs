namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife
{
    public class WheelOfLifePlanViewItem
    {
        public int Id { get; set; }

        public int ProblemId { get; set; }

        public string Description { get; set; }

        public bool IsFinished { get; set; }
    }
}
