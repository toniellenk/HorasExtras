namespace ControleHorasExtras
{
    partial class TelaInicial
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
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuColaboradores = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuManutencao = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHorasExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.ButAdicionar = new System.Windows.Forms.Button();
            this.ButAlterar = new System.Windows.Forms.Button();
            this.ButRemover = new System.Windows.Forms.Button();
            this.ButHorasExtras = new System.Windows.Forms.Button();
            this.LabTotal = new System.Windows.Forms.Label();
            this.LabValorTotal = new System.Windows.Forms.Label();
            this.ComboBoxColaborador = new System.Windows.Forms.ComboBox();
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.BackColor = System.Drawing.Color.DarkGray;
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastros,
            this.MenuManutencao});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Margin = new System.Windows.Forms.Padding(1);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(984, 29);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "MenuPrincipal";
            // 
            // MenuCadastros
            // 
            this.MenuCadastros.BackColor = System.Drawing.SystemColors.Window;
            this.MenuCadastros.CheckOnClick = true;
            this.MenuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuColaboradores});
            this.MenuCadastros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCadastros.ForeColor = System.Drawing.Color.Black;
            this.MenuCadastros.MergeIndex = 1;
            this.MenuCadastros.Name = "MenuCadastros";
            this.MenuCadastros.Size = new System.Drawing.Size(91, 25);
            this.MenuCadastros.Text = "Cadastros";
            // 
            // MenuColaboradores
            // 
            this.MenuColaboradores.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuColaboradores.Name = "MenuColaboradores";
            this.MenuColaboradores.Size = new System.Drawing.Size(166, 22);
            this.MenuColaboradores.Text = "Colaboradores";
            this.MenuColaboradores.Click += new System.EventHandler(this.MenuColaboradores_Click);
            // 
            // MenuManutencao
            // 
            this.MenuManutencao.BackColor = System.Drawing.SystemColors.Window;
            this.MenuManutencao.CheckOnClick = true;
            this.MenuManutencao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHorasExtras});
            this.MenuManutencao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuManutencao.ForeColor = System.Drawing.Color.Black;
            this.MenuManutencao.MergeIndex = 1;
            this.MenuManutencao.Name = "MenuManutencao";
            this.MenuManutencao.Size = new System.Drawing.Size(108, 25);
            this.MenuManutencao.Text = "Manutenção";
            // 
            // MenuHorasExtras
            // 
            this.MenuHorasExtras.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuHorasExtras.Name = "MenuHorasExtras";
            this.MenuHorasExtras.Size = new System.Drawing.Size(152, 22);
            this.MenuHorasExtras.Text = "Horas Extras";
            this.MenuHorasExtras.Click += new System.EventHandler(this.MenuHorasExtras_Click);
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToAddRows = false;
            this.GridPrincipal.AllowUserToDeleteRows = false;
            this.GridPrincipal.AllowUserToOrderColumns = true;
            this.GridPrincipal.AllowUserToResizeColumns = false;
            this.GridPrincipal.AllowUserToResizeRows = false;
            this.GridPrincipal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridPrincipal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrincipal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GridPrincipal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GridPrincipal.Location = new System.Drawing.Point(102, 110);
            this.GridPrincipal.MultiSelect = false;
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.ReadOnly = true;
            this.GridPrincipal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridPrincipal.RowHeadersVisible = false;
            this.GridPrincipal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.GridPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridPrincipal.Size = new System.Drawing.Size(766, 337);
            this.GridPrincipal.StandardTab = true;
            this.GridPrincipal.TabIndex = 1;
            // 
            // ButAdicionar
            // 
            this.ButAdicionar.Location = new System.Drawing.Point(102, 467);
            this.ButAdicionar.Name = "ButAdicionar";
            this.ButAdicionar.Size = new System.Drawing.Size(75, 23);
            this.ButAdicionar.TabIndex = 2;
            this.ButAdicionar.Text = "Adicionar";
            this.ButAdicionar.UseVisualStyleBackColor = true;
            this.ButAdicionar.Click += new System.EventHandler(this.ButAdicionar_Click);
            // 
            // ButAlterar
            // 
            this.ButAlterar.Location = new System.Drawing.Point(183, 467);
            this.ButAlterar.Name = "ButAlterar";
            this.ButAlterar.Size = new System.Drawing.Size(75, 23);
            this.ButAlterar.TabIndex = 3;
            this.ButAlterar.Text = "Alterar";
            this.ButAlterar.UseVisualStyleBackColor = true;
            this.ButAlterar.Click += new System.EventHandler(this.ButAlterar_Click);
            // 
            // ButRemover
            // 
            this.ButRemover.Location = new System.Drawing.Point(264, 467);
            this.ButRemover.Name = "ButRemover";
            this.ButRemover.Size = new System.Drawing.Size(75, 23);
            this.ButRemover.TabIndex = 4;
            this.ButRemover.Text = "Remover";
            this.ButRemover.UseVisualStyleBackColor = true;
            this.ButRemover.Click += new System.EventHandler(this.ButRemover_Click);
            // 
            // ButHorasExtras
            // 
            this.ButHorasExtras.Location = new System.Drawing.Point(345, 467);
            this.ButHorasExtras.Name = "ButHorasExtras";
            this.ButHorasExtras.Size = new System.Drawing.Size(122, 23);
            this.ButHorasExtras.TabIndex = 5;
            this.ButHorasExtras.Text = "Adicionar Horas Extras";
            this.ButHorasExtras.UseVisualStyleBackColor = true;
            this.ButHorasExtras.Click += new System.EventHandler(this.ButHorasExtras_Click);
            // 
            // LabTotal
            // 
            this.LabTotal.AutoSize = true;
            this.LabTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTotal.ForeColor = System.Drawing.Color.Blue;
            this.LabTotal.Location = new System.Drawing.Point(698, 472);
            this.LabTotal.Name = "LabTotal";
            this.LabTotal.Size = new System.Drawing.Size(93, 13);
            this.LabTotal.TabIndex = 6;
            this.LabTotal.Text = "Total da Folha:";
            this.LabTotal.Click += new System.EventHandler(this.LabTotal_Click);
            // 
            // LabValorTotal
            // 
            this.LabValorTotal.AutoSize = true;
            this.LabValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabValorTotal.ForeColor = System.Drawing.Color.Red;
            this.LabValorTotal.Location = new System.Drawing.Point(797, 472);
            this.LabValorTotal.Name = "LabValorTotal";
            this.LabValorTotal.Size = new System.Drawing.Size(0, 13);
            this.LabValorTotal.TabIndex = 7;
            // 
            // ComboBoxColaborador
            // 
            this.ComboBoxColaborador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxColaborador.FormattingEnabled = true;
            this.ComboBoxColaborador.Location = new System.Drawing.Point(102, 83);
            this.ComboBoxColaborador.Name = "ComboBoxColaborador";
            this.ComboBoxColaborador.Size = new System.Drawing.Size(288, 21);
            this.ComboBoxColaborador.TabIndex = 8;
            this.ComboBoxColaborador.TextChanged += new System.EventHandler(this.ComboBoxColaborador_AlteraValor);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.ComboBoxColaborador);
            this.Controls.Add(this.LabValorTotal);
            this.Controls.Add(this.LabTotal);
            this.Controls.Add(this.ButHorasExtras);
            this.Controls.Add(this.ButRemover);
            this.Controls.Add(this.ButAlterar);
            this.Controls.Add(this.ButAdicionar);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.MenuPrincipal);
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "TelaInicial";
            this.Text = "Super Controlador de Horas Extras";
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuColaboradores;
        private System.Windows.Forms.ToolStripMenuItem MenuManutencao;
        private System.Windows.Forms.ToolStripMenuItem MenuHorasExtras;
        public  System.Windows.Forms.DataGridView GridPrincipal;
        private System.Windows.Forms.Button ButAdicionar;
        private System.Windows.Forms.Button ButAlterar;
        private System.Windows.Forms.Button ButRemover;
        private System.Windows.Forms.Button ButHorasExtras;
        private System.Windows.Forms.Label LabTotal;
        private System.Windows.Forms.Label LabValorTotal;
        private System.Windows.Forms.ComboBox ComboBoxColaborador;
    }
}

