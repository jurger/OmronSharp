using System.Diagnostics.CodeAnalysis;

namespace OmronProject
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class OmronEdit : TextBox
    {
        public enum TActivity
        {
            ActInAct,
            PasInAct,
            PasInPas
        }

        public enum TState
        {
            Norma,
            Proc,
            WaitSend,
            Error,
            NoData
        }

        public enum TTypeContent
        {
            NumInt,
            NumFloat,
            Automan,
            OnOff,
            Mode
        }

        public enum TWindow
        {
            Dno,
            Bok,
            Pit,
            Algorithm,
            GrowParam
        }


        private bool nonDigitEntered;

        public OmronEdit()
        {
            InitializeComponent();
        }

        public int MinError { get; set; }
        public int MaxError { get; set; }
        public float Step { get; set; }
        public int NumsAfterDot { get; set; }
        public TTypeContent TypeContent { get; set; }
        public TActivity Activity { get; set; }
        public TState State { get; set; }
        public TWindow Window { get; set; }
        public OmronEdit FieldUp { get; set; }
        public OmronEdit FieldDown { get; set; }
        

#region floatmask
        //private void SetFloatMask(KeyPressEventArgs e)
        //{
        //    var c = e.KeyChar;
        //    bool b = (c == '\b' || ('0' <= c && c <= '9') || c == ',' || c=='.');
        //    if (!b)
        //        e.Handled = true;
        //    if (this.Text.IndexOf(',') > 1 && c == ',')
        //        e.Handled = true;
        //    if (this.Text.IndexOf('.') > 1 && c == '.')
        //        e.Handled = true;

        //}
#endregion


        private void OmronEditKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
                if (Text.IndexOf('.') < 0 && SelectionStart != 0)
                {
                    Text += @".";
                    SelectionStart = Text.Length;
                }
            }
            if ((Text.IndexOf('.') >= 0 || SelectionStart == 0) && e.KeyChar == '.')
                e.Handled = true;
            if (SelectionStart != 0 && e.KeyChar == '-')
                e.Handled = true;
            if (nonDigitEntered)
                e.Handled = true;

          
        }

        private void OmronEditKeyDown(object sender, KeyEventArgs e)
        {
            nonDigitEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod
                        && e.KeyCode != Keys.Oemcomma && e.KeyCode != Keys.OemMinus
                        && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.Subtract)
                        nonDigitEntered = true;
                }
                /*    if (Text.IndexOf('.')>=0)
                    if (Text.Substring(Text.IndexOf('.')).Length > 2)
                        nonDigitEntered = true;*/
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    //FieldUp.Focus();
                    break;
                case Keys.Down:
                    //FieldDown.Focus();
                    break;
            }
        }

        private void OmronEditEnter(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void OmronEditLeave(object sender, EventArgs e)
        {
            BackColor = Color.DarkKhaki;
        }
    }
}