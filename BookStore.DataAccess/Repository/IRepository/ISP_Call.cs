using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Repository.IRepository
{
    public  interface ISP_Call : IDisposable
    {
        T single<T>(string procedueName, DynamicParameters param = null);
        void Execute(string procedureNmae, DynamicParameters param = null);
        T OneRecord<T>(string procedureNmae, DynamicParameters param = null);

        IEnumerable<T> List<T>(string procedureNmae, DynamicParameters param = null);
        Tuple<IEnumerable<T1>,IEnumerable<T2>> List<T1,T2>(string procedureNmae, DynamicParameters param = null);
    }
}
