using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models.Configuration
{
    public class ConfigJSON
    {
        [Key]
        public string Key { get; set; }
        public string Data { get; set; }
    }
}
