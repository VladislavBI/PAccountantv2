namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    public class WheelOfLifePlanViewModel
    {
        public int Id { get; set; }

        public int ProblemId { get; set; }

        public string Description { get; set; }

        public bool IsFinished { get; set; }
    }
}
