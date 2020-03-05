using MaterialSkin;
using MaterialSkin.Controls;
using Nutricionista.servicio;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Citas
{
    public partial class FrmHorario : MaterialForm
    {
        public FrmHorario()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }

        private async void FrmHorario_Load(object sender, EventArgs e)
        {

        }

        private void txtMedico_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void txtMedico_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("hh");
            }
        }

        private async void Btn_LupaBuscar_Click(object sender, EventArgs e)
        {
            var dni = txtMedico.Text;
            await MedicosAsync(dni);
        }

        public async Task MedicosAsync(string id)
        {
            var apiMedicos = new ApiMedico();
            var medico = await apiMedicos.MedicosAsync(id);
            var error = apiMedicos.error;
            if (error == "OK")
            {
                LblNombre.Text = medico.Nombres + " " + medico.Apellidos;
            }
            else
            {
                MessageBox.Show(error);
                LblNombre.Text = "";
            }
            txtMedico.Focus();
            txtMedico.SelectAll();
        }

    }
}
