using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;

namespace SpBotSell
{
    class Start
    {
        private Reaction _reaction = new Reaction();
        private Info _info = new Info();
        private ChechName _chechName = new ChechName();
        static void Main(string[] args)
            => new Start().MainAsyns(args).GetAwaiter().GetResult();
        private async Task MainAsyns(string[] args)
        {
            Info.Client = new DiscordSocketClient();

            await Action();

            var token = _info.Token;

            await Info.Client.LoginAsync(TokenType.Bot, token);
            await Info.Client.StartAsync();

            CreateHostBuilder(args).Build().Run();
            Console.ReadLine();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        private Task Action()
        {
            Info.Client.MessageReceived += WriteEmote;
            Info.Client.MessageReceived += ComaandsHendler;
            Info.Client.ReactionAdded += _reaction.HandleReaction;

            return Task.CompletedTask;
        }
        private Task WriteEmote(SocketMessage arg)
        {
            if (!arg.Author.IsBot)
            {
                if (arg.Channel.Id == _info._onSellId)
                {
                    arg.AddReactionAsync(_info._like);
                }
            }
            if (arg.Channel.Id == _info._allArtsId || arg.Channel.Id == _info._notForKidId)
            {
                arg.AddReactionAsync(_info._payForCard);
                arg.AddReactionAsync(_info._payForCash);
            }
            if (arg.Channel.Id == _info._onSellId)
            {
                arg.AddReactionAsync(_info._like);
            }
            return Task.CompletedTask;
        }
        private Task ComaandsHendler(SocketMessage arg)
        {
            var privateSell = Info.Client.GetChannel(_info._privteSell) as IMessageChannel;
            var onSell = Info.Client.GetChannel(_info._onSellId) as IMessageChannel;

            if (!arg.Author.IsBot)
            {
                string name = Info.ArtName;
                Info.ArtName = "";
                string cordinate = arg.ToString();
                if (arg.Channel.Id == _info._sellId)
                {
                    arg.Channel.SendMessageAsync("Ваш арт пришел на проверку, это может занять время");
                }
                if (arg.Channel.Id == _info._cardBuyId)
                {
                    string mesage = $"Чел под ником {arg.Author} хочет купить |{name}| и оплатить <Картой>, товар привести  надо на {cordinate}";
                    name = "";
                    cordinate = "";
                    onSell.SendMessageAsync(mesage);
                }
                if (arg.Channel.Id == _info._cashBuyId)
                {
                    string mesage = $"Чел под ником {arg.Author} хочет купить |{name}| и оплатить <Наличкой> , товар привести  надо на {cordinate}";
                    name = "";
                    cordinate = "";
                    onSell.SendMessageAsync(mesage);
                }
                if (arg.Channel == privateSell)
                {
                    var allArts = Info.Client.GetChannel(_info._allArtsId) as IMessageChannel;
                    var notForKids = Info.Client.GetChannel(_info._notForKidId) as IMessageChannel;
                    _chechName.SeeNameAndPrice(arg);
                    if (Info.IsNotForKid)
                    {
                        notForKids.SendMessageAsync($"Названия арта {Info.Name} Цена арта {Info.Price} {Info.Link} 18+");
                    }
                    else
                    {
                        allArts.SendMessageAsync($"Названия арта {Info.Name} Цена арта {Info.Price} {Info.Link}");
                    }
                    Info.Name = "";
                    Info.Price = "";
                    Info.Link = "";
                }
            }
            return Task.CompletedTask;
        }
    }
}