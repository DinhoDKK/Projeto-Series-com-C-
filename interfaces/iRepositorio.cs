using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface iRepositorio<T>
    {
        
        List<T> Lista();

        T RetornaPorId (int Id);

        void Insere(T entidade);

        void Exclui(int Id);

        void Atualiza(int Id, T entidade);

        int ProximoId();
    }
}