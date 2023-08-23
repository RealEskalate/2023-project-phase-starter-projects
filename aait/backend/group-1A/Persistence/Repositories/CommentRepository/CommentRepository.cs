using Application.Contracts;
using Application.DTO.CommentDTOS.DTO;
using Application.Features.CommentFeatures.Requests.Commands;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public CommentRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comment>> GetCommentsForPostAsync(int postId)
        {
            return await _dbContext.Comments
                .Where(comment => comment.PostId == postId)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByUserAsync(int userId)
        {
            return await _dbContext.Comments
                .Where(comment => comment.UserId == userId)
                .ToListAsync();
        }

        Task<CommentDTO> ICommentRepository.GetCommentByIdAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        Task<List<CommentDTO>> ICommentRepository.GetAllCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteCommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCommentAsync(CommentUpdateCommand request)
        {
            throw new NotImplementedException();
        }

        // Implement other methods defined in ICommentRepository
    }
}
