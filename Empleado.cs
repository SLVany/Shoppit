using System.ComponentModel.DataAnnotations;

namespace Shoppit
{
    public class Empleado
    {
        [Key]
        public int id_empleado { get; set; }
        public string? nombre_empleado { get; set; }
        public string? apellido_empleado { get; set; }
    }
}
