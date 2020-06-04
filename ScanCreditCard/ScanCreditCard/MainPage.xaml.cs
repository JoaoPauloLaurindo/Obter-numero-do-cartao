using ScanCreditCard.DependeancyServices;
using ScanCreditCard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanCreditCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel ViewModel { get => BindingContext as MainPageViewModel; }
        public MainPage(string value)
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();

            numberTxt.Text = value;
        }
    }
}
