using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class Role
    {
        public async Task CreateRole(SocketGuildUser user, Discord.Rest.RestTextChannel channel)
        {
            //var newChannel = user.Guild.GetChannel(channel.Id);
            var uRole = await user.Guild.CreateRoleAsync(user.Username, GuildPermissions.None, Color.DarkTeal, false);
            await user.AddRoleAsync(uRole);
            await channel.AddPermissionOverwriteAsync(uRole,
                OverwritePermissions.DenyAll(channel).Modify(
                    viewChannel: PermValue.Allow, readMessageHistory: PermValue.Allow, sendMessages: PermValue.Allow, attachFiles: PermValue.Allow)
                );
        }
    }
}
