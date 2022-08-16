namespace pjControlRegistroEstacionamiento
{
    public partial class frmEstacionamiento : Form
    {
        String dia;

        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        
        private void frmEstacionamiento_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha Actual.
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //Daterminar el día. 
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            switch(dia)
            {
                case "domingo": costo = 2; break;
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                    costo = 4; break;

                case "viernes":
                case "sabado":
                    costo = 7; break; 

            }

            lblCosto.Text = costo.ToString("0.00");

            }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos del formulario
            String placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHoraIncio.Text);
            DateTime horaFin = DateTime.Parse(txtHoraSalir.Text);

            //Calcular la hora
            TimeSpan hora = horaFin - horaInicio;

            //Calcular el importe
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horaInicio.ToString("t"));
            fila.SubItems.Add(horaFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvlRegistro.Items.Add(fila);

        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿ Está seguro de salir?",
                                                "Estacionamiento ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHoraIncio.Clear();
            txtHoraSalir.Clear();
            txtPlaca.Focus();
        }
    }
    }