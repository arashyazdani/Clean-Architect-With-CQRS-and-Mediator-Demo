using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlogEntity = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Desctiption = request.Desctiption,
                Author = request.Author
            };

            return await _blogRepository.UpdateAsync(request.Id, updateBlogEntity);
        }
    }
}
