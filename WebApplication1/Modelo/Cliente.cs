using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modelo
{
    public class Cliente : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        public DateTime fechaNac { get; set; }
        public int dni { get; set; }



    }
}
