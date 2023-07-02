using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArshaAdminPanel.Core.Entites
{
    public class Employees:BaseModel
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
        public int PositionId { get; set; }
        public Positionn Position { get; set; }
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
