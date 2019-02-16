using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuebraDeLinha
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string resultado = Palavra.Quebra(
                    texto: "Um pequeno jabuti xereta viu dez cegonhas felizes.",
                    colunas: 20);

                Console.WriteLine(resultado);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
