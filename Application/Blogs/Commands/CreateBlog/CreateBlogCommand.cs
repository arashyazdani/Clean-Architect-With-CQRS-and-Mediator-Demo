using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand: IRequest<BlogVm>
    {
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public string Author { get; set; }
    }
}
