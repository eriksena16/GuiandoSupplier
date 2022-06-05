using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GuiandoSupplier.Domain.Entities
{
    public class SupplierDTQ : BaseEntity
    {
        [Required(ErrorMessage = "O campo empresa é obrigatório.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Link para Login")]
        [DataType(DataType.Url)]
        public string LinkLogin { get; set; }
        [Display(Name = "Fornecedor mantem historico?")]
        public bool Historic { get; set; }
        [Display(Name = "Logo do fornecedor")]
        public IFormFile FileLogo { get; set; }
        [Display(Name = "Verticais")]
        public Verticals Verticals { get; set; }
    }
}
