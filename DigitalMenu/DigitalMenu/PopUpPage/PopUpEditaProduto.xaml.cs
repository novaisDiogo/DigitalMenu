using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;
using DigitalMenu.Model;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using DigitalMenu.View;
using System.IO;

namespace DigitalMenu.PopUpPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpEditaProduto : PopupPage
    {
        public RestOrderItem RestOrderItem { get; set; }
        public OrderItem OrderItem { get; set; } = new OrderItem();
        public double Valor { get; set; }
        public int IdTable { get; set; }
        public PopUpEditaProduto(RestOrderItem orderItem, int table)
        {
            InitializeComponent();

            RestOrderItem = orderItem;
            OrderItem.OrderItemId = RestOrderItem.OrderItemId;
            OrderItem.ProductId = RestOrderItem.ProductId;
            OrderItem.OrderId = RestOrderItem.OrderId;
            OrderItem.Quantity = orderItem.Quantity;
            OrderItem.Value = orderItem.Value;
            OrderItem.AdditionalId = orderItem.AdditionalId;
            OrderItem.OptionsId = orderItem.OptionsId;
            IdTable = table;
            Valor = orderItem.Value / orderItem.Quantity;

            step.Value = orderItem.Quantity;
            ValorStepper.Text = orderItem.Quantity.ToString();

            RestClient products = new RestClient("http://13.90.44.28:8080/api/Products/product/" + RestOrderItem.ProductId);
            RestRequest requestProducts = new RestRequest(Method.GET);

            IRestResponse responseProducts = products.Execute(requestProducts);

            ProdutoImagem dProducts = new JsonDeserializer().Deserialize<ProdutoImagem>(responseProducts);

            byte[] Base64Stream = Convert.FromBase64String(dProducts.Image);

            xfImage.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));

            RestClient optionProduct = new RestClient("http://13.90.44.28:8080/api/Options/" + RestOrderItem.ProductId);
            RestRequest optionRequest = new RestRequest(Method.GET);

            IRestResponse optionResponse = optionProduct.Execute(optionRequest);

            List<RestProductOption> productOptions = new JsonDeserializer().Deserialize<List<RestProductOption>>(optionResponse);

            RestClient additional = new RestClient("http://13.90.44.28:8080/api/Additionals/" + RestOrderItem.ProductId);
            RestRequest additionalRequest = new RestRequest(Method.GET);

            IRestResponse additionalResponse = additional.Execute(additionalRequest);

            List<RestAdditionalProduct> additionalProducts = new JsonDeserializer().Deserialize<List<RestAdditionalProduct>>(additionalResponse);


            ListaOpcoes.ItemsSource = productOptions;
            ListaAdicionais.ItemsSource = additionalProducts;
            ListOptions.IsVisible = true;
            Quantity.IsVisible = false;
            lblSubTotal.Text = RestOrderItem.Value.ToString();
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

            lblSubTotal.Text = subtotal.ToString();
        }
        private void VoltarAction(object sender, EventArgs args)
        {
            Navigation.PopPopupAsync();
        }
        private void ItemOptionSelect(object sender, SelectedItemChangedEventArgs args)
        {
            RestProductOption productOption = (RestProductOption)args.SelectedItem;

            OrderItem.OptionsId = productOption.S.Select(c => c.OptionsId).FirstOrDefault();
            Valor = productOption.Value;
            OrderItem.Value = Valor;
            lblSubTotal.Text = Valor.ToString();
            OrderItem.Quantity = 1;
            ValorStepper.Text = "1";
            step.Value = 1;

            ListOptions.IsVisible = false;
            Quantity.IsVisible = true;
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
            string output = JsonConvert.SerializeObject(OrderItem);

            RestClient faturaPedido = new RestClient(String.Format("http://13.90.44.28:8080/api/OrderItems/"+ RestOrderItem.OrderItemId));
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            IRestResponse responseFatura = faturaPedido.Execute(request);

            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
            this.Navigation.PopAsync();
            Navigation.PopPopupAsync();
            Navigation.PushAsync(new View.Carrinho(OrderItem.OrderId, IdTable));

        }
    }
}