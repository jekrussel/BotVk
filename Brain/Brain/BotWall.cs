using System;
using VkNet;
using VkNet.Model.RequestParams;

namespace Brain
{
    public class BotWall
    {
        BotSingleton bot = BotSingleton.GetApi();

        /// <summary>
        /// Авторизация и отпавка оповещающего о начале работы бота поста на стену.
        /// </summary>
        public void BotWallPost()
        {
            var post = new WallPostParams();
            post.OwnerId = 358536316;
            post.Message = "BotWall";
            bot.Api.Wall.Post(post);
        }
    }
}
