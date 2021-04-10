// Getting special mention from the server 
// I want to show you my code that I implemented for the TerraZ server. 


using System.IO;
using Terraria.Net;
using Terraria;
using System.Drawing;
using TerrariaPatcher;
using System.Windows.Forms;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IDK
{
    public class SyncServerModule : NetModule
    {
		  private static System.Windows.Forms.NotifyIcon notifyIcon1 = new System.Windows.Forms.NotifyIcon(new System.ComponentModel.Container());
		
        public override bool Deserialize(BinaryReader reader, int userId)
        {
          try 
          {
            string index = reader.ReadString();
            string dataInLine = reader.ReadString();
            Dictionary<string, object> data = null;

            try {
              data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataInLine);
            }
            catch {}


            switch (index)
            {
              case "TextPingData":
              {
                Main.NotifyOfEvent(Terraria.GameContent.GameNotificationType.All);

                notifyIcon1.Icon = new Icon("appicon.ico");
                if (!Main.hasFocus)
                {
                  notifyIcon1.Visible = true;
                  notifyIcon1.ShowBalloonTip(
                    10000, 
                    "You were mentioned on the server by the player "+data["Author"]+" ("+data["AuthorId"]+")", 
                    "Be polite, answer him this ping :) ",
                    ToolTipIcon.Info
                  );
                }
                break;
              }
            }
          }
          catch (Exception ex)
          {
            Main.NewText(ex.ToString(), 255);
          }
			
          return false;
        }
    }
}
