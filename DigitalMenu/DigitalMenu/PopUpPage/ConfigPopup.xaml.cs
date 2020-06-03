using DigitalMenu.Banco;
using DigitalMenu.Model;
using RestSharp;
using RestSharp.Serialization.Json;
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
    public partial class ConfigPopup : PopupPage
    {
        public ConfigPopup()
        {
            InitializeComponent();

            Database database = new Database();

            var exits = database.TokenExiste();

            if (!exits)
            {
                Token token = new Token();
                token.Secret = "admin";
                database.CreateToken(token);
            }

            Opcoes.IsVisible = false;
            SelectTable.IsVisible = false;
        }
        public void btnActionAcessar(object sender, EventArgs args)
        {
            Database database = new Database();

            var success = database.ConsultaToken(txtSecret.Text);

            if (success)
            {
                Acesso.IsVisible = false;
                Opcoes.IsVisible = true;
            }
        }

        public void btnActionCancelar(object sender, EventArgs args)
        {
            Navigation.PopPopupAsync();
        }

        public void btnActionSincronizar(object sender, EventArgs args)
        {
            Database database = new Database();

            var exist = database.TablesExist();

            if (exist)
            {
                database.DeleteTables();
            }

            RestClient restTables = new RestClient("http://13.90.44.28:8080/api/Tables");
            RestRequest tablesRequest = new RestRequest(Method.GET);

            IRestResponse tableResponse = restTables.Execute(tablesRequest);

            List<Table> tables = new JsonDeserializer().Deserialize<List<Table>>(tableResponse);

            foreach (var t in tables)
            {
                Tables newTables = new Tables
                {
                    Description = t.Description,
                    Number = t.Id
                };

                database.CreateTable(newTables);
            }
        }
        public void btnSelectTable(object sender, EventArgs args)
        {
            Database database = new Database();

            var list = database.ListTables();
            ListOpcoes.ItemsSource = list;
            Opcoes.IsVisible = false;
            SelectTable.IsVisible = true;
        }

        private void ItemOptionSelect(object sender, SelectedItemChangedEventArgs args)
        {
            Database database = new Database();

            var t = database.Table();

            if (t != null)
            {
                Tables tableRemove = new Tables
                {
                    Id = t.Id,
                    Description = t.Description,
                    Number = t.Number,
                    Active = false
                };

                database.UpdateTable(tableRemove);
            }

            Tables tables = (Tables)args.SelectedItem;
            tables.Active = true;

            database.UpdateTable(tables);

            Opcoes.IsVisible = true;
            SelectTable.IsVisible = false;
            Acesso.IsVisible = false;
        }
        private void btnActionVoltar(object sender, EventArgs args)
        {
            Opcoes.IsVisible = true;
            SelectTable.IsVisible = false;
            Acesso.IsVisible = false;
        }
        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {

        }
    }
}