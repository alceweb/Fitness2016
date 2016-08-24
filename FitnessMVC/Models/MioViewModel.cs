using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessMVC.Models
{
    public class MioViewModel
    {
    }
    public class SchedeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string User_Id { get; set; }
        public string Descrizione { get; set; }
    }
}