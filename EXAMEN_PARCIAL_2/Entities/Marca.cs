namespace EXAMEN_PARCIAL_2.Entities
{
    public class Marca
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
         public List<Marca> ListadoDeMarcas { get; set; } = new List<Marca>();
    }
}