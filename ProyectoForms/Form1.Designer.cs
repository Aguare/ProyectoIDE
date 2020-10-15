namespace ProyectoForms
{
    partial class ventanaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventanaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCrear = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGuardarCambios = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablaControl = new System.Windows.Forms.TabControl();
            this.textErrores = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.arbolArchivos = new System.Windows.Forms.TreeView();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonCrear = new System.Windows.Forms.ToolStripButton();
            this.buttonGuardar = new System.Windows.Forms.ToolStripButton();
            this.buttonEliminarArch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.buttonCerrarArch = new System.Windows.Forms.ToolStripButton();
            this.buttonCompilar = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemArchivo,
            this.itemAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked_1);
            // 
            // itemArchivo
            // 
            this.itemArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbrir,
            this.itemCrear,
            this.itemGuardarCambios,
            this.itemCerrar,
            this.itemEliminar});
            this.itemArchivo.Name = "itemArchivo";
            this.itemArchivo.Size = new System.Drawing.Size(73, 24);
            this.itemArchivo.Text = "Archivo";
            // 
            // itemAbrir
            // 
            this.itemAbrir.Image = ((System.Drawing.Image)(resources.GetObject("itemAbrir.Image")));
            this.itemAbrir.Name = "itemAbrir";
            this.itemAbrir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itemAbrir.Size = new System.Drawing.Size(329, 26);
            this.itemAbrir.Text = "Abrir";
            // 
            // itemCrear
            // 
            this.itemCrear.Image = ((System.Drawing.Image)(resources.GetObject("itemCrear.Image")));
            this.itemCrear.Name = "itemCrear";
            this.itemCrear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.itemCrear.Size = new System.Drawing.Size(329, 26);
            this.itemCrear.Text = "Nuevo Proyecto";
            // 
            // itemGuardarCambios
            // 
            this.itemGuardarCambios.Image = ((System.Drawing.Image)(resources.GetObject("itemGuardarCambios.Image")));
            this.itemGuardarCambios.Name = "itemGuardarCambios";
            this.itemGuardarCambios.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itemGuardarCambios.Size = new System.Drawing.Size(329, 26);
            this.itemGuardarCambios.Text = "Guardar Cambios";
            // 
            // itemCerrar
            // 
            this.itemCerrar.Image = ((System.Drawing.Image)(resources.GetObject("itemCerrar.Image")));
            this.itemCerrar.Name = "itemCerrar";
            this.itemCerrar.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.itemCerrar.Size = new System.Drawing.Size(329, 26);
            this.itemCerrar.Text = "Cerrar Proyecto";
            // 
            // itemEliminar
            // 
            this.itemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("itemEliminar.Image")));
            this.itemEliminar.Name = "itemEliminar";
            this.itemEliminar.Size = new System.Drawing.Size(329, 26);
            this.itemEliminar.Text = "Eliminar Proyecto";
            // 
            // itemAyuda
            // 
            this.itemAyuda.Name = "itemAyuda";
            this.itemAyuda.Size = new System.Drawing.Size(65, 24);
            this.itemAyuda.Text = "Ayuda";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.tablaControl);
            this.panel1.Controls.Add(this.textErrores);
            this.panel1.Location = new System.Drawing.Point(217, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 663);
            this.panel1.TabIndex = 4;
            // 
            // tablaControl
            // 
            this.tablaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaControl.Location = new System.Drawing.Point(11, 0);
            this.tablaControl.Name = "tablaControl";
            this.tablaControl.SelectedIndex = 0;
            this.tablaControl.Size = new System.Drawing.Size(923, 530);
            this.tablaControl.TabIndex = 4;
            this.tablaControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tablaControl.SizeChanged += new System.EventHandler(this.tablaControl_SizeChanged);
            this.tablaControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tablaControl_MouseDoubleClick);
            // 
            // textErrores
            // 
            this.textErrores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textErrores.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textErrores.ForeColor = System.Drawing.Color.Red;
            this.textErrores.Location = new System.Drawing.Point(11, 536);
            this.textErrores.Name = "textErrores";
            this.textErrores.Size = new System.Drawing.Size(923, 115);
            this.textErrores.TabIndex = 2;
            this.textErrores.Text = "\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.arbolArchivos);
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 663);
            this.panel2.TabIndex = 5;
            // 
            // arbolArchivos
            // 
            this.arbolArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.arbolArchivos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.arbolArchivos.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.arbolArchivos.Location = new System.Drawing.Point(0, 0);
            this.arbolArchivos.Name = "arbolArchivos";
            this.arbolArchivos.Size = new System.Drawing.Size(222, 663);
            this.arbolArchivos.TabIndex = 0;
            this.arbolArchivos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.arbolArchivos_MouseDoubleClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem2.Text = "Crear";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem4.Text = "Cerrar Proyecto";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem5.Text = "Eliminar Proyecto";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(208, 26);
            this.toolStripMenuItem6.Text = "Crear Proyecto";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(208, 26);
            this.toolStripMenuItem7.Text = "Cerrar Proyecto";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(208, 26);
            this.toolStripMenuItem8.Text = "Eliminar Proyecto";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCrear,
            this.buttonGuardar,
            this.buttonEliminarArch,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.buttonCerrarArch,
            this.buttonCompilar});
            this.toolStrip2.Location = new System.Drawing.Point(0, 28);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1163, 27);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // buttonCrear
            // 
            this.buttonCrear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCrear.Image = ((System.Drawing.Image)(resources.GetObject("buttonCrear.Image")));
            this.buttonCrear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(29, 24);
            this.buttonCrear.Text = "Crear Archivo";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("buttonGuardar.Image")));
            this.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(29, 24);
            this.buttonGuardar.Text = "Guardar Cambios";
            // 
            // buttonEliminarArch
            // 
            this.buttonEliminarArch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEliminarArch.Image = ((System.Drawing.Image)(resources.GetObject("buttonEliminarArch.Image")));
            this.buttonEliminarArch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEliminarArch.Name = "buttonEliminarArch";
            this.buttonEliminarArch.Size = new System.Drawing.Size(29, 24);
            this.buttonEliminarArch.Text = "Eliminar Archivo";
            this.buttonEliminarArch.ToolTipText = "Eliminar Archivo Actual";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 27);
            this.toolStripTextBox1.Text = "MARCOS AGUARE";
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCerrarArch
            // 
            this.buttonCerrarArch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCerrarArch.Image = ((System.Drawing.Image)(resources.GetObject("buttonCerrarArch.Image")));
            this.buttonCerrarArch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCerrarArch.Name = "buttonCerrarArch";
            this.buttonCerrarArch.Size = new System.Drawing.Size(29, 24);
            this.buttonCerrarArch.Text = "buttonCerrar";
            this.buttonCerrarArch.ToolTipText = "Cerrar Archivo Actual";
            // 
            // buttonCompilar
            // 
            this.buttonCompilar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCompilar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCompilar.Image")));
            this.buttonCompilar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCompilar.Name = "buttonCompilar";
            this.buttonCompilar.Size = new System.Drawing.Size(29, 24);
            this.buttonCompilar.Text = "Compilar";
            // 
            // ventanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1163, 722);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ventanaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDE-AGUARE";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem itemArchivo;
        private System.Windows.Forms.ToolStripMenuItem itemAbrir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox textErrores;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView arbolArchivos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem itemCrear;
        private System.Windows.Forms.ToolStripMenuItem itemCerrar;
        private System.Windows.Forms.ToolStripMenuItem itemEliminar;
        private System.Windows.Forms.ToolStripMenuItem itemAyuda;
        private System.Windows.Forms.TabControl tablaControl;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton buttonCrear;
        private System.Windows.Forms.ToolStripButton buttonGuardar;
        private System.Windows.Forms.ToolStripMenuItem itemGuardarCambios;
        private System.Windows.Forms.ToolStripButton buttonEliminarArch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton buttonCerrarArch;
        private System.Windows.Forms.ToolStripButton buttonCompilar;
    }
}

