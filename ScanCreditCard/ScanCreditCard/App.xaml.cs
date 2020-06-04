using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanCreditCard
{
    public partial class App : Application
    {
        public new static App Current;

        public string NumberCard { get; set; }

        public App()
        {
            InitializeComponent();

            Current = this;

            Xamarin.Essentials.Preferences.Set("cartao", false);

            MainPage = new CartaoPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            if(Xamarin.Essentials.Preferences.Get("cartao", true))
            {
                Xamarin.Essentials.Preferences.Set("numberCard", DependencyService.Get<DependeancyServices.ICardService>().GetCardNumber());
                MainPage = new NavigationPage(new CartaoPage());
            }

            Xamarin.Essentials.Preferences.Set("cartao", false);
        })

    }
}
