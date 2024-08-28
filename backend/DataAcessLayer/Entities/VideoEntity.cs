using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
    public class VideoEntity
    {
        [Key, Required]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        [ForeignKey("UserEntity")]
        public int UserId { get; set; } 
        public virtual UserEntity User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
