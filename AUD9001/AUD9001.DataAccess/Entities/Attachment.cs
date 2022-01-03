using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class Attachment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime DeleteDate { get; set; }
    }
}
