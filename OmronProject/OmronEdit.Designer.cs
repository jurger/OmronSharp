using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OmronProject
{
    partial class OmronEdit
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OmronEdit
            // 
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new Padding(3, 1, 3, 1);
            this.Enter += new EventHandler(this.OmronEditEnter);
            this.KeyDown += new KeyEventHandler(this.OmronEditKeyDown);
            this.KeyPress += new KeyPressEventHandler(this.OmronEditKeyPress);
            this.Leave += new EventHandler(this.OmronEditLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
