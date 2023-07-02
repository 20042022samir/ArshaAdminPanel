using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArshaAdminPanel.Core.Entites
{
    public class SocialMedia:BaseModel
    {
        public string Name { get; set; }
        public List<Employees> employees { get; set; }
    }
}
