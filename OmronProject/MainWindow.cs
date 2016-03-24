using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class MainWindow : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();
        public MainWindow()
        {
            InitializeComponent();
            HighlightHeater(1);

            _hook.KeyPressed += HookKeyPressed;
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F1);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F2);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F3);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F4);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F5);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F6);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F8);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.F9);

            /*_hook.RegisterHotKey(new ModifierKeys(), Keys.Up);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Down);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Left);
            _hook.RegisterHotKey(new ModifierKeys(), Keys.Right);*/
        }

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                .Concat(controls).Where(c => c.GetType() == type);
        }


        private void HighlightHeater(int nHeater)
        {
            foreach (var heater in GetAll(this,typeof(OPanel)) )
            {
               // if (heater.GetType() != typeof (OmronPanel)) continue;
                var pn = heater as OPanel;
                if (nHeater == pn.HeaterNumber)
                    pn.SetActiveColorPanel();
                else
                {
                    pn.SetPassiveColorPanel();
                }
            }
        }

    private void HookKeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.F1:
                    HighlightHeater(1);
                    break;
                case Keys.F2:
                    HighlightHeater(2);
                    break;
                case Keys.F3:
                    HighlightHeater(3);
                    break;
                case Keys.F4:
                    HighlightHeater(4);
                    break;
                case Keys.F5:
                    HighlightHeater(5);
                    break;
                case Keys.F8:
                    HighlightHeater(8);
                    break;
                case Keys.F9:
                    HighlightHeater(9);
                    break;

                case Keys.Escape:
                    Application.Exit();
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


        

        private void Form1Shown(object sender, EventArgs e)
        {
            TTaskDno.Focus();
        }
    }
}