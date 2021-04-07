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
        public static NetPacket SendToClient(int indexData, int playerId, string data)
        {
            NetPacket packet = NetModule.CreatePacket<SCModule>(sizeof(int) + Encoding.UTF8.GetByteCount(data));

            packet.Writer.Write(indexData);
            packet.Writer.Write(data);

            NetManager.Instance.SendToClient(packet, playerId);
            return packet;
        }

        public static NetPacket SendToClient(TSPlayer player, int indexData, string data)
        {
            return SendToClient(indexData, player.Index, data);
        }

        public static NetPacket SendToClient(TSPlayer player, int indexData, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient(int player, int indexData, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient<T>(TSPlayer player, int indexData) where T : class
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient<T>(int player, int indexData) where T : class
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient(TSPlayer player, int indexData, object t)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(t));
        }
    }
}
