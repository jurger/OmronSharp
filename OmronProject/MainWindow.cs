using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class MainWindow : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();
        private readonly List<Keys> _keyList;

        public MainWindow()
        {
            InitializeComponent();
            HighlightHeater(1);

            _hook.KeyPressed += HookKeyPressed;
            _keyList = new List<Keys>()
            {
                Keys.F1, Keys.F2,Keys.F3,Keys.F4,Keys.F5
            };

            foreach (var key in _keyList)
            {
                _hook.RegisterHotKey(new ModifierKeys(), key);
            }

            _hook.RegisterHotKey(new ModifierKeys(), Keys.Tab);
        }

        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            var enumerable = controls as Control[] ?? controls.ToArray();
            return enumerable.SelectMany(ctrl => GetAllControls(ctrl, type)).Concat(enumerable).Where(c => c.GetType() == type);
        }

        private void HighlightHeater(int nHeater)
        {
            foreach (var heater in GetAllControls(this, typeof(OPanel)))
            {
                if (heater.GetType() != typeof(OPanel))
                    continue;
                var pn = heater as OPanel;
                if (pn != null && nHeater == pn.HeaterNumber)
                    pn.SetActiveColorPanel();
                else
                {
                    pn?.SetPassiveColorPanel();
                }
            }
        }

        private void HookKeyPressed(object sender, KeyPressedEventArgs e)
        {
            foreach (var key in _keyList)
                if (e.Key == key)
                    HighlightHeater(_keyList.IndexOf(key) + 1);

            if (e.Key == Keys.Tab)
                return;

            #region
            //         /*      case Keys.Up:
            //         if (ActiveControl.GetType() == typeof(OmronEdit.OmronEdit))
            //         {
            //             var oedit = (OmronEdit.OmronEdit) ActiveControl;
            //             oedit.FieldUp.Focus();
            //         }
            //         break;
            //     case Keys.Down:
            //         if (ActiveControl.GetType() == typeof(OmronEdit.OmronEdit))
            //         {
            //             var oedit = (OmronEdit.OmronEdit)ActiveControl;
            //             oedit.FieldDown.Focus();
            //         }
            //         break;
            //*/
            // }

            #endregion Obsolete  code
        }

        private void Form1Shown(object sender, EventArgs e)
        {
            TTaskDno.Focus();
        }
    }
}