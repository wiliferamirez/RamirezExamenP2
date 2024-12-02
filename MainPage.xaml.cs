namespace WRExamenP2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void WRconvertirUnidades(object sender, EventArgs e)
        {

                if (string.IsNullOrWhiteSpace(WRcantidadEntry.Text))
                {
                    DisplayAlert("Error", "Por favor, ingresa una cantidad válida", "OK");
                    return;
                }

                if (WRaConvertirPicker.SelectedItem == null || WRnuevaMedidaPicker.SelectedItem == null)
                {
                    DisplayAlert("Error", "Por favor, selecciona las unidades a convertir", "OK");
                    return;
                }


                string unidadOrigen = WRaConvertirPicker.SelectedItem.ToString();
                string unidadDestino = WRnuevaMedidaPicker.SelectedItem.ToString();
                double cantidad = double.Parse(WRcantidadEntry.Text);


                double resultado = WRConvertir(cantidad, unidadOrigen, unidadDestino);


                WRresultadoLabel.Text = resultado.ToString("F2");

        }


        private void WRlimpiarCampos(object sender, EventArgs e)
        {
            WRcantidadEntry.Text = string.Empty;
            WRaConvertirPicker.SelectedItem = null;
            WRnuevaMedidaPicker.SelectedItem = null;
            WRresultadoLabel.Text = "0";
        }


        private double WRConvertir(double cantidad, string unidadOrigen, string unidadDestino)
        {

            double cantidadEnMetros = unidadOrigen switch
            {
                "Metros" => cantidad,
                "kilometros" => cantidad * 1000,
                "Millas" => cantidad * 1609.34
            };

  
            return unidadDestino switch
            {
                "Metros" => cantidadEnMetros,
                "kilometros" => cantidadEnMetros / 1000,
                "Millas" => cantidadEnMetros / 1609.34
            };
        }
    }
}
