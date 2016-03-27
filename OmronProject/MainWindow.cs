using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            List<Keys> KeyList = new List<Keys>()
            {
                Keys.F1, Keys.F2,Keys.F3,Keys.F4,Keys.F5,Keys.Tab

            };
            
            foreach (var key in KeyList)
                _hook.RegisterHotKey(new ModifierKeys(),key);
            
           

          
        }

        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                .Concat(controls).Where(c => c.GetType() == type);
        }


        private void HighlightHeater(int nHeater)
        {
            foreach (var heater in GetAllControls(this,typeof(OPanel)) )
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

                case Keys.Tab:
                   // return;
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