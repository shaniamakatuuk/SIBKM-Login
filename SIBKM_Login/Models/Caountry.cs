using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApp.Models
{
    public class Caountry
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Area Area { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
    }
}
