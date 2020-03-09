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
    public partial class Carrinho : ContentPage
    {
        public Carrinho()
        {
            InitializeComponent();
            List<Opcoes> opcoes = new List<Opcoes>();
            opcoes.Add(new Opcoes { NomeOpcoes = "Contra-File" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Lasanha" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Coca-cola" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Sorvete" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Picole" });

            ListaCarrinho.ItemsSource = opcoes;
        }

        private async void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            Opcoes opcoes = tapGesture.CommandParameter as Opcoes;

            var page = new PopUpPage.PopUpDetalheProduto();
            await PopupNavigation.Instance.PushAsync(page);
        }
        private async void RemoverAction(object sender, EventArgs args)
        {
            Label lblRemover = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblRemover.GestureRecognizers[0];
            Opcoes opcoes = tapGesture.CommandParameter as Opcoes;

            var page = new PopUpPage.PopUpDetalheProduto();
            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}