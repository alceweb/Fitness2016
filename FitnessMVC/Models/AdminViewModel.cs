using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitnessMVC.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Data di nascita")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascita { get; set; }
        [Display(Name = "Anno inizio attività")]
        public string AnnoInizio { get; set; }
        [Display(Name = "Grado")]
        public string Grado { get; set; }
        [Display(Name = "La tua frase")]
        public string Frase { get; set; }
        [Display(Name = "Tokui kata")]
        public string Kata { get; set; }
        [Display(Name = "Maestro")]
        public bool Maestro { get; set; }
        [Display(Name = "Istruttore")]
        public bool Istruttore { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

    public class AllenamentiViewModel
    {
        public int Id { get; set; }
        public int Scheda_Id { get; set; }
        public string GruppoMuscolare { get; set; }
        public int Esercizio_Id { get; set; }
        public virtual Esercizi Esercizio { get; set; }
        public int Serie { get; set; }
        public int SerieUt { get; set; }
        public int Ripetizioni { get; set; }
        public int RipetizioniUt { get; set; }
        public int Peso { get; set; }
        public int PesoUt { get; set; }
        public int Riposo { get; set; }
        public int RiposoUt { get; set; }
        public string Descrizione { get; set; }
        public int Somma { get; set; }
    }

    public class AllPercViewModel
    {
        public int Numero { get; set; }
        public int SommaSerieUt { get; set; }
        public int SommaSerie { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine {get;set;}
    }
    public class AllList1ViewModel
    {
        public int Esercizio_Id { get; set; }
        public int TotMovimenti{ get; set; }
        public int MaxNumero { get; set; }
        public int AllenamentoId { get; set; }
    }

    public class EditAllenamentoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Serie")]
        public int Serie { get; set; }
        [Display(Name = "Serie")]
        public int SerieUt { get; set; }
        [Display(Name = "Ripetizioni")]
        public int Ripetizioni { get; set; }
        [Display(Name = "Ripetizioni")]
        public int RipetizioniUt { get; set; }
        [Display(Name = "Peso")]
        public int Peso { get; set; }
        [Display(Name = "Peso")]
        public int PesoUt { get; set; }
        [Display(Name = "Riposo")]
        public int Riposo { get; set; }
        [Display(Name = "Riposo")]
        public int RiposoUt { get; set; }
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }
    }
}