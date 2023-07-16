using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using PcWatcher.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PcWatcher.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string ipaddress;
        private string time;
        private int minutes;
        private int hours;
        private DateTime datatime;
        private string message;
        private Commands commands;
        public Commands Commands { get => commands; set => SetProperty(ref commands, value); }
        public string IpAddress { get => ipaddress; set => SetProperty(ref ipaddress, value); } 
        public string Time { get=> time; set => SetProperty(ref time, value);   }
        public string Message { get => message; set => SetProperty(ref message, value); }
        public int Minutes { get => minutes; set => SetProperty(ref minutes, value); }   
        public int Hours { get => hours; set=> SetProperty(ref hours, value); }  
        public DateTime DataTime { get => datatime; set => SetProperty(ref datatime, value); }
        public AboutViewModel()
        {
            Title = "About";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            SetTimeToNotifyCommand = new Command(SendTimeToNotify);
            SendMessageCommand = new Command(SendMessage);
            CloseWatcherCommand = new Command(CloseWatcher);
            ShutDownCommand = new Command(ShutDown);
            SaveParamsCommand = new Command(SaveParams);
        }

       
        public ICommand SaveParamsCommand { get; }
        public ICommand SetTimeToNotifyCommand { get; }
        public ICommand SendMessageCommand { get; }
        public ICommand CloseWatcherCommand { get; }
        public ICommand ShutDownCommand { get; }


        public async Task OnAppearing()
        {
            await Task.CompletedTask;
            IpAddress = Preferences.Get(nameof(IpAddress),"");
        }
        public async void  SaveParams()
        {
            Preferences.Set(nameof(IpAddress), IpAddress);
        }
        public async void SendTimeToNotify()
        {
            Commands c = new Commands();
            DateTime DTNow = DateTime.Now;
            DateTime DTNext = new DateTime(DTNow.Year, DTNow.Month, DTNow.Day, Hours, Minutes, 0);
            c.Parameter = DTNext.ToString();
            c.Command = 1;
            //IpAddress = "http://192.168.0.106:8888/connection/";
            try
            {
                var response = await RestRequest.SetTime(c, IpAddress);
                Dictionary<string, string> data = new Dictionary<string, string>();
                var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                var result = d.TryGetValue("response", out string value);
                await ShowWarning("Succesfull!", value);
            }
            catch(Exception e)
            {
                await ShowWarning("Error!", e.Message);
            }
        
            

        }
        public async void SendMessage()
        {
            Commands c = new Commands();

            c.Parameter = Message;
            c.Command = 3;
            //IpAddress = "http://192.168.0.106:8888/connection/";
            try
            {
                var response = await RestRequest.SendMessage(c, IpAddress);
                Dictionary<string, string> data = new Dictionary<string, string>();
                var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                var result = d.TryGetValue("response", out string value);
                await ShowWarning("Success!", value);
                Message = String.Empty;
            }
            catch (Exception e)
            {
                await ShowWarning("Error!", e.Message);
            }
           
        }
        public async void CloseWatcher()
        {
            Commands c = new Commands();

            c.Parameter = "";
            c.Command = 4;
            try
            {
                var response = await RestRequest.SendMessage(c, IpAddress);
                Dictionary<string, string> data = new Dictionary<string, string>();
                var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                var result = d.TryGetValue("response", out string value);
                await ShowWarning("Success!", value);
                Message = String.Empty;
            }
            catch (Exception e)
            {
                await ShowWarning("Error!", e.Message);
            }
        }
        public async void ShutDown()
        {

        }
    }
}