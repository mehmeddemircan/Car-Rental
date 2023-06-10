using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Validation.FluentValidation;
using CarRental.Core.Aspects.Validation;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentRepository _commentRepository;
        IUserRepository _userRepository;
        ICarRepository _carRepository; 
        IMapper _mapper; 
        public CommentManager(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository, ICarRepository carRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }
        [ValidationAspect(typeof(CommentValidator))]
        public async Task<IResult> AddAsync(CommentAddDto entity)
        {
            var newComment = _mapper.Map<Comment>(entity);

            newComment.CreatedDate = DateTime.Now; 


            await _commentRepository.AddAsync(newComment);
           

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _commentRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CommentDetailDto>> GetAsync(Expression<Func<Comment, bool>> filter)
        {
            var comment = await _commentRepository.GetAsync(filter);
            if (comment != null)
            {
                var commentDto = await AssignCommentDetails(comment, comment.UserId);
                return new SuccessDataResult<CommentDetailDto>(commentDto, Messages.Listed);

            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CommentDetailDto>> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetAsync(x => x.Id == id);
            if (comment != null)
            {
                var commentDto = await AssignCommentDetails(comment,comment.UserId);
                return new SuccessDataResult<CommentDetailDto>(commentDto, Messages.Listed);

            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CommentDetailDto>>> GetListAsync(Expression<Func<Comment, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _commentRepository.GetListAsync();
                var responseCommentDetailDto = _mapper.Map<IEnumerable<CommentDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentDetailDto>>(responseCommentDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _commentRepository.GetListAsync(filter);
                var responseCommentDetailDto = _mapper.Map<IEnumerable<CommentDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentDetailDto>>(responseCommentDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CommentUpdateDto>> UpdateAsync(CommentUpdateDto commentUpdateDto)
        {
            var getComment = await _commentRepository.GetAsync(x => x.Id == commentUpdateDto.Id);

            var comment = _mapper.Map<Comment>(commentUpdateDto);


            comment.UpdatedDate = DateTime.Now;
            comment.UpdatedBy = 1;


            var brandUpdate = await _commentRepository.UpdateAsync(comment);
            var resultUpdateDto = _mapper.Map<CommentUpdateDto>(brandUpdate);

            return new SuccessDataResult<CommentUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        private async Task<CommentDetailDto> AssignCommentDetails(Comment comment, int userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
  
            if (user == null )
            {
                return null;
            }

            comment.User = user; 
          
            var commentDetail = _mapper.Map<CommentDetailDto>(comment);
            return commentDetail;
        }
    }
}
