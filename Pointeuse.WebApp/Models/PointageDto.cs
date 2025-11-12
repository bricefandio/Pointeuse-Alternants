namespace Pointeuse.WebApp.Models
{
    public class PointageDto
    {
        public int Id { get; set; }
        public int EtudiantId { get; set; }
        public string EtudiantNom { get; set; }
        public DateTime DateHeureScan { get; set; }
        public string Statut { get; set; }
    }
}
