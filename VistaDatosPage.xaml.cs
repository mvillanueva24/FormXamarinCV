using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCV.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaDatosPage : ContentPage
    {
        public VistaDatosPage(Dictionary<string, object> datos)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); // Oculta la barra de navegación
            MostrarDatos(datos);
        }

        private void MostrarDatos(Dictionary<string, object> datos)
        {
            // Mostrar nombre y ocupación en la parte superior
            if (datos.ContainsKey("Nombre"))
                NombreLabel.Text = datos["Nombre"].ToString();

            if (datos.ContainsKey("Ocupación"))
                OcupacionLabel.Text = datos["Ocupación"].ToString().ToUpper();

            // Mostrar perfil
            if (datos.ContainsKey("Perfil"))
                PerfilLabel.Text = datos["Perfil"].ToString();

            // Información personal
            var infoPersonal = new[]
            {
                ("Fecha de Nacimiento", "Fecha de Nacimiento"),
                ("Teléfono", "Teléfono"),
                ("Correo", "Correo"),
                ("Nacionalidad", "Nacionalidad"),
                ("Nivel de Inglés", "Nivel de Inglés")
            };

            foreach (var (key, display) in infoPersonal)
            {
                if (datos.ContainsKey(key) && !string.IsNullOrEmpty(datos[key]?.ToString()))
                {
                    var label = new Label
                    {
                        Text = $"{display}: {datos[key]}",
                        TextColor = Color.FromHex("#757575"),
                        Margin = new Thickness(0, 0, 0, 5)
                    };
                    InfoPersonalStack.Children.Add(label);
                }
            }

            // Habilidades y competencias
            var habilidades = new[]
            {
                ("Lenguajes de Programación", "Lenguajes de Programación"),
                ("Aptitudes", "Aptitudes"),
                ("Habilidades", "Habilidades")
            };

            foreach (var (key, display) in habilidades)
            {
                if (datos.ContainsKey(key) && !string.IsNullOrEmpty(datos[key]?.ToString()))
                {
                    var label = new Label
                    {
                        Text = $"{display}:",
                        TextColor = Color.FromHex("#424242"),
                        FontAttributes = FontAttributes.Bold,
                        Margin = new Thickness(0, 5, 0, 5)
                    };
                    HabilidadesStack.Children.Add(label);

                    var valueLabel = new Label
                    {
                        Text = datos[key].ToString(),
                        TextColor = Color.FromHex("#757575"),
                        Margin = new Thickness(0, 0, 0, 10)
                    };
                    HabilidadesStack.Children.Add(valueLabel);
                }
            }
        }
    }
}