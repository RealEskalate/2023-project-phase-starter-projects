using MediatR;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IPostRepository : IGenericRepository<Interaction> { }
