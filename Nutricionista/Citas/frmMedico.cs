using MaterialSkin;
using MaterialSkin.Controls;
using System;
namespace Nutricionista.Citas
{
    public partial class frmMedico : MaterialForm
    {
        public frmMedico()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }

        private void xuiCustomGroupbox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
