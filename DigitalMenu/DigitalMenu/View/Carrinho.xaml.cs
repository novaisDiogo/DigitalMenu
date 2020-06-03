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
    public partial class Carrinho : ContentPage
    {
        public int OrderId { get; set; }
        public double TotalValue { get; set; } = 0.00;
        public int IdTable { get; set; }
        public Carrinho(int orderId, int table)
        {
            InitializeComponent();

            OrderId = orderId;
            IdTable = table;

            RestClient optionProduct = new RestClient("http://13.90.44.28:8080/api/OrderItems/" + OrderId);
            RestRequest optionRequest = new RestRequest(Method.GET);

            IRestResponse optionResponse = optionProduct.Execute(optionRequest);

            List<RestOrderItem> orderItems = new JsonDeserializer().Deserialize<List<RestOrderItem>>(optionResponse);

            ListaCarrinho.ItemsSource = orderItems;

            foreach(var v in orderItems)
            {
                TotalValue += v.Value;
            }

            Pedido.Text = orderId.ToString();
            Total.Text = TotalValue.ToString();
        }

        private async void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            RestOrderItem ordemItem = tapGesture.CommandParameter as RestOrderItem;

            var page = new PopUpPage.PopUpEditaProduto(ordemItem, IdTable);
            await PopupNavigation.Instance.PushAsync(page);
        }
        private async void RemoverAction(object sender, EventArgs args)
        {
            Label lblRemover = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblRemover.GestureRecognizers[0];
            RestOrderItem orderItem = tapGesture.CommandParameter as RestOrderItem;

            var page = new PopUpPage.PopupDeletarProduto(orderItem.OrderItemId, orderItem.OrderId, IdTable);
            await PopupNavigation.Instance.PushAsync(page);
        }

        public void ActionFinalizar(object sender, EventArgs args)
        {
            Order orderPut = new Order
            {
                OrderId = OrderId,
                OrderDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                TotalValue = TotalValue,
                OrderStatus = 2,
                TableId = IdTable,
                CashierOrder = null,
                Table = null,
                OrderItems = new List<OrderItem>()
            };

            string output = JsonConvert.SerializeObject(orderPut);

            RestClient finalizaPedido = new RestClient(String.Format("http://13.90.44.28:8080/api/Orders/" + OrderId));
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            IRestResponse responsePedido = finalizaPedido.Execute(request);

            App.Current.MainPage = new View.Apresentacao();
        }
    }
}