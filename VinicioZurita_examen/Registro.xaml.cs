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
    public partial class Registro : ContentPage
    {
        string u;
        public Registro(string usu)
        {
            InitializeComponent();
            lbUsuario.Text = "Usuario: " + usu;
            txtNombre.Text = "";
            txtPI.Text = "";
            u = usu;
        }



        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "¡Datos Guardados con exito!", "OK");
            string nombre = txtNombre.Text;
            string PagoI = txtPI.Text;
            string saldo = txtSaldo.Text;
            string div = txtDiv.Text;
            string c1 = txtCuota1.Text;
            string c2 = txtCuota2.Text;
            string c3 = txtCuota3.Text;
            await Navigation.PushAsync(new Resumen(nombre, PagoI, u, saldo, div, c1, c2, c3));
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtPI.Text != "")
                {
                    if (Convert.ToDouble(txtPI.Text) < 1800)
                    {
                        double cuota = 1800 - Convert.ToDouble(txtPI.Text);
                        double pc = Math.Round((cuota / 3) + 90, 2);
                        txtSaldo.Text = "Saldo: " + cuota;
                        txtDiv.Text = "Cuotas Individuales: " + Math.Round((cuota / 3), 2);
                        txtCuota1.Text = pc.ToString();
                        txtCuota2.Text = pc.ToString();
                        txtCuota3.Text = pc.ToString();
                        btnGuardar.IsEnabled = true;
                    }
                    else if (Convert.ToDouble(txtPI.Text) == 1800)
                    {
                        txtSaldo.Text = "Saldo: 0";
                        txtDiv.Text = "Cuotas Individuales: 0";
                        txtCuota1.Text = "0";
                        txtCuota2.Text = "0";
                        txtCuota3.Text = "0";
                        btnGuardar.IsEnabled = true;
                    }
                    else
                    {
                        DisplayAlert("Error!", "¡La cuota inicial debe ser menor a $1800.", "OK");
                        btnGuardar.IsEnabled = false;
                    }

                }
                else
                {
                    DisplayAlert("Error!", "¡Los campos * son abligatorios!", "OK");
                    btnGuardar.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", "" + ex, "OK");
            }
        }
    }
}