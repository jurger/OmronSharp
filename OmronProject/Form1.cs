using System;
using System.Drawing;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class Form1 : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();
            SetActiveDno();
            _hook.KeyPressed += HookKeyPressed;
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F1);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F2);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F3);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F4);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F5);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F6);
            /*_hook.RegisterHotKey(new ModifierKeys(), Keys.Up);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Down);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Left);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Right);*/
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

        private static void setActiveColorPanel(Control panel)
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

        private static void setPassiveColorPanel(Control panel)
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
            setActiveColorPanel(panel1);
            setPassiveColorPanel(panel2);
            setPassiveColorPanel(panel3);
            setPassiveColorPanel(panel4);
            setPassiveColorPanel(panel5);
            TTaskDno.Focus();
        }

        private void SetActiveBok()
        {
            setActiveColorPanel(panel2);
            setPassiveColorPanel(panel1);
            setPassiveColorPanel(panel3);
            setPassiveColorPanel(panel4);
            setPassiveColorPanel(panel5);
            TTaskBok.Focus();
        }

        private void SetActivePit()
        {
            setActiveColorPanel(panel3);
            setPassiveColorPanel(panel1);
            setPassiveColorPanel(panel2);
            setPassiveColorPanel(panel4);
            setPassiveColorPanel(panel5);
            TTaskPit.Focus();
        }

        private void SetActiveAlg()
        {
            setActiveColorPanel(panel4);
            setPassiveColorPanel(panel1);
            setPassiveColorPanel(panel3);
            setPassiveColorPanel(panel2);
            setPassiveColorPanel(panel5);
            TTaskAlg.Focus();
        }

        private void SetActiveGp()
        {
            setActiveColorPanel(panel5);
            setPassiveColorPanel(panel1);
            setPassiveColorPanel(panel3);
            setPassiveColorPanel(panel2);
            setPassiveColorPanel(panel4);
            TTaskAlg.Focus();
        }


        private void Form1Shown(object sender, EventArgs e)
        {
            TTaskDno.Focus();
        }
    }
}