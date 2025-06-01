using FluentValidation;

namespace App.Services.Products.Update
{
	public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequest>
	{
		public UpdateProductRequestValidator()
		{
			RuleFor(x => x.Name)
					.NotNull().WithMessage("Ürün ismi gereklidir.")
					.NotEmpty().WithMessage("Ürün ismi gereklidir.")
					.Length(3, 100).WithMessage("Ürün ismi 3 ile 100 karakter arasında olmalıdır.");

			//price validator
			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

			//category validator
			RuleFor(x => x.CategoryId)
				.GreaterThan(0).WithMessage("Kategori ID'si 0'dan büyük olmalıdır.");

			//stock validator
			RuleFor(x => x.Stock)
				.InclusiveBetween(1, 100).WithMessage("Stok 1 ile 100 arasında olmalıdır.");
		}

	}
}
