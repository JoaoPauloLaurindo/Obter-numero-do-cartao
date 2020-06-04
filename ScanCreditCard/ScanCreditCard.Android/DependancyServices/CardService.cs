using Android.App;
using Android.Content;

using Card.IO;
using Java.Lang;
using ScanCreditCard.DependeancyServices;
using ScanCreditCard.Droid;
using ScanCreditCard.Droid.DependancyServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CardService))]
namespace ScanCreditCard.Droid.DependancyServices
{
    public class CardService : ICardService
    {
        private Activity activity;

        [System.Obsolete]
        public void StartCapture()
        {
            InitCardService();

            var intent = new Intent(activity, typeof(CardIOActivity));
            intent.PutExtra(CardIOActivity.ExtraReturnCardImage, false);
            intent.PutExtra(CardIOActivity.ExtraSuppressScan, false);
            intent.PutExtra(CardIOActivity.ExtraSuppressManualEntry, false);
            intent.PutExtra(CardIOActivity.ExtraSuppressConfirmation, false);

            activity.StartActivityForResult(intent, 101);
        }

        public string GetCardholderName()
        {
            return (InfoShareHelper.Instance.CardInfo != null) ? InfoShareHelper.Instance.CardInfo.CardholderName : null;
        }

        public string GetCardNumber()
        {
            return (InfoShareHelper.Instance.CardInfo != null) ? InfoShareHelper.Instance.CardInfo.CardNumber : null;
        }

        public string GetCvv()
        {
            return (InfoShareHelper.Instance.CardInfo != null) ? InfoShareHelper.Instance.CardInfo.Cvv : null;
        }
        public string GetValidateMonth()
        {
            return InfoShareHelper.Instance.CardInfo?.ExpiryMonth.ToString();
        }

        public string GetValidateYear()
        {
            return InfoShareHelper.Instance.CardInfo.ExpiryYear.ToString();
        }

        [System.Obsolete]
        private void InitCardService()
        {
            var context = Forms.Context;
            activity = context as Activity;
        }

    }

    public class InfoShareHelper
    {
        private static InfoShareHelper instance = null;
        private static readonly object padlock = new object();

        public CreditCard CardInfo { get; set; }

        public static InfoShareHelper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new InfoShareHelper();
                    }

                    return instance;
                }
            }
        }
    }
}