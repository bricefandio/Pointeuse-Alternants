namespace Pointeuse.WebApp.Models
{
    public class EtudiantDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string QrCodeHash { get; set; }
        public int GroupeId { get; set; }
        public int PromotionId { get; set; }
        public string GroupeLibelle { get; set; }
        public string PromotionLibelle { get; set; }
    }
}
