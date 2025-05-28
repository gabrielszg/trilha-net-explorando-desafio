using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException() { }

        public EmptyListException(string message) : base(message) { }
    }
}