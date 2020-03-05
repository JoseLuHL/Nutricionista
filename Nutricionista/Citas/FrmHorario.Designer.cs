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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHorario));
            this.iTalk_Panel1 = new iTalk.iTalk_Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DgvHorariofecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioHorainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvHorarioHorafinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iTalk_GroupBox1 = new iTalk.iTalk_GroupBox();
            this.LblNombre = new iTalk.iTalk_Label();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.iTalk_Label3 = new iTalk.iTalk_Label();
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.iTalk_Button_21 = new iTalk.iTalk_Button_2();
            this.iTalk_Icon_Tick1 = new iTalk.iTalk_Icon_Tick();
            this.Btn_LupaBuscar = new System.Windows.Forms.Button();
            this.iTalk_Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.iTalk_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTalk_Panel1
            // 
            this.iTalk_Panel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel1.Controls.Add(this.dataGridView1);
            this.iTalk_Panel1.Location = new System.Drawing.Point(12, 192);
            this.iTalk_Panel1.Name = "iTalk_Panel1";
            this.iTalk_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel1.Size = new System.Drawing.Size(792, 255);
            this.iTalk_Panel1.TabIndex = 16;
            this.iTalk_Panel1.Text = "iTalk_Panel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvHorariofecha,
            this.DgvHorarioHorainicio,
            this.DgvHorarioHorafinal,
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(13, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(763, 228);
            this.dataGridView1.TabIndex = 11;
            // 
            // DgvHorariofecha
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = "01/01/2020";
            this.DgvHorariofecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvHorariofecha.Frozen = true;
            this.DgvHorariofecha.HeaderText = "Fecha de atención";
            this.DgvHorariofecha.MaxInputLength = 10;
            this.DgvHorariofecha.Name = "DgvHorariofecha";
            this.DgvHorariofecha.ToolTipText = "Fecha";
            this.DgvHorariofecha.Width = 150;
            // 
            // DgvHorarioHorainicio
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = "8:00 a. m.";
            this.DgvHorarioHorainicio.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvHorarioHorainicio.Frozen = true;
            this.DgvHorarioHorainicio.HeaderText = "Hora inicio";
            this.DgvHorarioHorainicio.Name = "DgvHorarioHorainicio";
            this.DgvHorarioHorainicio.Width = 110;
            // 
            // DgvHorarioHorafinal
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = "4:00 p. m.";
            this.DgvHorarioHorafinal.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvHorarioHorafinal.Frozen = true;
            this.DgvHorarioHorafinal.HeaderText = "Hora final";
            this.DgvHorarioHorafinal.Name = "DgvHorarioHorafinal";
            this.DgvHorarioHorafinal.Width = 110;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Nota";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Activar";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
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
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.BackColor = System.Drawing.Color.Transparent;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.LblNombre.Location = new System.Drawing.Point(430, 49);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(64, 20);
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
            this.iTalk_Label1.Location = new System.Drawing.Point(16, 469);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(42, 20);
            this.iTalk_Label1.TabIndex = 12;
            this.iTalk_Label1.Text = "Nota";
            // 
            // iTalk_Button_21
            // 
            this.iTalk_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_21.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_21.Image = null;
            this.iTalk_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_21.Location = new System.Drawing.Point(636, 464);
            this.iTalk_Button_21.Name = "iTalk_Button_21";
            this.iTalk_Button_21.Size = new System.Drawing.Size(166, 40);
            this.iTalk_Button_21.TabIndex = 8;
            this.iTalk_Button_21.Text = "Guardar";
            this.iTalk_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iTalk_Icon_Tick1
            // 
            this.iTalk_Icon_Tick1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.iTalk_Icon_Tick1.ForeColor = System.Drawing.Color.DimGray;
            this.iTalk_Icon_Tick1.Location = new System.Drawing.Point(600, 469);
            this.iTalk_Icon_Tick1.Name = "iTalk_Icon_Tick1";
            this.iTalk_Icon_Tick1.Size = new System.Drawing.Size(33, 33);
            this.iTalk_Icon_Tick1.TabIndex = 9;
            this.iTalk_Icon_Tick1.Text = "iTalk_Icon_Tick1";
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
            // FrmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 519);
            this.Controls.Add(this.iTalk_Panel1);
            this.Controls.Add(this.iTalk_GroupBox1);
            this.Controls.Add(this.iTalk_Label1);
            this.Controls.Add(this.iTalk_Button_21);
            this.Controls.Add(this.iTalk_Icon_Tick1);
            this.Name = "FrmHorario";
            this.Text = "Asignación de Horario";
            this.Load += new System.EventHandler(this.FrmHorario_Load);
            this.iTalk_Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.iTalk_GroupBox1.ResumeLayout(false);
            this.iTalk_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private iTalk.iTalk_Button_2 iTalk_Button_21;
        private iTalk.iTalk_Icon_Tick iTalk_Icon_Tick1;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_GroupBox iTalk_GroupBox1;
        private iTalk.iTalk_Label iTalk_Label3;
        private iTalk.iTalk_Panel iTalk_Panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorariofecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioHorainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvHorarioHorafinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.TextBox txtMedico;
        private iTalk.iTalk_Label LblNombre;
        internal System.Windows.Forms.Button Btn_LupaBuscar;
    }
}