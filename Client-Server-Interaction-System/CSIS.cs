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
    public class MainPlugin : TerrariaPlugin
    {
        public override string Author => "Zoom L1";
        public override string Name => "CSIS";

        public MainPlugin(Main main) : base(main) { }

        public override void Initialize() => ServerApi.Hooks.GamePostInitialize.Register(this, PostInitialize);

        public static void PostInitialize(EventArgs args)
        {
            NetManager.Instance._modules.Add(SCModule.Id, new SCModule());
        }
    }
}
