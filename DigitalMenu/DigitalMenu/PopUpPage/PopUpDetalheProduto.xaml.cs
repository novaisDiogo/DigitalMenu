using DigitalMenu.Model;
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
    public partial class PopUpDetalheProduto : PopupPage
    {
        public PopUpDetalheProduto()
        {
            InitializeComponent();
            List<Opcoes> opcoes = new List<Opcoes>();
            opcoes.Add(new Opcoes { NomeOpcoes = "Coca" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Fanta laranja" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Fanta Uva" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Fanta guarana" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Guarana" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Turbaina" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Sukita laranja" });
            opcoes.Add(new Opcoes { NomeOpcoes = "Sukita Uva" });

            List<Adicional> adicionals = new List<Adicional>();
            adicionals.Add(new Adicional { NomeAdicional = "Com Gelo" });
            adicionals.Add(new Adicional { NomeAdicional = "Com Limão" });
            adicionals.Add(new Adicional { NomeAdicional = "Com Laranja" });
            adicionals.Add(new Adicional { NomeAdicional = "Com Açucar" });
            adicionals.Add(new Adicional { NomeAdicional = "Sem Açucar" });

            ListaOpcoes.ItemsSource = opcoes;
            ListaAdicionais.ItemsSource = adicionals;
            ListOptions.IsVisible = true;
            Quantity.IsVisible = false;
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {
            
        }

        private void VoltarAction(object sender, EventArgs args)
        {
            Navigation.PopPopupAsync();
        }
        private void ItemSelect(object sender, SelectedItemChangedEventArgs args)
        {
            ListOptions.IsVisible = false;
            Quantity.IsVisible = true;
        }
        private void Opcao1Action(object sender, EventArgs args)
        {
            ListOptions.IsVisible = true;
            Quantity.IsVisible = false;
        }
        private void Opcao2Action(object sender, EventArgs args)
        {
            ListOptions.IsVisible = false;
            Quantity.IsVisible = true;
        }
    }
}