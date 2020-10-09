using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRUD_EntityFramework
{
    class SalaAula
    {
        public int Id { get; set; }
        public string Professor { get; set; }
        public string Sala { get; set; }
        public string Curso { get; set; }
        public string Data { get; set; }
    }
}
