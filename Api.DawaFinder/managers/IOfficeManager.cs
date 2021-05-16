using Api.DawaFinder.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.managers
{
    public interface IOfficeManager
    {
        List<Office> SelectManger();
        int inserttoManager(Office offe);
    }
}
