using Newtonsoft.Json.Linq;
using System.Diagnostics;
using UdpChat.Core.Data.Dto;
using UdpChat.Core.Data.Source;

namespace UdpChat.Services.DataHandlers;
public class DataPacketsHandler
{
    public void HandleCommand(DataPacket dataPacket)
    {
        try
        {
            switch (dataPacket.PacketType)
            {
                case "updateuserinfo":
                    //TODO: properly receive and store user data
                    break;
                case "chats":
                    //TODO: properly receive and store user data
                    break;
                case "chatcontent":
                    //TODO: properly receive and store user data
                    break;
                case "message":
                    //TODO: properly receive and display message
                    break;
                case "createnewchat":
                    break;
                case "adduserstochat":
                    break;
                case "code#confirm":
                    break;
                default:
                    throw new Exception("Unknown command!");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Source} Exception: {ex.Message}");
        }
    }
}
