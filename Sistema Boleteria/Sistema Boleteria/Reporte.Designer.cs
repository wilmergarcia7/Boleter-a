
namespace Sistema_Boleteria
{
    partial class Reporte
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVentasBoletos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVentaUsuarios = new System.Windows.Forms.Button();
            this.btnReporteDestino = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSalir.Location = new System.Drawing.Point(81, 391);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(131, 33);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "REGRESAR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnVentasBoletos
            // 
            this.btnVentasBoletos.BackColor = System.Drawing.SystemColors.Control;
            this.btnVentasBoletos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasBoletos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVentasBoletos.Location = new System.Drawing.Point(33, 127);
            this.btnVentasBoletos.Name = "btnVentasBoletos";
            this.btnVentasBoletos.Size = new System.Drawing.Size(228, 34);
            this.btnVentasBoletos.TabIndex = 1;
            this.btnVentasBoletos.Text = "Exportar PDF";
            this.btnVentasBoletos.UseVisualStyleBackColor = false;
            this.btnVentasBoletos.Click += new System.EventHandler(this.btnVentasBoletos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 38);
            this.label1.TabIndex = 13;
            this.label1.Text = "REPORTES";
            // 
            // btnVentaUsuarios
            // 
            this.btnVentaUsuarios.BackColor = System.Drawing.SystemColors.Control;
            this.btnVentaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentaUsuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVentaUsuarios.Location = new System.Drawing.Point(33, 212);
            this.btnVentaUsuarios.Name = "btnVentaUsuarios";
            this.btnVentaUsuarios.Size = new System.Drawing.Size(228, 34);
            this.btnVentaUsuarios.TabIndex = 2;
            this.btnVentaUsuarios.Text = "Exportar PDF";
            this.btnVentaUsuarios.UseVisualStyleBackColor = false;
            this.btnVentaUsuarios.Click += new System.EventHandler(this.btnVentaUsuarios_Click);
            // 
            // btnReporteDestino
            // 
            this.btnReporteDestino.BackColor = System.Drawing.SystemColors.Control;
            this.btnReporteDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteDestino.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporteDestino.Location = new System.Drawing.Point(33, 303);
            this.btnReporteDestino.Name = "btnReporteDestino";
            this.btnReporteDestino.Size = new System.Drawing.Size(228, 34);
            this.btnReporteDestino.TabIndex = 3;
            this.btnReporteDestino.Text = "Exportar PDF";
            this.btnReporteDestino.UseVisualStyleBackColor = false;
            this.btnReporteDestino.Click += new System.EventHandler(this.btnReporteDestino_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(36, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Reporte Venta Boletos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(33, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Reporte Venta por Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(36, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Reporte Venta por Destino:";
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(329, 445);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReporteDestino);
            this.Controls.Add(this.btnVentaUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVentasBoletos);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnVentasBoletos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVentaUsuarios;
        private System.Windows.Forms.Button btnReporteDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}