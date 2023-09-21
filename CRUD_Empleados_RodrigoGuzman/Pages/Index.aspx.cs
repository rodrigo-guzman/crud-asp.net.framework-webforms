using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Empleados_RodrigoGuzman.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_CargarEmpleados", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvempleados.DataSource = dt;
            gvempleados.DataBind();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string url = "~/Pages/CRUD.aspx?op=C";

            string script = "<script>window.open('" + ResolveUrl(url) + "', '', 'width=500,height=550');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", script);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;

            string url = "~/Pages/CRUD.aspx?id=" + id + "&op=U";

            string script = "<script>window.open('" + ResolveUrl(url) + "', '', 'width=500,height=550');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", script);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            string url = "~/Pages/CRUD.aspx?id=" + id + "&op=D";

            string script = "<script>window.open('" + ResolveUrl(url) + "', '', 'width=500,height=550');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", script);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LlenarGrillaEmpleados();
        }

        public void LlenarGrillaEmpleados(string query = "")
        {

            SqlCommand cmd = new SqlCommand("sp_GetEmpleados", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            string texto = (query != "") ? query : txtSearch.Text;
            da.SelectCommand.Parameters.Add("@Search", SqlDbType.VarChar).Value = texto;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvempleados.DataSource = dt;
            gvempleados.DataBind();
            con.Close();
        }

        [WebMethod]
        public static string Buscar(string query)
        {
            try
            {
                Index index = new Index();
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_GetEmpleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                string texto = (query != "") ? query : index.txtSearch.Text;
                da.SelectCommand.Parameters.Add("@Search", SqlDbType.VarChar).Value = texto;
                DataTable dt = new DataTable();
                da.Fill(dt);
                //index.gvempleados.DataSource = dt;
                //index.gvempleados.DataBind();
                conexion.Close();
                return DataTableToString(dt);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }

        static string DataTableToString(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();

            // Agregar encabezados de columnas
            foreach (DataColumn column in dataTable.Columns)
            {
                sb.Append(column.ColumnName);
                sb.Append("\t"); // Puedes usar un separador diferente si lo deseas
            }
            sb.AppendLine();

            // Agregar datos de las filas
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    sb.Append(item.ToString());
                    sb.Append("\t"); // Puedes usar un separador diferente si lo deseas
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}