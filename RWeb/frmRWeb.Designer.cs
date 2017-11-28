namespace RWeb
{
    partial class frmRWeb
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdDatos = new MetroFramework.Controls.MetroGrid();
            this.progressbar = new MetroFramework.Controls.MetroProgressBar();
            this.btnUpdateNow = new MetroFramework.Controls.MetroButton();
            this.lblProcessing = new MetroFramework.Controls.MetroLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnCerrarSesion = new MetroFramework.Controls.MetroButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblNombreActualizacion = new MetroFramework.Controls.MetroLabel();
            this.lblLastUpdate = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.AllowUserToResizeRows = false;
            this.grdDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDatos.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdDatos.EnableHeadersVisualStyles = false;
            this.grdDatos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdDatos.Location = new System.Drawing.Point(20, 60);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDatos.Size = new System.Drawing.Size(10, 158);
            this.grdDatos.TabIndex = 0;
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(20, 104);
            this.progressbar.Name = "progressbar";
            this.progressbar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressbar.Size = new System.Drawing.Size(294, 23);
            this.progressbar.TabIndex = 2;
            // 
            // btnUpdateNow
            // 
            this.btnUpdateNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateNow.Location = new System.Drawing.Point(168, 60);
            this.btnUpdateNow.Name = "btnUpdateNow";
            this.btnUpdateNow.Size = new System.Drawing.Size(146, 35);
            this.btnUpdateNow.TabIndex = 6;
            this.btnUpdateNow.Text = "Actualizar";
            this.btnUpdateNow.UseSelectable = true;
            this.btnUpdateNow.Click += new System.EventHandler(this.btnUpdateNow_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(18, 131);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(100, 19);
            this.lblProcessing.TabIndex = 8;
            this.lblProcessing.Text = "Procesando 0%";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Location = new System.Drawing.Point(20, 60);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(142, 35);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseSelectable = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblNombreActualizacion
            // 
            this.lblNombreActualizacion.AutoSize = true;
            this.lblNombreActualizacion.Location = new System.Drawing.Point(20, 153);
            this.lblNombreActualizacion.Name = "lblNombreActualizacion";
            this.lblNombreActualizacion.Size = new System.Drawing.Size(132, 19);
            this.lblNombreActualizacion.TabIndex = 10;
            this.lblNombreActualizacion.Text = "Última actualización: ";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(146, 150);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(0, 0);
            this.lblLastUpdate.TabIndex = 11;
            // 
            // frmRWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 158);
            this.ControlBox = false;
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lblNombreActualizacion);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.btnUpdateNow);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "frmRWeb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Actualización de datos";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.Load += new System.EventHandler(this.frmRWeb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid grdDatos;
        private MetroFramework.Controls.MetroProgressBar progressbar;
        private MetroFramework.Controls.MetroButton btnUpdateNow;
        private MetroFramework.Controls.MetroLabel lblProcessing;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private MetroFramework.Controls.MetroButton btnCerrarSesion;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroLabel lblNombreActualizacion;
        private MetroFramework.Controls.MetroLabel lblLastUpdate;
    }
}