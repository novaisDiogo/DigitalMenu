using RestSharp;
using Rg.Plugins.Popup.Extensions;
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
    public partial class PopupDeletarProduto : PopupPage
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int IdTable { get; set; }
        public PopupDeletarProduto(int id, int orderId, int table)
        {
            ItemId = id;
            OrderId = orderId;
            IdTable = table;

            InitializeComponent();
        }

        public void ActionDeleteItem(object sender, EventArgs args)
        {
            RestClient deleteItem = new RestClient("http://13.90.44.28:8080/api/OrderItems/" + ItemId);
            RestRequest deleteRequest = new RestRequest(Method.DELETE);

            IRestResponse deleteRsponse = deleteItem.Execute(deleteRequest);

            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
            this.Navigation.PopAsync();
            Navigation.PopPopupAsync();
            Navigation.PushAsync(new View.Carrinho(OrderId, IdTable));
        }
        private void ActionVoltar(object sender, EventArgs args)
        {
            Navigation.PopPopupAsync();
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {

        }
    }
}