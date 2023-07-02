using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArshaAdminPanel.Core.Entites
{
    public class Positionn:BaseModel
    {
        public string Name { get; set; }
        public List<Employees> employess { get; set; }
    }
}


