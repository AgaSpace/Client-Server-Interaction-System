using System;
using TShockAPI;
using System.Linq;
using Terraria;
using TerrariaApi;
using TerrariaApi.Server;
using System.Collections.Generic;
using System.Reflection;
using Terraria.Net;

namespace CSIS
{
    [ApiVersion(2, 1)]
    public class CSIS : TerrariaPlugin
    {
        public static Dictionary<string, Action<string, int>> Reader = new Dictionary<string, Action<string, int>>();

        public override string Author => "Zoom L1";
        public override string Name => "CSIS";

        public CSIS(Main main) : base(main) { }

        public override void Initialize() => ServerApi.Hooks.GamePostInitialize.Register(this, PostInitialize);

        public static void PostInitialize(EventArgs args)
        {
            NetManager.Instance._modules.Add(SCModule.Id, new SCModule());
        }
    }
}
