using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointeuse.Data.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Annee { get; set; } = string.Empty;

        // Relation inverse : une promotion a plusieurs étudiants
        public ICollection<Etudiant>? Etudiants { get; set; }
    }
}
