using DigitalMenu.Model;
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
        public MasterPage()
        {
            InitializeComponent();

            List<Categoria> categorias = new List<Categoria>();

            categorias.Add(new Categoria { TipoCategoria = "Bebidas" });
            categorias.Add(new Categoria { TipoCategoria = "Pratos Comerciais" });
            categorias.Add(new Categoria { TipoCategoria = "Pratos Executivos" });
            categorias.Add(new Categoria { TipoCategoria = "Saladas" });
            categorias.Add(new Categoria { TipoCategoria = "Sobremesas" });

            ViewCategorias.ItemsSource = categorias;
        }

        private void CategoriaSelecionada(object sender, SelectedItemChangedEventArgs args)
        {
            Categoria categoria = (Categoria)args.SelectedItem;

            Detail = new View.Produtos(categoria);
        }
    }
}