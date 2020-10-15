namespace ProyectoForms.Clases
{
    partial class PanelTexto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textEntrada = new System.Windows.Forms.RichTextBox();
            this.lineasNumeros = new System.Windows.Forms.PictureBox();
            this.labelPoint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lineasNumeros)).BeginInit();
            this.SuspendLayout();
            // 
            // textEntrada
            // 
            this.textEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEntrada.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textEntrada.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textEntrada.HideSelection = false;
            this.textEntrada.Location = new System.Drawing.Point(40, 0);
            this.textEntrada.Name = "textEntrada";
            this.textEntrada.Size = new System.Drawing.Size(869, 459);
            this.textEntrada.TabIndex = 0;
            this.textEntrada.Text = "";
            this.textEntrada.SelectionChanged += new System.EventHandler(this.textEntrada_SelectionChanged);
            this.textEntrada.VScroll += new System.EventHandler(this.textEntrada_VScroll);
            this.textEntrada.TextChanged += new System.EventHandler(this.textEntrada_TextChanged);
            this.textEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEntrada_KeyPress);
            // 
            // lineasNumeros
            // 
            this.lineasNumeros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lineasNumeros.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lineasNumeros.Location = new System.Drawing.Point(0, 0);
            this.lineasNumeros.Name = "lineasNumeros";
            this.lineasNumeros.Size = new System.Drawing.Size(42, 459);
            this.lineasNumeros.TabIndex = 3;
            this.lineasNumeros.TabStop = false;
            this.lineasNumeros.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // labelPoint
            // 
            this.labelPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoint.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelPoint.Location = new System.Drawing.Point(0, 455);
            this.labelPoint.Name = "labelPoint";
            this.labelPoint.Size = new System.Drawing.Size(909, 36);
            this.labelPoint.TabIndex = 1;
            this.labelPoint.Text = "Fila: 0 Columna: 0";
            // 
            // PanelTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.labelPoint);
            this.Controls.Add(this.lineasNumeros);
            this.Controls.Add(this.textEntrada);
            this.Name = "PanelTexto";
            this.Size = new System.Drawing.Size(909, 491);
            ((System.ComponentModel.ISupportInitialize)(this.lineasNumeros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textEntrada;
        private System.Windows.Forms.PictureBox lineasNumeros;
        private System.Windows.Forms.Label labelPoint;
    }
}
