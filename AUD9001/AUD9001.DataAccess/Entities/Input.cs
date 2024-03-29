﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Input : EntityBase
    {
        public string Name { get; set; }
        public DateTime AdditionDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public string Description { get; set; }
        [Required]
        public Process Process { get; set; }
        public int ProcessId { get; set; }
    }
}
