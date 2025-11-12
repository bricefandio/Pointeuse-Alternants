using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pointeuse.Data.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public int GroupeId { get; set; }
        public int PromotionId { get; set; }
        public string? QrCodeHash { get; set; }

        // Relations
        public Groupe? Groupe { get; set; }
        public Promotion? Promotion { get; set; }
        public ICollection<Pointage>? Pointages { get; set; }
    }
}
