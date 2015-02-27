using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmronProject
{
    public partial class Heater : UserControl
    {
      //  public OmronEdit OEdit ;

    //    public OmronEdit OEdit1 { get; set; }
        
      

        public OmronEdit OmronEdit1
        {
            get { return omronEdit1; }
           private set { omronEdit1 = value; }
        }

        public Heater()
        {
            InitializeComponent();
            
            

        }

        private void Heater_Load(object sender, EventArgs e)
        {
            
        }
    }
}
