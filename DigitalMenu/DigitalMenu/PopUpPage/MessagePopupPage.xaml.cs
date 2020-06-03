using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalMenu.PopUpPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePopupPage : PopupPage
    {
        public MessagePopupPage()
        {
            InitializeComponent();
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {

        }
    }
}