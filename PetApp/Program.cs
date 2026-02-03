using System;
using System.Collections.Generic;
using System.Linq;
using PetApp.Domain;

namespace PetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize data
            var dueños = new List<Dueño>
            {
                new Dueño
                {
                    Nombre = "Juan Perez",
                    Direccion = "Calle Falsa 123",
                    Telefono = "555-1234",
                    Mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Fido", Tipo = TipoMascota.Perro, Edad = 3, Genero = Genero.Niño },
                        new Mascota { Nombre = "Mishu", Tipo = TipoMascota.Gato, Edad = 5, Genero = Genero.Niña }
                    }
                },
                new Dueño
                {
                    Nombre = "Maria Rodriguez",
                    Direccion = "Avenida Siempreviva 742",
                    Telefono = "555-5678",
                    Mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Rex", Tipo = TipoMascota.Perro, Edad = 2, Genero = Genero.Niño }
                    }
                },
                new Dueño
                {
                    Nombre = "Carlos Gomez",
                    Direccion = "Boulevard de los Sueños Rotos 45",
                    Telefono = "555-8765",
                    Mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Piolin", Tipo = TipoMascota.Ave, Edad = 1, Genero = Genero.Niño },
                        new Mascota { Nombre = "Silvestre", Tipo = TipoMascota.Gato, Edad = 4, Genero = Genero.Niño }
                    }
                },
                 new Dueño
                {
                    Nombre = "Laura Ipsum",
                    Direccion = "Avenida Siempreviva 742",
                    Telefono = "555-5678",
                    Mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Garfield", Tipo = TipoMascota.Gato, Edad = 2, Genero = Genero.Niño }
                    }
                }
            };

            var app = new Application(dueños);

            Console.WriteLine("--- Todas las mascotas ---");
            app.ConsultarTodasLasMascotas();

            Console.WriteLine("\n--- Mascotas que son gatos ---");
            app.ConsultarMascotasGatos();

            Console.WriteLine("\n--- Dueños que solo tienen perros ---");
            app.ConsultarDueñosConSoloPerros();

            Console.WriteLine("\n--- Todos los dueños ---");
            app.ConsultarTodosLosDueños();
        }
    }

    public class Application
    {
        private readonly List<Dueño> _dueños;

        public Application(List<Dueño> dueños)
        {
            _dueños = dueños;
        }

        public void ConsultarTodasLasMascotas()
        {
            var todasLasMascotas = _dueños.SelectMany(d => d.Mascotas);
            foreach (var mascota in todasLasMascotas)
            {
                Console.WriteLine($"- {mascota.Nombre} ({mascota.Tipo})");
            }
        }

        public void ConsultarMascotasGatos()
        {
            var gatos = _dueños.SelectMany(d => d.Mascotas).Where(m => m.Tipo == TipoMascota.Gato);
            foreach (var gato in gatos)
            {
                Console.WriteLine($"- {gato.Nombre}");
            }
        }

        public void ConsultarDueñosConSoloPerros()
        {
            var dueñosConSoloPerros = _dueños.Where(d => d.Mascotas.All(m => m.Tipo == TipoMascota.Perro) && d.Mascotas.Any());
            foreach (var dueño in dueñosConSoloPerros)
            {
                Console.WriteLine($"- {dueño.Nombre}");
            }
        }

        public void ConsultarTodosLosDueños()
        {
            foreach (var dueño in _dueños)
            {
                Console.WriteLine($"- {dueño.Nombre}");
            }
        }
    }
}