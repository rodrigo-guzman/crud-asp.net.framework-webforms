using CRUD_Empleados_RodrigoGuzman.Features.Empeados;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.InputOutput;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Interactor;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace CRUD_Empleados_RodrigoGuzman.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        private readonly IEmpleadosUseCase EmpleadosUseCase;

        public Index()
        {
            EmpleadosUseCase = new EmpleadosUseCase();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            LlenarGrillaEmpleados();
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
            SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LlenarGrillaEmpleados(txtSearch.Text);
        }

        public void LlenarGrillaEmpleados(string query = "")
        {
            var input = new GetEmpleadoInput()
            {
                Search = query
            };
            var empleadosResult = EmpleadosUseCase.GetEmpleados(input).Result;
            List<EmpleadoModel> empleados = empleadosResult
                .Select(e => new EmpleadoModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Email = e.Email,
                    Salario = e.Salario
                })
                .ToList();

            gvempleados.DataSource = empleados;
            gvempleados.DataBind();
        }
    }
}