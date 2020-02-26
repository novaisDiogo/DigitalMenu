using DigitalMenu.Model;
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
    public partial class Produtos : ContentPage
    {
        public Produtos(Categoria categoria)
        {
            InitializeComponent();
            TituloCategoria.Text = categoria.TipoCategoria;
            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto { Categoria = categoria.ToString(), Imagem = "Imagem", Adicionais = "Natural", NomeProduto = "Agua" });
            produtos.Add(new Produto { Categoria = categoria.ToString(), Imagem = "Imagem", Adicionais = "Com gelo", NomeProduto = "Coca-Cola" });
            produtos.Add(new Produto { Categoria = categoria.ToString(), Imagem = "Imagem", Adicionais = "Com açucar", NomeProduto = "Suco Natural" });
            produtos.Add(new Produto { Categoria = categoria.ToString(), Imagem = "Imagem", Adicionais = "Laranja", NomeProduto = "Fanta" });
            produtos.Add(new Produto { Categoria = categoria.ToString(), Imagem = "Imagem", Adicionais = "Com limão", NomeProduto = "Pepsi" });

            ListaProduto.ItemsSource = produtos;
        }

        private async void DetalheProdutoAction(object sender, EventArgs args)
        {
            var page = new PopUpPage.PopUpDetalheProduto();

            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}