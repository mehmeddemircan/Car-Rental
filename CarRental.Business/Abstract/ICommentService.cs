using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICommentService
    {
        Task<IResult> AddAsync(CommentAddDto entity);


        Task<IDataResult<IEnumerable<CommentDetailDto>>> GetListAsync(Expression<Func<Comment, bool>> filter = null);
        Task<IDataResult<CommentDetailDto>> GetAsync(Expression<Func<Comment, bool>> filter);

        Task<IDataResult<CommentDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<CommentUpdateDto>> UpdateAsync(CommentUpdateDto commentUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
