using System.Text;

namespace SCRO_Web_API.Models.Extensions;

public static class GerarSenha
{
    public static string Sequencia()
    {
        Random random = new Random();
        StringBuilder sequencia = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            char letra = (char)('A' + random.Next(26));
            sequencia.Append(letra);
        }
        sequencia.Append('-');

        for (int i = 0; i < 4; i++)
        {
            int numero = (1 + random.Next(10));
            sequencia.Append(numero);
        }
 
        return sequencia.ToString();
    }

}
