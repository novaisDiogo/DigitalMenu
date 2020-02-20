﻿using DigitalMenu.Model;
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
            ProdCat.Text = categoria.TipoCategoria;
        }
    }
}