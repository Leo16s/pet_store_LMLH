namespace PetApp.Domain
{
    public enum TipoMascota
    {
        Gato,
        Perro,
        Reptil,
        Ave
    }

    public enum Genero
    {
        Niña,
        Niño
    }

    public class Mascota
    {
        public string Nombre { get; set; }
        public TipoMascota Tipo { get; set; }
        public int Edad { get; set; }
        public Genero Genero { get; set; }
    }
}
