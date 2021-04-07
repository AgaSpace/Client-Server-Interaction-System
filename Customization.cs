//To begin with, you must in some way implement into the client NetModule with index 11.
//I implemented it like this: I made the fields public and wrote the following: 

public void OnGameInitialize() // Main.Initialize() { ...; OnGameInitialize(); this.LoadContent_TryEnteringHiDef(); this.ClientInitialize(); base.Initialize(); }
{
	NetManager.Instance._modules.Add(11, new Demovers.SyncServerModule());
}

/*
Yes, I forgot to mention, we need a class that refers to NetModule 
*/

public class SyncServerModule : NetModule
{
	public override bool Deserialize(BinaryReader reader, int userId)
	{
		string index = reader.ReadString();
		Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(reader.ReadString());
		// The plugin sends us two strings, one of which is an index (index), and the second is data in the json format (data)
		
		switch (index)
		/*
			Now we need to find out the indexes sent from the server.
			As an example, I will take a plugin for mentioning a user in a chat. 
		*/
		{
			case "TextPingData": // The server can come up with any index. 
			{
				Main.NotifyOfEvent(Terraria.GameContent.GameNotificationType.All); // If the game is closed, we will get a mention on the game icon. 
				break;
			}
		}
		
		return false;
	}
}