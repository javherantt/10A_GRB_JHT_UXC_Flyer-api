using Flyer.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flyer.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
