using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Shoppit.Pages
{
    public class IndexModel : PageModel
    {
        public string msg;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string user, string pass)
        {
            login(user, pass);
        }

        private void login(string u, string p)
        {
            using (MySqlConnection c = new MySqlConnection("Server=localhost;Database=shoppit;Uid=root;Password="))
            {
                MySqlCommand cmd = new MySqlCommand();
                c.Open();
                cmd.Connection = c;
                cmd.CommandText = $"SELECT * FROM users WHERE username='{u}' AND password='{p}'";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //ViewData["Mensaje"] = "Si existe el usuario";
                        Response.Redirect("Empleados");
                    }
                    else
                    {
                        //ViewData["Mensaje"] = "Error no se encontro el usuario";
                        msg = "Error en el nombre o contraseña";
                    }
                }
            }

        }
    }
}