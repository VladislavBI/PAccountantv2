﻿using System;

namespace PAccountant2.DAL.DBO.Entities.WheelOfLife
{
    public class WheelOfLifeMementoDbo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Score { get; set; }

        public int ElementId { get; set; }

        public WheelOfLifeElementDbo Element{ get; set; }
    }
}
