﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Process : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ProcessLiderId { get; set; }
        
    }
}
