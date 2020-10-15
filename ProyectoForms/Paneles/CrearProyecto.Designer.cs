namespace ProyectoForms.EntradasTexto
{
    partial class CrearProyecto
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearProyecto));
            this.label1 = new System.Windows.Forms.Label();
            this.textNombreProyecto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.buttonSeleccion = new System.Windows.Forms.Button();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Proyecto:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textNombreProyecto
            // 
            this.textNombreProyecto.Location = new System.Drawing.Point(12, 41);
            this.textNombreProyecto.Name = "textNombreProyecto";
            this.textNombreProyecto.Size = new System.Drawing.Size(516, 27);
            this.textNombreProyecto.TabIndex = 1;
            this.textNombreProyecto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombreProyecto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ruta de Acceso:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // textPath
            // 
            this.textPath.Enabled = false;
            this.textPath.Location = new System.Drawing.Point(12, 102);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(478, 27);
            this.textPath.TabIndex = 1;
            // 
            // buttonSeleccion
            // 
            this.buttonSeleccion.Image = ((System.Drawing.Image)(resources.GetObject("buttonSeleccion.Image")));
            this.buttonSeleccion.Location = new System.Drawing.Point(496, 102);
            this.buttonSeleccion.Name = "buttonSeleccion";
            this.buttonSeleccion.Size = new System.Drawing.Size(29, 26);
            this.buttonSeleccion.TabIndex = 2;
            this.buttonSeleccion.UseVisualStyleBackColor = true;
            this.buttonSeleccion.Click += new System.EventHandler(this.buttonSeleccion_Click);
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(434, 147);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(94, 29);
            this.buttonCrear.TabIndex = 3;
            this.buttonCrear.Text = "Crear";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(12, 147);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(94, 29);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // CrearProyecto
            // 
            this.AcceptButton = this.buttonCrear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(534, 185);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.buttonSeleccion);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textNombreProyecto);
            this.Controls.Add(this.label1);
            this.Name = "CrearProyecto";
            this.Text = "Nuevo Proyecto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombreProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button buttonSeleccion;
        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.Button buttonCancelar;
    }
}