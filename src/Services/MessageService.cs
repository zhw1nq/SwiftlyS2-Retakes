using System;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Players;
using SwiftlyS2_Retakes.Interfaces;

namespace SwiftlyS2_Retakes.Services;

public sealed class MessageService : IMessageService
{
  private readonly ISwiftlyCore _core;

  public MessageService(ISwiftlyCore core)
  {
    _core = core;
  }

  public string FormatChat(string message)
  {
    if (string.IsNullOrWhiteSpace(message)) return message;
    return message.Colored();
  }

  public void Chat(IPlayer player, string message)
  {
    if (player is null || !player.IsValid || string.IsNullOrEmpty(message)) return;

    player.SendMessage(MessageType.Chat, FormatForPlayer(player, message));
  }

  public void BroadcastChat(string message)
  {
    if (string.IsNullOrEmpty(message)) return;

    foreach (var player in _core.PlayerManager.GetAllPlayers())
    {
      if (player is null || !player.IsValid) continue;
      player.SendMessage(MessageType.Chat, FormatForPlayer(player, message));
    }
  }

  private string FormatForPlayer(IPlayer player, string line)
  {
    if (string.IsNullOrWhiteSpace(line)) return " ";

    var loc = _core.Translation.GetPlayerLocalizer(player);
    var prefix = loc["chat.prefix"];

    var trimmed = line.Trim();
    if (string.IsNullOrEmpty(prefix) || prefix == "{0}" || trimmed.StartsWith("--") || trimmed.StartsWith("-->") || trimmed.StartsWith("[grey]--") || trimmed.StartsWith("[grey]-->") || trimmed.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
    {
      return line.Colored();
    }

    return $"{prefix}{line}".Colored();
  }
}
