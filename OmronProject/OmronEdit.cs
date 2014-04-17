namespace OmronProject
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

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
            this.InitializeComponent();
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
                if (this.Text.IndexOf('.') < 0 && this.SelectionStart != 0)
                {
                    this.Text += @".";
                    this.SelectionStart = this.Text.Length;
                }
            }
            if ((this.Text.IndexOf('.') >= 0 || this.SelectionStart == 0) && e.KeyChar == '.')
                e.Handled = true;
            if (this.SelectionStart != 0 && e.KeyChar == '-')
                e.Handled = true;
            if (this.nonDigitEntered)
                e.Handled = true;

          
        }

        private void OmronEditKeyDown(object sender, KeyEventArgs e)
        {
            this.nonDigitEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod
                        && e.KeyCode != Keys.Oemcomma && e.KeyCode != Keys.OemMinus
                        && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.Subtract)
                        this.nonDigitEntered = true;
                }
                /*    if (Text.IndexOf('.')>=0)
                    if (Text.Substring(Text.IndexOf('.')).Length > 2)
                        nonDigitEntered = true;*/
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.FieldUp.Focus();
                    break;
                case Keys.Down:
                    this.FieldDown.Focus();
                    break;
            }
        }

        private void OmronEditEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void OmronEditLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkKhaki;
        }
    }
}