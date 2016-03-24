using System.Diagnostics.CodeAnalysis;

namespace OmronProject
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;





    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class OEdit : TextBox
    {

        public enum TActivity
        {
            ActInAct,
            PasInAct,
            PasInPas
        }

        public enum TState
        {
            Normal,
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

        public int MinError { get; set; }
        public int MaxError { get; set; }
        public float Step { get; set; }
        public int NumsAfterDot { get; set; }
        public TTypeContent TypeContent { get; set; }
        public TActivity Activity { get; set; }
        public TState State { get; set; }
        public TWindow Window { get; set; }
        public OEdit FieldUp { get; set; }
        public OEdit FieldDown { get; set; }



        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x201 || m.Msg == 0x204) //0x201 - Left Button 0x204 - Right button
            {
                return;
            }
            base.WndProc(ref m);
        }


       

        public OEdit()
        {
            
            
            InitializeComponent();
            
            GotFocus += TextBoxGotFocus;
            Enabled = true; //TODO: Need fix in designer

    }

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(Handle);
            Select(0, 0);
            BackColor = Color.Yellow;
        }

        

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
                    FieldUp.Focus();
                    break;
                case Keys.Down:
                   FieldDown.Focus();
                    break;
                case Keys.Escape:
                    Text = "0.0";
                    break;
            }
        }

        

        private void OmronEditLeave(object sender, EventArgs e)
        {
            BackColor = Color.DarkKhaki;
        }

        //private void SetFieldColor(TState state)
        //{
        //    switch (state)
        //    {
        //        case TState.Normal:
        //            break;
        //    }

        //}
    }
}