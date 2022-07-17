using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class Reaction
    {
        private Info _info = new Info();
        private ChechName _chechName = new ChechName();
        private AddArt _addArt = new AddArt();
        private Channel _channel = new Channel(); 
        public async Task HandleReaction(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> channel, SocketReaction reaction)
        {
            SocketGuildUser user = (SocketGuildUser)reaction.User;
            var cardBuy = user.Guild.GetChannel(_info._cardBuyId) as IMessageChannel;
            var cashBuy = user.Guild.GetChannel(_info._cashBuyId) as IMessageChannel;
            if (!user.Guild.GetUser(reaction.UserId).IsBot && channel.Id != _info._updateID)
            {
                var msg = await message.GetOrDownloadAsync();
                var messageString = msg.ToString();
                if (channel.Id == _info._allArtsId || channel.Id == _info._notForKidId)
                {
                    if (reaction.Emote.Name == _info._payForCash.Name)
                    {
                        await _chechName.SeeName(messageString);
                        await cashBuy.SendMessageAsync($"{user.Mention} Вы выбрали наличные ары вам надо, положить в сундук где вы поставили карту столько ар сколько стоит арт");
                    }
                    if (reaction.Emote.Name == _info._payForCard.Name)
                    {
                        await _chechName.SeeName(messageString);
                        await cardBuy.SendMessageAsync($"{user.Mention} Вы выбрали карту вам надо, отправить столько ар сколько стоит арт на карту под номером 66610");
                    }
                }
                if (channel.Id == _info._onSellId)
                {
                    if (reaction.Emote.Name == _info._like.Name)
                    {
                        await _addArt.AddArtToChanel(_chechName.AceptArtName(messageString), user);
                    }
                }
                if (channel.Id == _info._artToOrderCaategory)
                {
                    if (reaction.Emote.Name == _info._like.Name)
                    {
                        await _channel.CreateOrderChanel(user);
                    }
                }
            }
        }
    }
}
