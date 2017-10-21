using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Symbiose.Data.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
