using App.Repositories.Products;
using FluentValidation;

namespace App.Services.Products.Create
{
	public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
	{
		private readonly IProductRepository _productRepository;
		public CreateProductRequestValidator(IProductRepository productRepository)
		{
			RuleFor(x => x.Name)
				.NotNull().WithMessage("Ürün ismi gereklidir.")
				.NotEmpty().WithMessage("Ürün ismi gereklidir.")
				.Length(3, 100).WithMessage("Ürün ismi 3 ile 100 karakter arasında olmalıdır.");
				//.Must(MustUniqueProductName).WithMessage("Ürün ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");

			//price validator
			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

			//stock validator
			RuleFor(x => x.Stock)
				.InclusiveBetween(1, 100).WithMessage("Stok 1 ile 100 arasında olmalıdır.");
			_productRepository = productRepository;
		}


		#region sync validation
		//private bool MustUniqueProductName(string name)
		//{
		//	return !_productRepository.Where(x => x.Name == name).Any();

		//}
		#endregion

	}
}
