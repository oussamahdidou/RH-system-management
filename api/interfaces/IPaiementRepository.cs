using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.interfaces
{
    public interface IPaiementRepository
    {
        Task CreatePaiements();
    }
}