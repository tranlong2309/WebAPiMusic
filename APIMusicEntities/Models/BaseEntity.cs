using System;
using System.ComponentModel.DataAnnotations;

namespace APIMusicEntities.Models
{
    public class BaseEntity
    {   
        [Key]
        public int Id { get; set; }
        public string describe { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}