using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Configurar navegación
            MainPage = new NavigationPage(new Views.FormularioCVPage());
        }
    }
}
