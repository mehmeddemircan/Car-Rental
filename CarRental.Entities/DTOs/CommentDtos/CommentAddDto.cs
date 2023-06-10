using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CommentDtos
{
    public class CommentAddDto : IDto
    {

        public string Content { get; set; }

        public int CarId { get; set; }

        public int UserId { get; set; }
    }
}
