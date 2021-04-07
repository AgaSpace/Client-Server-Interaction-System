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
        public static NetPacket SendToClient(string index, int playerId, string data)
        {
            NetPacket packet = NetModule.CreatePacket<SCModule>(Encoding.UTF8.GetByteCount(index) + Encoding.UTF8.GetByteCount(data));

            packet.Writer.Write(index);
            packet.Writer.Write(data);

            NetManager.Instance.SendToClient(packet, playerId);
            return packet;
        }

        #region one
        public static NetPacket SendToClient(TSPlayer player, string indexData, string data)
        {
            return SendToClient(indexData, player.Index, data);
        }

        public static NetPacket SendToClient(TSPlayer player, string indexData, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient(int player, string indexData, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient<T>(TSPlayer player, string indexData) where T : class
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient<T>(int player, string indexData) where T : class
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient(TSPlayer player, string indexData, object t)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(t));
        }
        #endregion

        #region two
        public static NetPacket SendToClient(string indexData, TSPlayer player, object t)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(t));
        }

        public static NetPacket SendToClient(string indexData, TSPlayer player, string data)
        {
            return SendToClient(indexData, player.Index, data);
        }

        public static NetPacket SendToClient(string indexData, TSPlayer player, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient(string indexData, int player, Dictionary<string, object> data)
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(data));
        }

        public static NetPacket SendToClient<T>(string indexData, TSPlayer player) where T : class
        {
            return SendToClient(indexData, player.Index, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }

        public static NetPacket SendToClient<T>(string indexData, int player) where T : class
        {
            return SendToClient(indexData, player, JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
        }
        #endregion
    }
}
