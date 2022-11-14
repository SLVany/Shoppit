using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Shoppit.Pages
{
    public class EmpleadosModel : PageModel
    {
        public List<Empleado> empleados = new List<Empleado>();
        public void OnGet()
        {
            listaEmpleados();
        }

        public void listaEmpleados()
        {
            using (MySqlConnection c = new MySqlConnection("Server=localhost;Database=shoppit;Uid=root;Password="))
            {
                MySqlCommand cmd = new MySqlCommand();
                c.Open();
                cmd.Connection = c;
                cmd.CommandText = "SELECT * FROM empleados";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado()
                        {
                            id_empleado = reader.GetInt32("id_empleado"),
                            nombre_empleado = reader.GetString("nombre_empleado"),
                            apellido_empleado = reader.GetString("apellido_empleado")
                        });
                    }
                }
            }
        }
    }
}
