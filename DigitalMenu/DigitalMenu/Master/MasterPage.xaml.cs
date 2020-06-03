using DigitalMenu.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalMenu.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public int OrderId { get; set; }
        public int IdTable { get; set; }
        public MasterPage(int orderId, int table)
        {
            InitializeComponent();

            OrderId = orderId;
            IdTable = table;

            RestClient categories = new RestClient("http://13.90.44.28:8080/api/Categories/");
            RestRequest requestCategories = new RestRequest(Method.GET);

            IRestResponse categoriesResponse = categories.Execute(requestCategories);

            List<Category> categories1 = new JsonDeserializer().Deserialize<List<Category>>(categoriesResponse);

            ViewCategorias.ItemsSource = categories1;
        }

        private void CategoriaSelecionada(object sender, SelectedItemChangedEventArgs args)
        {
            Category categoria = (Category)args.SelectedItem;

            Detail = new View.Produtos(categoria, OrderId);
        }
        private void CarrinhoAction(object sender, EventArgs args)
        {
            Navigation.PushAsync(new View.Carrinho(OrderId, IdTable));
        }
    }
}