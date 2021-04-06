using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Terraria.Net;

namespace CSIS
{
    public class SCModule : NetModule
    {
        public const byte Id = 64;

        public override bool Deserialize(BinaryReader reader, int userId)
        {
            return true;
        }
    }
}
