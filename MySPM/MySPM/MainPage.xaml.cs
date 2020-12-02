﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySPM
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new Inicio());
    }
  }
}
