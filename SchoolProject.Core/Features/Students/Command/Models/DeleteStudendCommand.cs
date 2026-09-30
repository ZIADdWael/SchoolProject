using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Command.Models
{
    public class DeleteStudendCommand:IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteStudendCommand(int id)
        {
         Id=id;   
        }
    }
}
