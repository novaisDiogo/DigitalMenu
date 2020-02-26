using DigitalMenu.Model;
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

            ListaOpcoes.ItemsSource = opcoes;
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {

        }
        protected override async Task OnDisappearingAnimationBeginAsync()
        {
            
        }
    }
}