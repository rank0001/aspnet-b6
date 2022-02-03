﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM.Models
{
    public class Session: BaseId, IId
    {
        public new int Id { get; set; }
        public int DurationInHour { get; set; }
        public string LearningObjective { get; set; }
    }
}
