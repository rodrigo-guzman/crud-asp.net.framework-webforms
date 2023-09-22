
namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.InputOutput
{
    using Newtonsoft.Json;
    public class GetEmpleadoInput
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("Apellido")]
        public string Apellido { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("salario")]
        public decimal Salario { get; set; }
        [JsonProperty("search")]
        public string Search { get; set; }
    }
}