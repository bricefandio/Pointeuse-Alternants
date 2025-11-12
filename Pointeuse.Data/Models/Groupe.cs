using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointeuse.Data.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // FE / FA

        // Relation inverse : un groupe peut avoir plusieurs étudiants
        public ICollection<Etudiant>? Etudiants { get; set; }
    }
}
