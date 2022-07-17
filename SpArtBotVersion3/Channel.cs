using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class Channel
    {
        private Role _role = new Role();
        public async Task CreateOrderChanel(SocketGuildUser user)
        {
            string textChannelName = user.Username;
            var newChannel = await user.Guild.CreateTextChannelAsync(textChannelName, id => id.CategoryId = 996125516476207185);
            var channel = newChannel as IMessageChannel;
            await _role.CreateRole(user, newChannel);
            await MentionInCreateChanel(user, channel);
        }
        public async Task MentionInCreateChanel(SocketGuildUser user, IMessageChannel chanel)
        {
            await chanel.SendMessageAsync($"{user.Mention} Добрый  день, скоро с вами свяжеться художник, который сделает ваш арт.");
            await chanel.SendMessageAsync($"Пока вы можете отправить тут картинку арта который для вас сделает художник, подробности расскажет художник. Если есть вопросы  пишите сюда, приятного вам дня {user.Username}");
            //await chanel.SendMessageAsync(MentionUtils.MentionRole(996424312615616542));
        }
    }
}
