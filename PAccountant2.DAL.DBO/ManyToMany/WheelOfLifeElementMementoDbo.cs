using PAccountant2.DAL.DBO.Entities.WheelOfLife;

namespace PAccountant2.DAL.DBO.ManyToMany
{
    public class WheelOfLifeElementMementoDbo
    {
        public int Id { get; set; }

        public int WheelElementId { get; set; }

        public WheelOfLifeElementDbo WheelElement { get; set; }

        public int WheelMementoId { get; set; }

        public WheelOfLifeMementoDbo WheelMemento { get; set; }
    }
}
