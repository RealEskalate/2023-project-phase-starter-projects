using Application.Contracts;
using Application.DTO.CommentReactionDTOS.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReactionRepositories
{
    public class CommentReactionRepository : ICommentReactionRepository
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentReactionRepository(SocialMediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CommentReaction>> GetReactionsForCommentAsync(int commentId)
        {
            return await _dbContext.CommentReaction
                .Where(reaction => reaction.CommentId == commentId)
                .ToListAsync();
        }

        public async Task<List<CommentReaction>> GetReactionsByUserAsync(int userId)
        {
            return await _dbContext.CommentReaction
                .Where(reaction => reaction.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<CommentReaction>> GetAll(Expression<Func<CommentReaction, bool>> predicate)
        {
            return await _dbContext.CommentReaction
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<CommentReaction> Add(CommentReaction entity)
        {
            await _dbContext.CommentReaction.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(CommentReaction entity)
        {
            _dbContext.CommentReaction.Remove(entity);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> Exists(int id)
        {
            return await _dbContext.CommentReaction.AnyAsync(reaction => reaction.Id == id);
        }

        public async Task<CommentReaction> Update(CommentReaction entity)
        {
            _dbContext.CommentReaction.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CommentReaction> GetCommentReactionByIdAsync(int id)
        {
            return await _dbContext.CommentReaction.FindAsync(id);
        }

        public async Task AddCommentReactionAsync(CommentReaction commentReaction)
        {
            await _dbContext.CommentReaction.AddAsync(commentReaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCommentReactionAsync(CommentReaction commentReaction)
        {
            _dbContext.CommentReaction.Update(commentReaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCommentReactionAsync(int id)
        {
            var commentReaction = await _dbContext.CommentReaction.FindAsync(id);
            if (commentReaction != null)
            {
                _dbContext.CommentReaction.Remove(commentReaction);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CommentReactionDTO>> GetAllCommentReactionsAsync()
        {
            var commentReactions = await _dbContext.CommentReaction.ToListAsync();
            var commentReactionDTOs = _mapper.Map<List<CommentReactionDTO>>(commentReactions);
            return commentReactionDTOs;
        }
    }
}
