using DigitalMenu.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalMenu.PopUpPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpDetalheProduto : PopupPage
    {
        public double Valor { get; set; }
        public int OrderId { get; set; }
        public OrderItem OrderItem { get; set; } = new OrderItem();
        public PopUpDetalheProduto(int orderId, int productId, string image)
        {
            InitializeComponent();

            byte[] Base64Stream = Convert.FromBase64String(image);

            xfImage.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));

            OrderId = orderId;
            OrderItem.OrderId = OrderId;
            OrderItem.ProductId = productId;

            RestClient optionProduct = new RestClient("http://13.90.44.28:8080/api/Options/" + productId);
            RestRequest optionRequest = new RestRequest(Method.GET);

            IRestResponse optionResponse = optionProduct.Execute(optionRequest);

            List<RestProductOption> productOptions = new JsonDeserializer().Deserialize<List<RestProductOption>>(optionResponse);

            RestClient additional = new RestClient("http://13.90.44.28:8080/api/Additionals/" + productId);
            RestRequest additionalRequest = new RestRequest(Method.GET);

            IRestResponse additionalResponse = additional.Execute(additionalRequest);

            List<RestAdditionalProduct> additionalProducts = new JsonDeserializer().Deserialize<List<RestAdditionalProduct>>(additionalResponse);


            ListaOpcoes.ItemsSource = productOptions;
            ListaAdicionais.ItemsSource = additionalProducts;
            ListOptions.IsVisible = true;
            Quantity.IsVisible = false;
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {

        }
        private void ActionMudaValorStepper(object sender, ValueChangedEventArgs args)
        {
            ValorStepper.Text = args.NewValue.ToString();
            OrderItem.Quantity = int.Parse(args.NewValue.ToString());

            double subtotal = args.NewValue * Valor;
            OrderItem.Value = subtotal;

            lblSubTotal.Text = subtotal.ToString("F2");
        }
        private void VoltarAction(object sender, EventArgs args)
        {
            Navigation.PopPopupAsync();
        }
        private void ItemOptionSelect(object sender, SelectedItemChangedEventArgs args)
        {
            RestProductOption productOption = (RestProductOption)args.SelectedItem;

            OrderItem.OptionsId = productOption.S.Select(c => c.OptionsId).FirstOrDefault();
            Valor = Double.Parse(productOption.Value.ToString("F2"));
            OrderItem.Value = Valor;
            lblSubTotal.Text = Valor.ToString("F2");
            OrderItem.Quantity = 1;
            ValorStepper.Text = "1";

            ListOptions.IsVisible = false;
            Quantity.IsVisible = true;
            Op1.BackgroundColor = Color.FromHex("#D2691E");
            lblOp1.TextColor = Color.White;
            Op2.BackgroundColor = Color.LightGray;
            lblOp2.TextColor = Color.Black;
        }
        private void ItemAdditionalSelect(object sender, SelectedItemChangedEventArgs args)
        {
            RestAdditionalProduct additionalProduct = (RestAdditionalProduct)args.SelectedItem;

            OrderItem.AdditionalId = additionalProduct.S.Select(c => c.AdditionalId).FirstOrDefault();
        }
        private void Opcao1Action(object sender, EventArgs args)
        {
            ListOptions.IsVisible = true;
            Quantity.IsVisible = false;
            Op1.BackgroundColor = Color.LightGray;
            lblOp1.TextColor = Color.Black;
            Op2.BackgroundColor = Color.FromHex("#D2691E");
            lblOp2.TextColor = Color.White;
        }
        private void Opcao2Action(object sender, EventArgs args)
        {
            ListOptions.IsVisible = false;
            Quantity.IsVisible = true;
            Op1.BackgroundColor = Color.FromHex("#D2691E");
            lblOp1.TextColor = Color.White;
            Op2.BackgroundColor = Color.LightGray;
            lblOp2.TextColor = Color.Black;
        }
        private void ActionButtonCarrinho(object sender, EventArgs args)
        {
            if(OrderItem.AdditionalId == null)
            {
                DisplayAlert("Adicional", "Faltou escolher o adicional", "Fechar");
            }
            else
            {
                string output = JsonConvert.SerializeObject(OrderItem);

                RestClient faturaPedido = new RestClient(String.Format("http://13.90.44.28:8080/api/OrderItems/"));
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", output, ParameterType.RequestBody);
                IRestResponse responseFatura = faturaPedido.Execute(request);

                Navigation.PopPopupAsync();
            }
        }
    }
}