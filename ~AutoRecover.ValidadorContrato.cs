using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.application.Reglas
{
    public class ValidadorContrato
    {
        public string ValidadorContratoMessage(string value, string name, int min, int max)
        {

            try
            {
                ValidadorContrato(value, name, min, max);

                return "";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public void ValidadorContrato(string value, string name, int min, int max)
        {

            if (value == null || value.Count() < min || value.Count() > max)
            {
                throw new Exception(
                    "El campo" + name + "Debe poseer" + min + "y maximo" + max + "caracteres");
            }
        }

        internal static string validadorContratoMessage(string nombre, string v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
}
