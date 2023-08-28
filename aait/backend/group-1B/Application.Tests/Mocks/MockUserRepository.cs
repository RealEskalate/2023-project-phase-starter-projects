using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{   
    public static class MockUserRepository
    {

        public static Mock<IUserRepository> GetMockUserRepo()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "first",
                    LastName = "last",
                    Bio = "Bio",
                    Username = "username",
                    Followees = new HashSet<Follow>
                    {
                        new Follow {  FollowerId = 1, FolloweeId = 2 },
                        new Follow {  FollowerId = 1, FolloweeId = 3 },

                    },
                    Followers = new HashSet<Follow>
                    {
                        new Follow {FollowerId = 3 , FolloweeId = 1} 
                    }


                }
                ,
                new User
                {
                    Id = 2,
                    FirstName = "first2",
                    LastName = "last2",
                    Bio = "Bio2",
                    Username = "username2",
                }
                ,
                new User
                {
                    Id = 3,
                    FirstName = "first3",
                    LastName = "last3",
                    Bio = "Bio3",
                    Username = "username3",
                }
            };

            var follows = new List<Follow>
            {
                new Follow {  FollowerId = 1, FolloweeId = 2 },
                new Follow {  FollowerId = 1, FolloweeId = 3 },
                new Follow {FollowerId = 3 , FolloweeId = 1}


            };

            var mockUserRepo = new Mock<IUserRepository>();

            mockUserRepo.Setup(repo => repo.Exists(It.IsAny<int>()))
                .ReturnsAsync((int id) => users.Any(u => u.Id == id));  

            mockUserRepo.Setup(repo => repo.FollowUser(It.IsAny<int>() , It.IsAny<int>()))
                .ReturnsAsync((int followerId, int followeeId) =>
                {
                    Console.WriteLine($" {followeeId} &&&&&&& {followerId}");
                    if (follows.FirstOrDefault(f => f.FollowerId == followerId && f.FolloweeId == followeeId) != null )
                    {
                        throw new BadRequestException("already following the user");
                    }

                    if (!users.Any(u => u.Id == followeeId))
                    {
                        throw new NotFoundException("user not found", typeof(User));
                    }

                    follows.Add(new Follow { FollowerId = followerId, FolloweeId = followeeId });

                    return true;
                });

            mockUserRepo.Setup(repo => repo.UnFollowUser(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((int followerId, int followeeId) =>
            {
                var follow = follows.FirstOrDefault<Follow>(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
                if (follow == null)
                {
                    throw new BadRequestException("not following the user");
                }

                follows.Remove(follow);

                return true;
            });

            mockUserRepo.Setup(repo => repo.GetUserDetail(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var user = users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    throw new NotFoundException("user not found", typeof(User));
                }

                return user;
            });


            mockUserRepo.Setup(repo => repo.UpdateUser(It.IsAny<User>())).Callback((User user) =>
            {
                var userToUpdate = users.FirstOrDefault(u => u.Id == user.Id);

                if (userToUpdate == null)
                {
                    throw new BadRequestException("user does not exist");
                }

                userToUpdate.FirstName = user.FirstName;

                userToUpdate.LastName = user.LastName;

                userToUpdate.Bio = user.Bio;


            });

            mockUserRepo.Setup(repo => repo.GetUsers(It.IsAny<int>(), It.IsAny<bool>()))

                .ReturnsAsync((int Id, bool getfollowers) =>
                {
                    var user = users.FirstOrDefault(u => u.Id == Id);
                    if (user == null)
                    {
                        throw new NotFoundException("user not found", typeof(User));

                    }

                    if (getfollowers)
                    {
                        var followers = user.Followers;
                        return users.Where(u => followers.Any(f => f.FollowerId == u.Id)).ToList();
                    }

                    else {
                        var followees = user.Followees;
                        return users.Where(u => followees.Any(f => f.FolloweeId == u.Id)).ToList();
                    }
                });


            return mockUserRepo;

        }
    }
}
