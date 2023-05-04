using Centralizador2023.DTO;

namespace Centralizador2023.ComunicacionAsync
{
    public interface IBusDeMensajesCliente
    {
        void PublicarNuevoEstudiante(EstudiantePublisherDTO estudiantePublisherDTO);
    }
}
