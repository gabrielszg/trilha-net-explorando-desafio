using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models.Exceptions
{
    public class GuestCapacityExceededException : Exception
    {
        public GuestCapacityExceededException() { }

        public GuestCapacityExceededException(string message) : base(message) { }

    }
}