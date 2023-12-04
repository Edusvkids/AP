using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.ProductGamesDTOs
{
    //  DTOs PARA CREAR PRODUCTOS
    public class CreateProductInputDTOs
    {
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "The Title must have at least 5 characters.")]
        public string Moneda { get; set; }

        [Required(ErrorMessage = "The field Tipe is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field price must be greater than 1")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "The field Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field Amount must be greater than 1")]
        public int Total { get; set; }


    }
    public class CreateProductOutputDTOs
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public int Total { get; set; }

    }

    //  DTOs PARA ELIMINAR PRODUCTOS
    public class DeleteProductsInputDTOs
    {
        [Required]
        public int Id { get; set; }
    }

    public class DeleteProductsOutputDTOs
    {
        public bool IsDeleted { get; set; }
    }


    //  DTOs PARA ACTUALIZAR PRODUCTOS
    public class UpdateProductInputDTOs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "The Title must have at least 5 characters.")]
        public string Moneda { get; set; }

        [Required(ErrorMessage = "The field Tipe is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field price must be greater than 1")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "The field Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field Amount must be greater than 1")]
        public int Total { get; set; }


    }


    //  DTOs PARA EDITAR PRODUCTOS
    public class UpdateProductOutputDTOs
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public int Total { get; set; }

    }

    public class GetByIdProductOutputDTO
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public int Total { get; set; }
    }

    //  DTOs PARA BUSCAR PRODUCTOS
    public class getProductsInputDTOs
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public int Total { get; set; }
    }
    public class getProductsOutputDTOs
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public int Total { get; set; }

    }
}
