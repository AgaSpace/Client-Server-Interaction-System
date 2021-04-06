using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Terraria.Net;
using TShockAPI;

namespace CSIS
{
    public static class Controller
    {
        public static NetPacket SendToClient(int playerId, string data)
        {
            NetPacket packet = NetModule.CreatePacket<SCModule>(sizeof(int) + Encoding.UTF8.GetByteCount(data));

            packet.Writer.Write(playerId);
            packet.Writer.Write(data);

            NetManager.Instance.SendToClient(packet, playerId);
            return packet;
        }

        public static NetPacket SendToClient(TSPlayer player, string data)
        {
            return SendToClient(player.Index, data);
        }

        public static NetPacket SendToClient(TSPlayer player, Dictionary<string, object> data)
        {
            return SendToClient(player.Index, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient(int player, Dictionary<string, object> data)
        {
            return SendToClient(player, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient<T>(TSPlayer player) where T : class
        {
            return SendToClient(player.Index, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient<T>(int player) where T : class
        {
            return SendToClient(player, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }
    }
}
