using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin2Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        public SMSPage()
        {
            InitializeComponent();
            buttonSend.Clicked += ButtonSend_Clicked;
        }

        private async void ButtonSend_Clicked(object sender, EventArgs e)
        {
            var recipient = entryRecipient.Text;
            var messageText = entryMessage.Text;
            await SendSms(messageText, recipient);
        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Error","SMS is not supported on this device!","OK", "CANCEL");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error has occured. Try again later!", "OK", "CANCEL");
            }
        }
    }
}