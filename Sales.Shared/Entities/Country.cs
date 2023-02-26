using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    //Entidad country, tabla en BD
    public class Country
    {
        public int Id { get; set; } //identificador unico del Pais/Country

        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //campo name obligatorio en {0} se coloca name, pero como definique es pais, sale pais
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")] //cantidad de caracteres, en caso de error {1} se reemplaza por 100
        [Display(Name = "País")] // nombre que se vializa en la intefaz de usuario
        public string Name { get; set; } = null!; //nombre del pais(debe ser diferente de null)
    }
}
