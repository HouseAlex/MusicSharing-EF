﻿using MusicSharing.Business.Models;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Data.entities;

namespace MusicSharing.Business.Services
{
    /// <summary>
    /// This class implements the post   service and provides methods for obtaining post information.
    /// </summary>
    public class PostService : IPostService
    {
        private readonly IMusicSharingContext context;

        public PostService(IMusicSharingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the post based on the identifier.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns>The post object.</returns>
        public async Task<PostDto> GetPostInformation(string postId)
        {
            return await GetPostInformation(postId);
        }

        /// <summary>
        /// Gets the post feed for the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A list of posts.</returns>
        public async Task<IEnumerable<PostDto>> GetPostFeed(int userId)
        {
            return await context.GetPostFeedForUser(userId);
        }

        /// <summary>
        /// Grabs all the post titles within our application.
        /// </summary>
        /// <returns>A list of postTitles.</returns>
        public async Task<IEnumerable<string>> GetPostTitles()
        {
            var postTitles = await context.GetPostTitles();

            return postTitles;
        }

        /// <summary>
        /// Generates a new post for our application.
        /// </summary>
        /// <param name="payload">A payload of the new user user's information.</param>
        /// <returns>An empty task.</returns>
        public async Task<PostDto> CreatePost(PostCreatePayload payload)
        {
            var newPost = Post.Create(
                payload.ArtistName,
                payload.Caption,
                payload.ImageUrl,
                payload.SpotifyId,
                payload.SpotifyUrl,
                payload.TrackName,
                payload.UserId);

            var obj = await context.AddPost(newPost) ?? throw new Exception();

            return new PostDto
            {
                ArtistName = obj.ArtistName,
                Caption = obj.Caption,
                CreatedOn = obj.CreatedOn,
                Comments = null,
                Id = obj.Id,
                ImageUrl = obj.ImageUrl,
                IsLikedByUser = false,
                LikeTotal = 0,
                SpotifyId = obj.SpotifyId,
                SpotifyUrl = obj.SpotifyUrl,
                TrackName = obj.TrackName,
                UserId = obj.UserId,
                UserName = obj.User!.Name
            };
        }

        /// <summary>
        /// Generates a new comment for our application.
        /// </summary>
        /// <param name="payload">A payload of the new user user's information.</param>
        /// <returns>An empty task.</returns>
        public async Task CreateComment(CommentCreatePayload payload)
        {
            var newComment = PostComment.Create(payload.Comment, payload.PostId, payload.UserId);
            await context.AddComment(newComment);
        }

        /// <summary>
        /// Lets a user like/unlike a post.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="isLiked">A value indicating if the user has </param>
        /// <returns>A boolean indicating liked.</returns>
        public async Task<bool> LikePost(int postId, int userId, bool isLiked)
        {
            if (isLiked)
            {
                var postLike = PostLike.Create(postId, userId);
                await context.AddPostLike(postLike);

                return true;
            }
            else
            {
                var postLike = await context.GetPostLike(postId, userId) ?? throw new Exception("Unable to find post like object.");
                postLike.Delete();
                await context.SaveChangesAsync();

                return false;
            }
        }
    }
}
