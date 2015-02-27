namespace OmronProject
{
    partial class Heater
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oPanel1 = new OmronProject.OPanel();
            this.omronEdit2 = new OmronProject.OmronEdit();
            this.omronEdit1 = new OmronProject.OmronEdit();
            this.oPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oPanel1
            // 
            this.oPanel1.Controls.Add(this.omronEdit2);
            this.oPanel1.Controls.Add(this.omronEdit1);
            this.oPanel1.Location = new System.Drawing.Point(0, 25);
            this.oPanel1.Name = "oPanel1";
            this.oPanel1.Size = new System.Drawing.Size(260, 251);
            this.oPanel1.TabIndex = 0;
            // 
            // omronEdit2
            // 
            this.omronEdit2.Activity = OmronProject.OmronEdit.TActivity.ActInAct;
            this.omronEdit2.FieldDown = null;
            this.omronEdit2.FieldUp = null;
            this.omronEdit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.omronEdit2.Location = new System.Drawing.Point(28, 71);
            this.omronEdit2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.omronEdit2.MaxError = 0;
            this.omronEdit2.MinError = 0;
            this.omronEdit2.Name = "omronEdit2";
            this.omronEdit2.NumsAfterDot = 0;
            this.omronEdit2.Size = new System.Drawing.Size(178, 23);
            this.omronEdit2.State = OmronProject.OmronEdit.TState.Norma;
            this.omronEdit2.Step = 0F;
            this.omronEdit2.TabIndex = 1;
            this.omronEdit2.TypeContent = OmronProject.OmronEdit.TTypeContent.NumInt;
            this.omronEdit2.Window = OmronProject.OmronEdit.TWindow.Dno;
            // 
            // omronEdit1
            // 
            this.omronEdit1.Activity = OmronProject.OmronEdit.TActivity.ActInAct;
            this.omronEdit1.FieldDown = null;
            this.omronEdit1.FieldUp = null;
            this.omronEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.omronEdit1.Location = new System.Drawing.Point(28, 34);
            this.omronEdit1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.omronEdit1.MaxError = 0;
            this.omronEdit1.MinError = 0;
            this.omronEdit1.Name = "omronEdit1";
            this.omronEdit1.NumsAfterDot = 0;
            this.omronEdit1.Size = new System.Drawing.Size(178, 23);
            this.omronEdit1.State = OmronProject.OmronEdit.TState.Norma;
            this.omronEdit1.Step = 0F;
            this.omronEdit1.TabIndex = 0;
            this.omronEdit1.TypeContent = OmronProject.OmronEdit.TTypeContent.NumInt;
            this.omronEdit1.Window = OmronProject.OmronEdit.TWindow.Dno;
            // 
            // Heater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oPanel1);
            this.Name = "Heater";
            this.Size = new System.Drawing.Size(260, 276);
            this.oPanel1.ResumeLayout(false);
            this.oPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPanel oPanel1;
        private OmronEdit omronEdit2;
        private OmronEdit omronEdit1;
    }
}
