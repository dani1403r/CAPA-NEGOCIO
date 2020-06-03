using CAPA_NEGOCIO.application.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.application.business
{
    public class MantenedorClienteBusiness
    {
        private ClienteDAO clienteDAO;

        public MantenedorClienteBusiness()
        {
            clienteDAO = new ClienteDAO();
        }

        public void Guardar(ClienteModel cliente)
        {
            validar(cliente);
            clienteDAO.Insertar(cliente);
        }

        public void validar(ClienteModel cliente)
        {
            EmptyRole emptyRole = new EmptyRole();

            string errorMessage = "";
            errorMessage = errorMessage + ValidarNombre(cliente.Nombre);
            errorMessage = errorMessage + ValidarDescripcion(cliente.Descripcion);

            if (errorMessage == null errorMessage.Count() > 0) {
                throw new Exception(errorMessage);
            }
        }

        public List<ClienteModel> Listar()
        {

            return clienteDAO.BuscarTodo();
        }

        public string ValidarNombre(string nombre)
        {
            
            return ValidarTexbox(nombre, "Nombre", 1, 80);


        }

        public string ValidarDescripcion(string descripcion)
        {

            return ValidarTexbox(descripcion, "Descripcion", 1, 250);


        }

        public string ValidarTexbox(string value, string name, int min, int max)
        {
            EmptyRole emptyRole = new EmptyRole();
            string errorMessage = "";
            errorMessage = errorMessage + emptyRole.EmptyMessage(value, name);

            if (errorMessage == null errorMessage.Count() == 0){

                ValidadorCliente validadorCliente = new ValidadorCliente();
                errorMessage = ValidadorCliente.validadorClienteMessage(value, name, min, max);

            }

            return errorMessage;
        }
    }
}
