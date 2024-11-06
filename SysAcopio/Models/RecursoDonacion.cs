namespace SysAcopio.Models
{
    public partial class RecursoDonacion
    {
        public long IdRecursoDonacion { get; set; }
        public long IdDonacion { get; set; }
        public long IdRecurso { get; set; }
        public int Cantidad { get; set; }
    }
}