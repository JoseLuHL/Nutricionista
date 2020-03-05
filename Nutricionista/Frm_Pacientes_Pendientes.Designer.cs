namespace Nutricionista
{
    partial class Frm_Pacientes_Pendientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.DgvPendientes = new System.Windows.Forms.DataGridView();
            this.DgvPendientesColNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesColDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesNombrecompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPendientesProfesional = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvPendientesEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabDatosConsulta = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.TabDatosConsulta);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 66);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1090, 668);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage10.Controls.Add(this.DgvPendientes);
            this.tabPage10.Location = new System.Drawing.Point(4, 29);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1082, 635);
            this.tabPage10.TabIndex = 10;
            this.tabPage10.Text = "Pacientes Pendientes";
            // 
            // DgvPendientes
            // 
            this.DgvPendientes.AllowUserToAddRows = false;
            this.DgvPendientes.AllowUserToDeleteRows = false;
            this.DgvPendientes.AllowUserToOrderColumns = true;
            this.DgvPendientes.AllowUserToResizeColumns = false;
            this.DgvPendientes.AllowUserToResizeRows = false;
            this.DgvPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPendientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvPendientesColNumero,
            this.DgvPendientesColDocumento,
            this.DgvPendientesNombrecompleto,
            this.DgvPendientesFecha,
            this.DgvPendientesHora,
            this.DgvPendientesMotivo,
            this.DgvPendientesProfesional,
            this.DgvPendientesEstado});
            this.DgvPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvPendientes.Location = new System.Drawing.Point(8, 13);
            this.DgvPendientes.Name = "DgvPendientes";
            this.DgvPendientes.RowHeadersVisible = false;
            this.DgvPendientes.Size = new System.Drawing.Size(1066, 454);
            this.DgvPendientes.TabIndex = 131;
            this.DgvPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPendientes_CellDoubleClick);
            // 
            // DgvPendientesColNumero
            // 
            this.DgvPendientesColNumero.HeaderText = "Numero";
            this.DgvPendientesColNumero.Name = "DgvPendientesColNumero";
            this.DgvPendientesColNumero.Visible = false;
            // 
            // DgvPendientesColDocumento
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DgvPendientesColDocumento.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPendientesColDocumento.HeaderText = "Documento";
            this.DgvPendientesColDocumento.Name = "DgvPendientesColDocumento";
            // 
            // DgvPendientesNombrecompleto
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DgvPendientesNombrecompleto.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvPendientesNombrecompleto.HeaderText = "Nombre";
            this.DgvPendientesNombrecompleto.Name = "DgvPendientesNombrecompleto";
            this.DgvPendientesNombrecompleto.ReadOnly = true;
            this.DgvPendientesNombrecompleto.Width = 240;
            // 
            // DgvPendientesFecha
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.DgvPendientesFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvPendientesFecha.HeaderText = "Fecha";
            this.DgvPendientesFecha.Name = "DgvPendientesFecha";
            this.DgvPendientesFecha.ReadOnly = true;
            // 
            // DgvPendientesHora
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.DgvPendientesHora.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPendientesHora.HeaderText = "Hora";
            this.DgvPendientesHora.Name = "DgvPendientesHora";
            this.DgvPendientesHora.ReadOnly = true;
            this.DgvPendientesHora.Width = 80;
            // 
            // DgvPendientesMotivo
            // 
            this.DgvPendientesMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.DgvPendientesMotivo.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvPendientesMotivo.HeaderText = "Motivo Consulta";
            this.DgvPendientesMotivo.Name = "DgvPendientesMotivo";
            // 
            // DgvPendientesProfesional
            // 
            this.DgvPendientesProfesional.HeaderText = "Profesional";
            this.DgvPendientesProfesional.Name = "DgvPendientesProfesional";
            this.DgvPendientesProfesional.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPendientesProfesional.Width = 180;
            // 
            // DgvPendientesEstado
            // 
            this.DgvPendientesEstado.HeaderText = "Estado";
            this.DgvPendientesEstado.Name = "DgvPendientesEstado";
            this.DgvPendientesEstado.Visible = false;
            // 
            // TabDatosConsulta
            // 
            this.TabDatosConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.TabDatosConsulta.Location = new System.Drawing.Point(4, 29);
            this.TabDatosConsulta.MinimumSize = new System.Drawing.Size(126, 39);
            this.TabDatosConsulta.Name = "TabDatosConsulta";
            this.TabDatosConsulta.Size = new System.Drawing.Size(1082, 635);
            this.TabDatosConsulta.TabIndex = 11;
            this.TabDatosConsulta.Text = "Pacientes Atendidos";
            this.TabDatosConsulta.UseVisualStyleBackColor = true;
            // 
            // Frm_Pacientes_Pendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 694);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Pacientes_Pendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes pendientes";
            this.Load += new System.EventHandler(this.Frm_Pacientes_Pendientes_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage TabDatosConsulta;
        private System.Windows.Forms.DataGridView DgvPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesColNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesColDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesNombrecompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesMotivo;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvPendientesProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPendientesEstado;
    }
}