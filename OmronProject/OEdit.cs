using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace OmronProject
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;



    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "SpecifyACultureInStringConversionExplicitly")]


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

        public enum ContentType
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

        private enum Operation { Increment, Decrement }

        public int MinError { get; set; }
        public int MaxError { get; set; }
        public float Step { get; set; }
        public int NumsAfterDot { get; set; }
        public ContentType TypeContent { get; set; }
        public TActivity Activity { get; set; }
        public TState State { get; set; }
        public TWindow Window { get; set; }
        public OEdit FieldUp { get; set; }
        public OEdit FieldDown { get; set; }


        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x201 || m.Msg == 0x204 ||
                m.Msg == 0x203) //0x201 - Left Button 0x204 - Right button
            {
                return;
            }
            base.WndProc(ref m);
        }


        public OEdit()
        {
            
            InitializeComponent();
            
            GotFocus += FieldGotFocus;
            Enabled = true; //TODO: Need fix in designer
    //        switch (TypeContent)
            
            

    }

        private void FieldGotFocus(object sender, EventArgs args)
        {
         //   HideCaret(Handle);
            BackColor = Color.Yellow;
            SelectionStart = 0;

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
                if (Text.IndexOf('.') < 0 && SelectionStart != 0  )
                {
                    Text += @".";
                    SelectionStart = Text.Length;
                }
            }

            

            if ((Text.IndexOf('.') >= 0 ||SelectionStart == 0) &&
                e.KeyChar == '.' ||
                (SelectionStart != 0 && e.KeyChar == '-'))
                e.Handled = true;

            if (Text.IndexOf('0') == 0 &&
                (e.KeyChar == '0' || e.KeyChar != '.') &&
                SelectionStart == 1 ||
                (SelectionStart == 0 && Text == @"0"))
                Text = "";



        }

        private void CheckInput(KeyEventArgs e)
        {
            var MaxTextLength = 6;
            var MaxFract = 2;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod
                        && e.KeyCode != Keys.Oemcomma && e.KeyCode != Keys.OemMinus
                        && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.Subtract)
                        e.SuppressKeyPress = true;
                }
            }

            if (Text.IndexOf('.') >= 0 )
                    if (Text.Substring(Text.IndexOf('.')).Length > MaxFract && e.KeyCode != Keys.Back)
                        e.SuppressKeyPress = true;

            if (Text.Length > MaxTextLength && e.KeyCode != Keys.Back || e.KeyCode == Keys.Home ||
                e.KeyCode == Keys.End || e.KeyCode ==Keys.Tab)
                e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal && Text == @"0")
            {
                Text = @"0.";
                SelectionStart = TextLength;
            }

            if (e.KeyCode == Keys.Decimal && Text.IndexOf('-') == 0 && SelectionStart == 1)
            {
                //MessageBox.Show(Text.IndexOf('-').ToString());
                e.SuppressKeyPress = true;
                
                
              //  BackColor = Color.Yellow;
                //Thread.Sleep(700);
                //BackColor = Color.Red;
                //Thread.Sleep(700);
                //BackColor = Color.Yellow;

            }
            
        }

       

        private void OmronEditKeyDown(object sender, KeyEventArgs e)
        {
           CheckInput(e);


            switch (e.KeyCode)
            {
                case Keys.Up:
                    FieldUp.Focus();
                    break;
                case Keys.Down:
                   FieldDown.Focus();
                    break;
                case Keys.Escape:
                    Text = @"0";
                    SelectionStart = 0;
                    break;
                case Keys.Right:
                    ChangeValue(TypeContent, Operation.Increment);
                    break;
                case Keys.Left:
                    ChangeValue(TypeContent,Operation.Decrement);
                    break;
            }
        }


        private void ChangeValue(ContentType type, Operation op)
        {
            switch (type)
            {
                case ContentType.NumInt:

                    var i = int.Parse(Text);
                    if (op == Operation.Increment && i < MaxError) i+=(int)Step;
                    if (op == Operation.Decrement && i > MinError) i -=(int)Step;
                    Text = i.ToString();
                    break;
                case ContentType.NumFloat:
                    var f = float.Parse(Text);
                    if (op == Operation.Increment && f<MaxError) f+=Step;
                    if (op == Operation.Decrement && f> MinError) f-=Step;
                    Text = f.ToString();
                    break;
                case ContentType.Automan:
                    break;
                case ContentType.OnOff:
                    break;
                case ContentType.Mode:
                    break;
                default:
                    MessageBox.Show(@"Error in IncValue");
                    break;
            }
            SelectionStart = TextLength;
        }



        private void OmronEditLeave(object sender, EventArgs e)
        {
            BackColor = Color.DarkKhaki;
            if (Text == "" || Text == @"-")
                Text = @"0";

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