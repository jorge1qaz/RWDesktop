using BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RWeb
{
    public partial class frmEleccionEmpresa : MetroFramework.Forms.MetroForm
    {
        public frmEleccionEmpresa()
        {
            InitializeComponent();
        }
        string idCompany = "";
        string ruc = "";
        Consultas cons = new Consultas();
        Paths paths = new Paths();
        private void frmEleccionEmpresa_Load(object sender, EventArgs e)
        {
            DataTable dataCompany = new DataTable();
            dataCompany = cons.GetCompanies();
            DataColumn column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Seleccione";
            dataCompany.Columns.Add(column);
            grdEmpresas.DataSource = dataCompany;
            grdEmpresas.Columns[2].MinimumWidth = 300;
            grdEmpresas.Columns[0].ReadOnly = true;
            grdEmpresas.Columns[1].ReadOnly = true;
            grdEmpresas.Columns[2].ReadOnly = true;
        }
        private void grdEmpresas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblDescripcion.Text = "Usted a selecionado la empresa de código: " + grdEmpresas.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("  ", "") +
                                    " \r Razón social: " + grdEmpresas.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("  ", "") + "  y de RUC: " +
                                    grdEmpresas.Rows[e.RowIndex].Cells[1].Value.ToString().Replace("  ", "");
                idCompany = grdEmpresas.Rows[e.RowIndex].Cells[0].Value.ToString().Replace(" ", "");
                ruc = grdEmpresas.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(" ", "");
                metroToolTip1.SetToolTip(lblDescripcion, lblDescripcion.Text.ToString().Replace("  ", ""));
            }
            catch (Exception)
            {
                lblDescripcion.Text =  "Hemos encontrado las siguientes empresa(s), por favor seleccione sólo una empresa" + "\n" +"para ver sus reportes en la web.";
            }
        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
            try
            {
                if (idCompany == "")
                    MessageBox.Show("Debe selecionar una empresa ", "Error al registro de empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    using (StreamWriter LastUpdate = new StreamWriter(paths.PathPrincipalDirectory + "idCompany.txt", false))
                        LastUpdate.WriteLine(idCompany.ToString().Trim());
                    if (ruc == "")
                        MessageBox.Show("Esta empresa no tiene RUC.", "Error al registro de empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        using (StreamWriter ructxt = new StreamWriter(paths.PathPrincipalDirectory + "ruc.txt", false))
                            ructxt.WriteLine(ruc.ToString().Trim());
                        Application.Restart();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error al guardar la elección de su empresa, error de tipo: "  + error, "Error al registro de empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
        }
    }
}
