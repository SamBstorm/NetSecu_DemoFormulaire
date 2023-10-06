using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Models.Entities
{
    public class Jeux
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Editeur { get; set; }
        public int AnneeSortie { get; set; }
        public DateTime DateAjout { get; set; }
        public Utilisateur Createur { get; set; }

        public Guid CreateurId { get; set; }
    }
}
