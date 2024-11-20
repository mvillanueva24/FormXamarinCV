using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCV.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCVPage : ContentPage
    {
        public FormularioCVPage()
        {
            InitializeComponent();
        }

        private async void OnEnviarClicked(object sender, EventArgs e)
        {
            var datos = new Dictionary<string, object>
            {
                { "Nombre", NombreEntry.Text },
                { "Fecha de Nacimiento", FechaNacimientoPicker.Date.ToString("dd/MM/yyyy") },
                { "Ocupación", OcupacionEntry.Text },
                { "Teléfono", TelefonoEntry.Text },
                { "Correo", CorreoEntry.Text },
                { "Nacionalidad", NacionalidadPicker.SelectedItem?.ToString() },
                { "Nivel de Inglés", ObtenerNivelIngles() },
                { "Lenguajes de Programación", ObtenerLenguajes() },
                { "Aptitudes", AptitudesEditor.Text },
                { "Habilidades", ObtenerHabilidades() },
                { "Perfil", PerfilEditor.Text }
            };

            await Navigation.PushAsync(new VistaDatosPage(datos));
        }

        private string ObtenerNivelIngles()
        {
            if (BasicoRadio.IsChecked) return "Básico";
            if (IntermedioRadio.IsChecked) return "Intermedio";
            if (AvanzadoRadio.IsChecked) return "Avanzado";
            if (FluidoRadio.IsChecked) return "Fluido";
            return "";
        }

        private string ObtenerLenguajes()
        {
            var lenguajes = new List<string>();
            if (JavascriptCheck.IsChecked) lenguajes.Add("Javascript");
            if (PythonCheck.IsChecked) lenguajes.Add("Python");
            if (PHPCheck.IsChecked) lenguajes.Add("PHP");
            return string.Join(", ", lenguajes);
        }

        private string ObtenerHabilidades()
        {
            var habilidades = new List<string>();
            if (InteligenciaCheck.IsChecked) habilidades.Add("Inteligencia Emocional");
            if (EspirituCheck.IsChecked) habilidades.Add("Espíritu Crítico");
            if (TrabajoEquipoCheck.IsChecked) habilidades.Add("Trabajo en Equipo");
            return string.Join(", ", habilidades);
        }
    }
}