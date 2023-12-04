using HGAPI.DTOs.ProductGamesDTOs;
using HGAPI.Interface;
using HGAPI.InterfaceBL;
using HGAPI.Models.DAL;
using HGAPI.Models.EN;
using Stripe;

namespace HGAPI.BL
{
    public class ProductGameBL : IProductBL
    {
        readonly IProduct _productDAL;
        readonly IUnitOfWork _unitWork;

        public ProductGameBL(IProduct productDAL, IUnitOfWork unitOfWork)
        {
            _productDAL = productDAL;
            _unitWork = unitOfWork;
        }

        public async Task<CreateProductOutputDTOs> Create(CreateProductInputDTOs pProducts)
        {
            ProductGames newProduct = new ProductGames()
            {
                Moneda = pProducts.Moneda,
                Precio = pProducts.Precio,
                Total = pProducts.Total
            };

            _productDAL.Create(newProduct);
            await _unitWork.SaveChangesAsync();
            CreateProductOutputDTOs productsOutput = new CreateProductOutputDTOs()
            {
                Id = newProduct.Id,
                Moneda = newProduct.Moneda,
                Precio = newProduct.Precio,
                Total = newProduct.Total

            };
            return productsOutput;
        }

        public async Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts)
        {
            ProductGames productToDelete = await _productDAL.GetById(new ProductGames { Id = pProducts.Id });

            if (productToDelete != null)
            {
                _productDAL.Delete(productToDelete);
                await _unitWork.SaveChangesAsync();
            }

            return new DeleteProductsOutputDTOs { IsDeleted = true };
        }

        public async Task<GetByIdProductOutputDTO> GetById(int id)
        {
            ProductGames product = await _productDAL.GetById(new ProductGames { Id = id });
            return new GetByIdProductOutputDTO
            {
                Id = product.Id,
                Moneda = product.Moneda,
            };
        }

        public async Task<List<getProductsOutputDTOs>> Search(getProductsInputDTOs pProducts)
        {
            List<ProductGames> products = await _productDAL.Search(pProducts);

            List<getProductsOutputDTOs> list = new List<getProductsOutputDTOs>();
            products.ForEach(p => list.Add(new getProductsOutputDTOs
            {
                Id = p.Id,
                Moneda = p.Moneda,
                Precio = p.Precio,
                Total = p.Total
            }));
            return list;

        }

        public async Task<UpdateProductOutputDTOs> Update(UpdateProductInputDTOs pProducts)
        {
            ProductGames productUpdate = await _productDAL.GetById(pProducts.Id);

            if (productUpdate.Id == pProducts.Id)
            {
                productUpdate.Moneda = pProducts.Moneda;
                productUpdate.Precio = pProducts.Precio;
                productUpdate.Total = pProducts.Total;

                _productDAL.Update(productUpdate);

                await _unitWork.SaveChangesAsync();

                UpdateProductOutputDTOs product = new UpdateProductOutputDTOs()
                {
                    Id = productUpdate.Id,
                    Moneda = productUpdate.Moneda,
                    Precio = productUpdate.Precio,
                    Total = productUpdate.Total
                };
                return product;
            }

            throw new Exception($"The product with id: {pProducts.Id} not found");

        }
    }
}
