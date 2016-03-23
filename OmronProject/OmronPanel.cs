using System.Drawing;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class OmronPanel : Panel
    {
        public int HeaterNumber { get; set; }
        public bool IsActive { private set; get; }
        public OmronEdit FocusPriority { get; set; }

        public void SetActiveColorPanel()
        {
            FocusPriority.Focus();
            BackColor = Color.Gray;
            foreach (Control control in Controls)
            {
                if (control is Label)
                    control.ForeColor = Color.Lime;
                if (control is OmronEdit)
                {
                    control.BackColor = Color.DarkKhaki;
                    control.Enabled = true;
                    if (control.Focused)
                        control.BackColor = Color.Yellow;

                }
                
            }
            IsActive = true;
        }

        public void SetPassiveColorPanel()
        {
            BackColor = SystemColors.Control;
            foreach (Control control in Controls)
            {
                if (control is Label)
                    control.ForeColor = Color.Black;
                var edit = control as OmronEdit;
                if (edit == null) continue;
                control.BackColor = Color.White;
                // i.Enabled = false;
                var re = edit;
                re.ReadOnly = true;
            }
            IsActive = false;
        }


        public OmronPanel()
        {
            InitializeComponent();
        }

      
    }
}
