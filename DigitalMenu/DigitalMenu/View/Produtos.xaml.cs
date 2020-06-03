using DigitalMenu.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalMenu.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Produtos : ContentPage
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }

        public Produtos(Category categoria, int orderId)
        {
            InitializeComponent();

            OrderId = orderId;
            TituloCategoria.Text = categoria.Description;

            RestClient products = new RestClient("http://13.90.44.28:8080/api/Products/" + categoria.Id);
            RestRequest requestProducts = new RestRequest(Method.GET);

            IRestResponse responseProducts = products.Execute(requestProducts);

            List<RestProductCategory> dProducts = new JsonDeserializer().Deserialize<List<RestProductCategory>>(responseProducts);

            ListaProduto.ItemsSource = dProducts;
        }

        private async void DetalheProdutoAction(object sender, EventArgs args)
        {
            Button btnDetails = (Button)sender;
            RestProductCategory restProduct = btnDetails.CommandParameter as RestProductCategory;
            var productId = restProduct.S.Select(c => c.ProductId).FirstOrDefault();
            var productImage = restProduct.Image;

            ProductId = productId;
            ProductImage = productImage;


            var page = new PopUpPage.PopUpDetalheProduto(OrderId, ProductId, productImage);

            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}