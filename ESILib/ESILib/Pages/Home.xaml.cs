﻿using ESILib.Data;
using ESILib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private FirebaseHelper helper = new FirebaseHelper();
        private ObservableCollection<Book> books ;
        private ObservableCollection<Book> collectbooks;
        public Home()
        {
            InitializeComponent();
            GetLatest();
        }
        private async void GetLatest()
        {
            books = new ObservableCollection<Book>(await helper.GetLatestBooks());
            collectbooks = new ObservableCollection<Book>(books.Take(4));
            Books.ItemsSource = books.Where(i=>!collectbooks.Contains(i));
            First.ItemsSource = collectbooks;
        }

        private void First_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = (Book)e.CurrentSelection;

        }

        private void Books_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Book book = (Book)e.Item;
        }
    }
}