using Api.DawaFinder.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.services
{
      public interface IOfficeService
    {
       List<Office> getAll();
        Office insertoff(Office off);


    }
}
