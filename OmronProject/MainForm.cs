using System;
using System.Drawing;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class MainForm : Form
    {
        private readonly KeyboardHook hook = new KeyboardHook();

        public MainForm()
        {
            InitializeComponent();
            SetActiveDno();
            hook.KeyPressed += HookKeyPressed;
            hook.RegisterHotKey(new ModifierKeys(), Keys.F1);
            hook.RegisterHotKey(new ModifierKeys(), Keys.F2);
            hook.RegisterHotKey(new ModifierKeys(), Keys.F3);
            hook.RegisterHotKey(new ModifierKeys(), Keys.F4);
            hook.RegisterHotKey(new ModifierKeys(), Keys.F5);
            hook.RegisterHotKey(new ModifierKeys(), Keys.F6);
            /*_hook.RegisterHotKey(new ModifierKeys(), Keys.Up);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Down);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Left);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Right);*/
            heater1.OmronEdit1.Text = "asdas";
            
        }

        private void HookKeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.F1:
                    SetActiveDno();
                    
                    break;
                case Keys.F2:
                    SetActiveBok();
                    break;
                case Keys.F3:
                    SetActivePit();
                    break;
                case Keys.F4:
                    SetActiveAlg();
                    break;
                case Keys.F5:
                    SetActiveGp();
                    break;
                    /*      case Keys.Up:
                    if (ActiveControl.GetType() == typeof(OmronEdit.OmronEdit))
                    {
                        var oedit = (OmronEdit.OmronEdit) ActiveControl;
                        oedit.FieldUp.Focus();
                    }
                    break;
                case Keys.Down:
                    if (ActiveControl.GetType() == typeof(OmronEdit.OmronEdit))
                    {
                        var oedit = (OmronEdit.OmronEdit)ActiveControl;
                        oedit.FieldDown.Focus();
                    }
                    break;
           */
            }
        }


        private void OmronEdit3TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private static void SetActiveColorPanel(Control panel)
        {
            panel.BackColor = Color.Gray;
            foreach (Control control in panel.Controls)
            {
                if (control is Label)
                    control.ForeColor = Color.Lime;
                if (control is OmronEdit)
                {
                    control.BackColor = Color.DarkKhaki;
                    control.Enabled = true;
                }
            }
        }

        private static void SetPassiveColorPanel(Control panel)
        {
            panel.BackColor = SystemColors.Control;
            foreach (Control control in panel.Controls)
            {
                if (control is  Label)
                    control.ForeColor = Color.Black;
                if (control is OmronEdit)
                {
                    control.BackColor = Color.White;
                    // i.Enabled = false;
                    var re = (OmronEdit) control;
                    re.ReadOnly = true;
                }
            }
        }

        private void SetActiveDno()
        {
            SetActiveColorPanel(panel1);
            SetPassiveColorPanel(panel2);
            SetPassiveColorPanel(panel3);
            SetPassiveColorPanel(panel4);
            SetPassiveColorPanel(panel5);
            TTaskDno.Focus();
        }

        private void SetActiveBok()
        {
            SetActiveColorPanel(panel2);
            SetPassiveColorPanel(panel1);
            SetPassiveColorPanel(panel3);
            SetPassiveColorPanel(panel4);
            SetPassiveColorPanel(panel5);
            TTaskBok.Focus();
        }

        private void SetActivePit()
        {
            SetActiveColorPanel(panel3);
            SetPassiveColorPanel(panel1);
            SetPassiveColorPanel(panel2);
            SetPassiveColorPanel(panel4);
            SetPassiveColorPanel(panel5);
            TTaskPit.Focus();
        }

        private void SetActiveAlg()
        {
            SetActiveColorPanel(panel4);
            SetPassiveColorPanel(panel1);
            SetPassiveColorPanel(panel3);
            SetPassiveColorPanel(panel2);
            SetPassiveColorPanel(panel5);
            TTaskAlg.Focus();
        }

        private void SetActiveGp()
        {
            SetActiveColorPanel(panel5);
            SetPassiveColorPanel(panel1);
            SetPassiveColorPanel(panel3);
            SetPassiveColorPanel(panel2);
            SetPassiveColorPanel(panel4);
            TTaskAlg.Focus();
        }


        private void Form1Shown(object sender, EventArgs e)
        {
            TTaskDno.Focus();
        }
    }
}