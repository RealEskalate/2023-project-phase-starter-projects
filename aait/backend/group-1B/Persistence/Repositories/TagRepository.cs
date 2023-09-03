// using Application.Contracts.Persistence;
// using Application.DTOs.Posts;
// using AutoMapper;
// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace Persistence.Repositories;

// public class TagRepository : GenericRepository<Tag>, ITagRepository
// {
//     private readonly SocialSyncDbContext _context;

//     public TagRepository(SocialSyncDbContext context) : base(context)
//     {
//         _context = context;
//     }

//     public async Task AddTag(TagNameDto tagNameDto)
//     {
//         if(ExistsByTagName(tagNameDto.TagName) == Task.FromResult(false)){
//             var tag = new Tag(){
//                 TagName = tagNameDto.TagName
//             };
//             await _context.Tags.AddAsync(tag);
//         }
//     }


//     public async Task<bool> ExistsByTagName(string tagName)
//     {
//         var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
//         return tag != null;
//     }

//     public async Task<Tag> GetByTagName(string tagName)
//     {
//         var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
//         return tag;
//     }
// }