using DigitalMenu.Banco;
using DigitalMenu.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalMenu.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Apresentacao : ContentPage
    {
        public Apresentacao()
        {
            InitializeComponent();
        }

        public void btnActionMaster(object sender, EventArgs args)
        {
            Database database = new Database();

            Order order = new Order
            {
                OrderDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                OrderStatus = 1,
                TableId = database.IdTable(),
            };

            string output = JsonConvert.SerializeObject(order);

            RestClient faturaPedido = new RestClient(String.Format("http://13.90.44.28:8080/api/Orders/"));
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            IRestResponse responseFatura = faturaPedido.Execute(request);

            Order order1 = new JsonDeserializer().Deserialize<Order>(responseFatura);
            int id = int.Parse(order1.OrderId.ToString());
            int idTable = int.Parse(order1.TableId.ToString());
            App.Current.MainPage = new NavigationPage(new Master.MasterPage(id, idTable)) { BarBackgroundColor = Color.FromHex("#D2691E") }; ;
        }

        public async void btnActionConfigAsync(object sender, EventArgs args)
        {
            var configPage = new PopUpPage.ConfigPopup();
            await PopupNavigation.Instance.PushAsync(configPage);
        }
    }
}