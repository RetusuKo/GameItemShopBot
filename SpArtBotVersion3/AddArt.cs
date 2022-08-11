using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class AddArt
    {
        //Тут писать новый канал 
        private ulong[] artList = new ulong[]
        {
            994701574007963778, //милое личико
            994701665800290344, //женщина в белом
            995988538011160666, //3-лишний
            995988680726556763, //пчело-чб
            998228190520676413, //Блондинка лиса
            1000098060891861154, //Каштановая чародейка
            1007247445132058655 //Берсерк начало
        };
        public Task AddArtToChanel(string artName, SocketGuildUser user)
        {
            switch (artName)
            {
                case "милое личико":
                    WriteBuyArt(0, user);
                    break;
                case "женщина В Белом":
                    WriteBuyArt(1, user);
                    break;
                case "3 лишний":
                    WriteBuyArt(2, user);
                    break;
                case "пчело чб":
                    WriteBuyArt(3, user);
                    break;
                case "Блондинка лиса":
                    WriteBuyArt(4, user);
                    break;
                    case "Каштановая чародейка":
                    WriteBuyArt(5, user);
                    break;
                    case "Берсерк начало":
                    WriteBuyArt(6, user);
                    break;
                default:
                    Console.WriteLine("Eror");
                    break;
            }
            return Task.CompletedTask;
        }
        private void WriteBuyArt(int artNumber,SocketGuildUser user)
        {
            var art = user.Guild.GetChannel(artList[artNumber]) as IMessageChannel;
            art.SendMessageAsync("Купили ваш арт ");
        }
    }
}
