using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDIO_DotNET_AppSeries.Interfaces
{
    interface iRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}
