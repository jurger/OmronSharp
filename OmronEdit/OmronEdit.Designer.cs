namespace OmronEdit
{
    partial class OmronEdit
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Enter += new System.EventHandler(this.OmronEditEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OmronEditKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OmronEditKeyPress);
            this.Leave += new System.EventHandler(this.OmronEditLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
