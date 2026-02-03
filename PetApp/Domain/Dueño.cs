using System.Collections.Generic;

namespace PetApp.Domain
{
    public class Dueño
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}
