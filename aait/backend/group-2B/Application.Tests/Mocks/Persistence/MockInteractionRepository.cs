using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;


namespace SocialSync.Application.Tests.Mocks;

public class MockInteractionRepository
{
    public static Mock<IInteractionRepository> GetMockInteractionRepository()
    {
        var interactions = new List<Interaction>
        {
            new Interaction
            {
                Id = 1,
                PostId = 1,
                UserId = 1,
                Type = InteractionType.Like,
                Body = null,
                CreatedAt = DateTime.Now,
                LastModified = DateTime.Now
            },
            new Interaction
            {
                Id = 1,
                PostId = 1,
                UserId = 1,
                Type = InteractionType.Comment,
                Body = "this is the body",
                CreatedAt = DateTime.Now,
                LastModified = DateTime.Now
            },
            new Interaction
            {
                Id = 2,
                PostId = 2,
                UserId = 2,
                Type = InteractionType.Comment,
                Body = "This is a comment",
                CreatedAt = DateTime.Now,
                LastModified = DateTime.Now
            },
            new Interaction
            {
                Id = 3,
                PostId = 3,
                UserId = 3,
                Type = InteractionType.Comment,
                Body = "This is the second comment",
                CreatedAt = DateTime.Now,
                LastModified = DateTime.Now
            }
        };

        var mockInteractionRepository = new Mock<IInteractionRepository>();


        mockInteractionRepository
            .Setup(repo => repo.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => interactions.FirstOrDefault(u => u.Id == id));
        
        
        mockInteractionRepository
            .Setup(repo => repo.GetAllCommentInteractionsAsync(It.IsAny<int>()))
            .ReturnsAsync((int postId) => interactions.Where(u => u.PostId == postId).ToList());


        mockInteractionRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Interaction>()))
            .ReturnsAsync(
                (Interaction interaction) =>
                {
                    interaction.Id = interactions.Count + 1;
                    interactions.Add(interaction);
                    return interaction;
                }
            );


        mockInteractionRepository
            .Setup(repo => repo.UpdateAsync(It.IsAny<Interaction>()))
            .Callback(
                (Interaction interaction) =>
                {
                    int index = interactions.FindIndex(u => u.Id == interaction.Id);
                    if (index >= 0)
                    {
                        interactions[index] = interaction;
                    }
                }
            );


        mockInteractionRepository
            .Setup(repo => repo.DeleteAsync(It.IsAny<Interaction>()))
            .Callback(
                (Interaction interaction) =>
                {
                    int index = interactions.FindIndex(u => u.Id == interaction.Id);
                    if (index >= 0)
                    {
                        interactions.RemoveAt(index);
                    }
                }
            );

        mockInteractionRepository
            .Setup(repo => repo.LikeUnlikeInteractionAsync(It.IsAny<Interaction>()))
            .ReturnsAsync(
                (Interaction interaction) =>
                {
                    interaction.Id = interactions.Count + 1;
                    interactions.Add(interaction);
                    return interaction;
                }
            );

        return mockInteractionRepository;
    }
}