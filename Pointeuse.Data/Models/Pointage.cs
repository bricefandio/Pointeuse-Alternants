using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointeuse.Data.Models
{
    public class Pointage
    {
        public int Id { get; set; }
        public int EtudiantId { get; set; }
        public DateTime DateHeureScan { get; set; }
        public string Statut { get; set; } = string.Empty;

        public Etudiant? Etudiant { get; set; }
    }
}
