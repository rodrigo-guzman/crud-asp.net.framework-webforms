using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Interactor;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.InputOutput;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Models;

namespace CRUD_Empleados_RodrigoGuzman.Pages
{
    public partial class Crud : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpcion = "";

        private readonly IEmpleadosUseCase EmpleadosUseCase;

        public Crud()
        {
            EmpleadosUseCase = new EmpleadosUseCase();
        }

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
                            this.BtnCreate.Visible = true;
                            break;
                        case "U":
                            this.BtnEdit.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            var input = new GetEmpleadoInput()
            {
                Id = int.Parse(sID)
            };
            var empleadoResult = EmpleadosUseCase.GetEmpleado(input).Result;
            EmpleadoModel empleado = new EmpleadoModel()
            {
                Id = empleadoResult.Id,
                Nombre = empleadoResult.Nombre,
                Apellido = empleadoResult.Apellido,
                Email = empleadoResult.Email,
                Salario = empleadoResult.Salario
            };

            tbNombre.Text = empleado.Nombre.ToString();
            tbApellido.Text = empleado.Apellido.ToString();
            tbEmail.Text = empleado.Email.ToString();
            tbSalario.Text = empleado.Salario.ToString();
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