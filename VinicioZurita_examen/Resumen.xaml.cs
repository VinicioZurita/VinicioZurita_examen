using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinicioZurita_examen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(string nom, string Pag, string u, string saldo, string div, string c1, string c2, string c3)
        {
            InitializeComponent();
            lbUsuario.Text = "Usuario: " + u;
            lbNombre.Text = nom;
            lbPI.Text = Pag;
            lbSaldo.Text = saldo;
            lbDiv.Text = div;
            lbCuota1.Text = c1;
            lbCuota2.Text = c2;
            lbCuota3.Text = c3;
        }
    }
}