﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CompreAqui.Modelos;
using CompreAqui.ViewModels;

namespace CompreAqui.Paginas
{
    public partial class ProdutosHub : PhoneApplicationPage
    {
        public ProdutosHub()
        {
            InitializeComponent();
        }

        private void SuaConta_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Paginas/SuaConta.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Categorias.ItemsSource = (from produtos in Loja.Dados.Produtos
                                      select new CategoriaVM
                                      {
                                          Id = produtos.Categoria.Id,
                                          Descricao = produtos.Categoria.Descricao
                                      }).Distinct().ToList();

            Promocoes.ItemsSource = (from produtos in Loja.Dados.Produtos
                                     where produtos.PrecoPromocao != 0
                                     select new ProdutoVM
                                     {
                                         Id = produtos.Id,
                                         Descricao = produtos.Descricao,
                                         Preco = produtos.Preco,
                                         PrecoPromocao = produtos.PrecoPromocao,
                                         Icone = produtos.Icone
                                     }).OrderByDescending(produto => produto.Desconto)
                                       .ToList();

            Produtos.ItemsSource = (from produtos in Loja.Dados.Produtos
                                    where produtos.Id == 3 || produtos.Id == 4
                                    select new ProdutoVM
                                    {
                                        Id = produtos.Id,
                                        Descricao = produtos.Descricao,
                                        Icone = produtos.Icone,
                                        Preco = produtos.Preco,
                                        PrecoPromocao = produtos.PrecoPromocao
                                    }).ToList();
        }
    }
}