using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUD_Empleados_RodrigoGuzman.Pages
{
    public partial class Crud : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpcion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpcion = Request.QueryString["op"].ToString();
                    switch (sOpcion)
                    {
                        case "C":
                            //this.lblTitulo.Text = "Ingresar Nuevo Empleado";
                            this.BtnCreate.Visible = true;
                            break;
                        case "U":
                            //this.lblTitulo.Text = "Editar Empleado";
                            this.BtnEdit.Visible = true;
                            break;
                        case "D":
                            //this.lblTitulo.Text = "Eliminar Empleado";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmpleado", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbApellido.Text = row[2].ToString();
            tbEmail.Text = row[3].ToString();
            tbSalario.Text = row[4].ToString();
            con.Close();
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = tbApellido.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Salario", SqlDbType.Money).Value = decimal.Parse(tbSalario.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_CrearEmpleado", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = tbApellido.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Salario", SqlDbType.Money).Value = decimal.Parse(tbSalario.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Pages/Index.aspx");
        }
    }
}