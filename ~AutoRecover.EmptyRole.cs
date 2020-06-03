using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.application.Reglas
{
    public class EmptyRole
    {
        public string EmptyMenssage(string value, string name)
        {

            try
            {
                IsEmpty(value, name);

                return "";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void IsEmpty(string value, string name)
        {

            if (value == null || value.Count == 0)
            {
                throw new Exception(
                    "El campo" + name + "No debe estar vacio");
            }

        }

        internal string EmptyMessage(string nombre, string v)
        {
            throw new NotImplementedException();
        }
    }
}
