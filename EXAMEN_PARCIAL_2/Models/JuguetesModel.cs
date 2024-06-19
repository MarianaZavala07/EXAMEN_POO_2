namespace EXAMEN_PARCIAL_2.Models
{
    public class JuguetesModel 
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime? Vigencia { get; set; }
        public bool Activo { get; set; }
        //public List<Juguete> ListadoDeJuguetes { get; set; } = new List<Juguete>();
    }
}