﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife
{
    public class WheelOfLifeProblemViewItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ElementId { get; set; }

        public bool IsFinished { get; set; }
    }
}
