using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CommentDtos
{
    public class CommentDetailDto : IDto
    {

        public int Id { get; set; }

        public string Content { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
