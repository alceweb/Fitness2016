using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FitnessMVC.Models
{
    // È possibile aggiungere dati di profilo dell'utente specificando altre proprietà della classe ApplicationUser. Per ulteriori informazioni, visitare http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

    public class Schede
    {
        [Key]
        public int Id {get;set;}
        [Display(Name = "Titolo scheda")]
        public string Nome { get; set; }
        public string User_Id { get; set; }
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }
    }

    public class Allenamenti
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Giorno")]
        public int Numero { get; set; }
        public int Scheda_Id { get; set; }
        [Display(Name ="Gruppo muscolare")]
        public string GruppoMuscolare { get; set; }
        public int Esercizio_Id { get; set; }
        public virtual Esercizi Esercizio { get; set; }
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

    public class Esercizi
    {
        [Key]
        public int Esercizio_Id { get; set; }
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }
        public virtual ICollection<Allenamenti> Allenamentis { get; set; }
    }
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<FitnessMVC.Models.Schede> Schedes { get; set; }
        public DbSet<FitnessMVC.Models.Allenamenti> Allenamentis { get; set; }
        public DbSet<FitnessMVC.Models.Esercizi> Esercizis { get; set; }
        public DbSet<FitnessMVC.Models.Product> Products { get; set; }
        public DbSet<FitnessMVC.Models.Category> Categorys { get; set; }
    }
}