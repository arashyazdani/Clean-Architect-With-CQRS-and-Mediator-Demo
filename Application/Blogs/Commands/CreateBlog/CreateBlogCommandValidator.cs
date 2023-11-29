using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required").MaximumLength(200)
                .WithMessage("Name must not exceed 200 characters.");

            RuleFor(v => v.Desctiption).NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.Author).NotEmpty().WithMessage("Author is required.").MinimumLength(20)
                .WithMessage("Author must not exceed 20 characters.");
        }
    }
}
