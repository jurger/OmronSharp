using System.Drawing;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class OPanel : Panel
    {
        public int HeaterNumber { get; set; }
        //public bool IsActive { private set; get; }
        public OEdit FocusPriority { get; set; }

        public OPanel()
        {
            InitializeComponent();
        }



        public void SetActiveColorPanel()
        {
           
            BackColor = Color.Gray;
            foreach (Control control in Controls)
            {
                if (control is Label)
                    control.ForeColor = Color.Lime;
                if (!(control is OEdit)) continue;
                control.BackColor = Color.DarkKhaki;
                control.Enabled = true;
                if (control.Focused)
                    control.BackColor = Color.Yellow;
            }
       
            FocusPriority.Focus();

            //    IsActive = true;
        }

        public void SetPassiveColorPanel()
        {
            BackColor = SystemColors.Control;
            foreach (Control control in Controls)
            {
                if (control is Label)
                    control.ForeColor = Color.Black;
                var edit = control as OEdit;
                if (edit == null) continue;
                control.BackColor = Color.White;
          //      edit.ReadOnly = true;
            }
  //          IsActive = false;
        }


       

      
    }
}
