using Flyer.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flyer.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {        
        [Key]
        public int Id { get; set; }

        public bool Status { get; set; } = true;

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy HH:mm:ss.fff}")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
