using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointeuse.Maui.Models
{
    public class EtudiantDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public int GroupeId { get; set; }
        public int PromotionId { get; set; }
        public string QrCodeHash { get; set; } = string.Empty;
    }
}
