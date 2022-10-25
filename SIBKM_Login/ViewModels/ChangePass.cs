using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApp.ViewModels
{
    public class ChangePass
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassLama { get; set; }
        public string PassBaru { get; set; }
    }
}
