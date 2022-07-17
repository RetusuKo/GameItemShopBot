using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class Info
    {
        public static DiscordSocketClient Client;

        public static string ArtName = "TESTSTART";
        public static string Name = "";
        public static string Price = "";
        public static string Link = "";
        public static bool IsNotForKid = false;

        public readonly ulong _allArtsId = 987609527748800542;
        public readonly ulong _notForKidId = 993425054656368731;
        public readonly ulong _sellId = 987369349432082485;
        public readonly ulong _onSellId = 987627294736666694;
        public readonly ulong _privteSell = 993411306029850644;
        public readonly ulong _updateID = 993891758599581777;
        public readonly ulong _cardBuyId = 993945840710328350;
        public readonly ulong _cashBuyId = 993945867935568013;
        public readonly ulong _artToOrderCaategory = 996128086632448011;

        public readonly Emoji _like = new Emoji("\uD83D\uDC4D");
        public readonly Emote _payForCard = "<:card:993856288490541176>";
        public readonly Emote _payForCash = "<:cash:993856162820784229>";
        public readonly string Token = "OTg3MzY5MDY5NTIxMDIzMDE3.GXnfoy.NGn6wcCEhiIYOBccZ1STwsTYj6irgcG8u60ce4";
    }
}
