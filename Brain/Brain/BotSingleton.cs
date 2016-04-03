using System;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace Brain
{
    /// <summary>
    /// Синглтон для создания единственного экземпляра VkApi. Создает один единственный токен для доступа к методам VkApi и проводит авторизацию.
    /// </summary>
    public class BotSingleton
    {
        private BotSingleton() { }

        private static BotSingleton _instance;
        private static Object _obj = new Object();
        private static VkApi _api;

        /// <summary>
        /// Хранит и инициирует создание/возвращает экземпляр VkApi.
        /// </summary>
        public VkApi Api
        {
            get
            {
                if (_api != null)
                    return _api;

                else {
                    GetApi();
                    return _api;
                }
            }
        }

        /// <summary>
        /// Получение экземпляра VkApi.
        /// </summary>
        public static BotSingleton GetApi()
        {
            if (_api == null)
            {
                lock (_obj)
                {
                    if (_api == null)
                    {
                        _api = new VkApi();
                        _instance = new BotSingleton();
                        Authorize();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Авторизация и отпавка оповещающего поста на стену.
        /// </summary>
        private static void Authorize()
        {
            _api.Authorize(new ApiAuthParams
            {
                ApplicationId = 5393370,
                Login = "a.kolesnikov.official@gmail.com",
                Password = "Rjktcj564236",
                Settings = Settings.All,
            });

            var post = new WallPostParams();
            post.OwnerId = 358536316;
            post.Message = "%26%23128640; Вжжжнннвжжжннн! Полетелииии... \n\n\n(Бот начал работу)";
            _api.Wall.Post(post);
        }
    }
}
