using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PcWatcher.Models;
namespace PcWatcher.Services
{
    public interface IRestClient
    {
        Task<string> SetTime(Commands commands,string address);
        Task<string> SendMessage(Commands commands, string address);
        Task<string> CloseWatcher(Commands commands, string address);
        Task<string> ShutDown(Commands commands, string address );
    }
}
