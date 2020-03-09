namespace Nutricionista.Citas
{
    partial class FrmHorario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHorario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnEliminarFila = new iTalk.iTalk_Button_1();
            this.BtnNuevaFila = new iTalk.iTalk_Button_1();
            this.iTalk_Panel1 = new iTalk.iTalk_Panel();
            this.DgvHorario = new System.Windows.Forms.DataGridView();
            this.iTalk_GroupBox1 = new iTalk.iTalk_GroupBox();
            this.Btn_LupaBuscar = new System.Windows.Forms.Button();
            this.LblNombre = new iTalk.iTalk_Label();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.iTalk_Label3 = new iTalk.iTalk_Label();
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.BtnGuardar = new iTalk.iTalk_Button_2();
            this.IndicadorOcupado = new iTalk.iTalk_ProgressIndicator();
            this.DgvHorarioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorariofecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioHorainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioHorafinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioActivar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iTalk_Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHorario)).BeginInit();
            this.iTalk_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEliminarFila
            // 
            this.BtnEliminarFila.BackColor = System.Drawing.Color.Transparent;
            this.BtnEliminarFila.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnEliminarFila.Image = null;
            this.BtnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminarFila.Location = new System.Drawing.Point(63, 451);
            this.BtnEliminarFila.Name = "BtnEliminarFila";
            this.BtnEliminarFila.Size = new System.Drawing.Size(42, 38);
            this.BtnEliminarFila.TabIndex = 136;
            this.BtnEliminarFila.Text = "-";
            this.BtnEliminarFila.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnEliminarFila.Click += new System.EventHandler(this.BtnEliminarFila_Click);
            // 
            // BtnNuevaFila
            // 
            this.BtnNuevaFila.BackColor = System.Drawing.Color.Transparent;
            this.BtnNuevaFila.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnNuevaFila.Image = null;
            this.BtnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevaFila.Location = new System.Drawing.Point(12, 451);
            this.BtnNuevaFila.Name = "BtnNuevaFila";
            this.BtnNuevaFila.Size = new System.Drawing.Size(45, 38);
            this.BtnNuevaFila.TabIndex = 135;
            this.BtnNuevaFila.Text = "+";
            this.BtnNuevaFila.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnNuevaFila.Click += new System.EventHandler(this.BtnNuevaFila_Click);
            // 
            // iTalk_Panel1
            // 
            this.iTalk_Panel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel1.Controls.Add(this.DgvHorario);
            this.iTalk_Panel1.Location = new System.Drawing.Point(12, 192);
            this.iTalk_Panel1.Name = "iTalk_Panel1";
            this.iTalk_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel1.Size = new System.Drawing.Size(792, 255);
            this.iTalk_Panel1.TabIndex = 16;
            this.iTalk_Panel1.Text = "iTalk_Panel1";
            // 
            // DgvHorario
            // 
            this.DgvHorario.AllowUserToAddRows = false;
            this.DgvHorario.BackgroundColor = System.Drawing.Color.White;
            this.DgvHorario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvHorario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvHorario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHorario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvHorario.ColumnHeadersHeight = 30;
            this.DgvHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvHorarioid,
            this.DgvHorariofecha,
            this.DgvHorarioHorainicio,
            this.DgvHorarioHorafinal,
            this.DgvHorarioNota,
            this.DgvHorarioActivar});
            this.DgvHorario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvHorario.Location = new System.Drawing.Point(13, 11);
            this.DgvHorario.Name = "DgvHorario";
            this.DgvHorario.RowHeadersVisible = false;
            this.DgvHorario.Size = new System.Drawing.Size(763, 228);
            this.DgvHorario.TabIndex = 11;
            // 
            // iTalk_GroupBox1
            // 
            this.iTalk_GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_GroupBox1.Controls.Add(this.Btn_LupaBuscar);
            this.iTalk_GroupBox1.Controls.Add(this.LblNombre);
            this.iTalk_GroupBox1.Controls.Add(this.txtMedico);
            this.iTalk_GroupBox1.Controls.Add(this.iTalk_Label3);
            this.iTalk_GroupBox1.Controls.Add(this.iTalk_Label2);
            this.iTalk_GroupBox1.Location = new System.Drawing.Point(12, 72);
            this.iTalk_GroupBox1.MinimumSize = new System.Drawing.Size(136, 50);
            this.iTalk_GroupBox1.Name = "iTalk_GroupBox1";
            this.iTalk_GroupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.iTalk_GroupBox1.Size = new System.Drawing.Size(790, 104);
            this.iTalk_GroupBox1.TabIndex = 15;
            this.iTalk_GroupBox1.Text = "Medico";
            // 
            // Btn_LupaBuscar
            // 
            this.Btn_LupaBuscar.BackColor = System.Drawing.Color.Ivory;
            this.Btn_LupaBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_LupaBuscar.BackgroundImage")));
            this.Btn_LupaBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_LupaBuscar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LupaBuscar.Location = new System.Drawing.Point(280, 46);
            this.Btn_LupaBuscar.Name = "Btn_LupaBuscar";
            this.Btn_LupaBuscar.Size = new System.Drawing.Size(32, 27);
            this.Btn_LupaBuscar.TabIndex = 19;
            this.Btn_LupaBuscar.UseVisualStyleBackColor = false;
            this.Btn_LupaBuscar.Click += new System.EventHandler(this.Btn_LupaBuscar_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.BackColor = System.Drawing.Color.Transparent;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.LblNombre.Location = new System.Drawing.Point(430, 47);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(81, 25);
            this.LblNombre.TabIndex = 18;
            this.LblNombre.Text = "Nombre";
            // 
            // txtMedico
            // 
            this.txtMedico.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedico.Location = new System.Drawing.Point(113, 46);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Size = new System.Drawing.Size(161, 27);
            this.txtMedico.TabIndex = 17;
            this.txtMedico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMedico_KeyDown_1);
            // 
            // iTalk_Label3
            // 
            this.iTalk_Label3.AutoSize = true;
            this.iTalk_Label3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label3.Location = new System.Drawing.Point(360, 49);
            this.iTalk_Label3.Name = "iTalk_Label3";
            this.iTalk_Label3.Size = new System.Drawing.Size(64, 20);
            this.iTalk_Label3.TabIndex = 16;
            this.iTalk_Label3.Text = "Nombre";
            // 
            // iTalk_Label2
            // 
            this.iTalk_Label2.AutoSize = true;
            this.iTalk_Label2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label2.Location = new System.Drawing.Point(8, 48);
            this.iTalk_Label2.Name = "iTalk_Label2";
            this.iTalk_Label2.Size = new System.Drawing.Size(99, 20);
            this.iTalk_Label2.TabIndex = 14;
            this.iTalk_Label2.Text = "Identificación";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(121, 469);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(42, 20);
            this.iTalk_Label1.TabIndex = 12;
            this.iTalk_Label1.Text = "Nota";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = null;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(636, 464);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(166, 40);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // IndicadorOcupado
            // 
            this.IndicadorOcupado.BackColor = System.Drawing.Color.White;
            this.IndicadorOcupado.Location = new System.Drawing.Point(483, 446);
            this.IndicadorOcupado.MinimumSize = new System.Drawing.Size(80, 80);
            this.IndicadorOcupado.Name = "IndicadorOcupado";
            this.IndicadorOcupado.P_AnimationColor = System.Drawing.Color.Gainsboro;
            this.IndicadorOcupado.P_AnimationSpeed = 100;
            this.IndicadorOcupado.P_BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(14)))), ((int)(((byte)(59)))));
            this.IndicadorOcupado.Size = new System.Drawing.Size(80, 80);
            this.IndicadorOcupado.TabIndex = 132;
            this.IndicadorOcupado.Text = "iTalk_ProgressIndicator1";
            this.IndicadorOcupado.Visible = false;
            // 
            // DgvHorarioid
            // 
            this.DgvHorarioid.Frozen = true;
            this.DgvHorarioid.HeaderText = "id";
            this.DgvHorarioid.Name = "DgvHorarioid";
            this.DgvHorarioid.Visible = false;
            this.DgvHorarioid.Width = 50;
            // 
            // DgvHorariofecha
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = "01/01/2020";
            this.DgvHorariofecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvHorariofecha.Frozen = true;
            this.DgvHorariofecha.HeaderText = "Fecha de atención";
            this.DgvHorariofecha.MaxInputLength = 10;
            this.DgvHorariofecha.Name = "DgvHorariofecha";
            this.DgvHorariofecha.ToolTipText = "Fecha";
            this.DgvHorariofecha.Width = 150;
            // 
            // DgvHorarioHorainicio
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle8.Format = "t";
            dataGridViewCellStyle8.NullValue = "8:00 a. m.";
            this.DgvHorarioHorainicio.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvHorarioHorainicio.Frozen = true;
            this.DgvHorarioHorainicio.HeaderText = "Hora inicio";
            this.DgvHorarioHorainicio.Name = "DgvHorarioHorainicio";
            this.DgvHorarioHorainicio.Width = 110;
            // 
            // DgvHorarioHorafinal
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle9.Format = "t";
            dataGridViewCellStyle9.NullValue = "4:00 p. m.";
            this.DgvHorarioHorafinal.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvHorarioHorafinal.Frozen = true;
            this.DgvHorarioHorafinal.HeaderText = "Hora final";
            this.DgvHorarioHorafinal.Name = "DgvHorarioHorafinal";
            this.DgvHorarioHorafinal.Width = 110;
            // 
            // DgvHorarioNota
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvHorarioNota.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvHorarioNota.Frozen = true;
            this.DgvHorarioNota.HeaderText = "Nota";
            this.DgvHorarioNota.Name = "DgvHorarioNota";
            this.DgvHorarioNota.Width = 300;
            // 
            // DgvHorarioActivar
            // 
            this.DgvHorarioActivar.Frozen = true;
            this.DgvHorarioActivar.HeaderText = "Activar";
            this.DgvHorarioActivar.Name = "DgvHorarioActivar";
            this.DgvHorarioActivar.Width = 60;
            // 
            // FrmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 519);
            this.Controls.Add(this.BtnEliminarFila);
            this.Controls.Add(this.BtnNuevaFila);
            this.Controls.Add(this.iTalk_Panel1);
            this.Controls.Add(this.iTalk_GroupBox1);
            this.Controls.Add(this.iTalk_Label1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.IndicadorOcupado);
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "FrmHorario";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FrmHorario_Load);
            this.iTalk_Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHorario)).EndInit();
            this.iTalk_GroupBox1.ResumeLayout(false);
            this.iTalk_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private iTalk.iTalk_Button_2 BtnGuardar;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_GroupBox iTalk_GroupBox1;
        private iTalk.iTalk_Label iTalk_Label3;
        private iTalk.iTalk_Panel iTalk_Panel1;
        private System.Windows.Forms.DataGridView DgvHorario;
        private System.Windows.Forms.TextBox txtMedico;
        private iTalk.iTalk_Label LblNombre;
        internal System.Windows.Forms.Button Btn_LupaBuscar;
        private iTalk.iTalk_ProgressIndicator IndicadorOcupado;
        private iTalk.iTalk_Button_1 BtnNuevaFila;
        private iTalk.iTalk_Button_1 BtnEliminarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorariofecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioHorainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioHorafinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioNota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvHorarioActivar;
    }
}