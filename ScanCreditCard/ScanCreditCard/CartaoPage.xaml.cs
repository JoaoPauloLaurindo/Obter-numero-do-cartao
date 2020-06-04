using ScanCreditCard.DependeancyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanCreditCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartaoPage : ContentPage
    {
        public string NumberCard { get; set; }


        public CartaoPage()
        {
            InitializeComponent();
            numberTxt.Text = Xamarin.Essentials.Preferences.Get("numberCard", "");
        }

        private void btnScanCard_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.Preferences.Set("cartao", true);

            DependencyService.Get<ICardService>().StartCapture();
            //var cartao = Task.Run(() => DependencyService.Get<ICardService>().GetCardNumber());
            //numberTxt.Text = cartao.Result;
        }

        //protected void OnAppearing()
        //{
        //    base.OnAppearing();
        //}
    }
}