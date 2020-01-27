using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersRepoWebAPI_MVCApp.Models
{
    public class mvcUsersModel
    {
        public int id { get; set; }
        [Required(ErrorMessage="Pole wymagane!")]
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}