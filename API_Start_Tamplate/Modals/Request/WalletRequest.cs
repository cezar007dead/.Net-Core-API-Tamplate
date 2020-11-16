using API_Start_Template.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Start_Template.Modals.Request
{
    public class WalletRequest : Wallet {

        [Required]
        public static string Name { get; set; }

        public static DateTime LastTimeAccess { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public static double Value { get; set; }

    }
}
