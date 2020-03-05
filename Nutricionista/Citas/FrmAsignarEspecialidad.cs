using MaterialSkin;
using MaterialSkin.Controls;

namespace Nutricionista.Citas
{
    public partial class FrmAsignarEspecialidad : MaterialForm
    {
        public FrmAsignarEspecialidad()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }
    }
}
