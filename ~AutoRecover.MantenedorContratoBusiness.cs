using CAPA_NEGOCIO.application.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.application.business
{
    public class MantenedorContratoBusiness
    {
        private ContratoDAO contratoDAO;

        public MantenedorContratoBusiness()
        {
            contratoDAO = new ContratoDAO();
        }

        public void Guardar(ContratoModel contrato)
        {
            validar(contrato);
            contratoDAO.Insertar(contrato);
        }

        public void validar(ContratoModel contrato)
        {
            EmptyRole emptyRole = new EmptyRole();
            string errorMessage = "";
            errorMessage = errorMessage + ValidarNombre(contrato.Nombre);
            errorMessage = errorMessage + ValidarDescripcion(contrato.Descripcion);

            if (errorMessage == null errorMessage.Count() > 0) {
                throw new Exception(errorMessage);
            }
        }

        public List<ContratoModel> Listar()
        {

            return contratoDAO.BuscarTodo();
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

                ValidadorContrato validadorContrato = new ValidadorContrato();
                errorMessage = ValidadorContrato.validadorContratoMessage(value, name, min, max);

            }

            return errorMessage;
        }
    }
}