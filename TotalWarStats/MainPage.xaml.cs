using System;
using System.Collections.Generic;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Business.Services;
using TotalWarStats.Model.Entities;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TotalWarStats
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            IMatchService matchService = new MatchService();
            IList<Match> matches = matchService.GetAllMatchesAsync().Result;
            Match match = matches[0];
            matchService.DeleteMatchAsync(match.MatchId).Wait();
            matches = matchService.GetAllMatchesAsync().Result;
            DisplayDataDialog(matches.Count);

        }

        private async void DisplayDataDialog(int count)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "MATCHES IN DB",
                Content = count + "",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }
    }
}
