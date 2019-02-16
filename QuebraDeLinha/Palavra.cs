using System;
using System.Collections.Generic;
using System.Linq;

namespace QuebraDeLinha
{
    public static class Palavra
    {
        public static string Quebra(string texto, int colunas)
        {
            List<List<string>> frases = new List<List<string>>();

            List<string> palavras = new List<string>();

            palavras = texto.Split(' ').ToList();

            #region validacões

            if (ValidaTamanhoColunas(palavras, colunas))
            {
                throw new Exception("não vai dar");
            }

            #endregion

            HeadTail headTail = new HeadTail() { Head = palavras, Tail = palavras };

            while (headTail.Tail.Count() > 0)
            {
                int quantidadePalavras = QuantidadePalavras(headTail.Tail, colunas);
                headTail = QuebraFrase(headTail.Tail, quantidadePalavras);
                frases.Add(headTail.Head);
            }

            return FormatarFrases(frases);
        }


        private static string FormatarFrases(List<List<string>> frases)
        {
            return String.Join("\n", frases.Select(ConcatenarComEspaco));
        }

        private static string ConcatenarComEspaco(List<string> frase)
        {
            return String.Join(" ", frase);
        }

        private static HeadTail QuebraFrase(List<string> frase, int quantidadePalavras)
        {
            return new HeadTail()
            {
                Head = frase.Take(quantidadePalavras).ToList(),
                Tail = frase.Skip(quantidadePalavras).ToList()
            };
        }

        private static bool ValidaTamanhoColunas(List<string> palavras, int colunas)
        {
            return palavras.Where((palavra) => palavra.Length > colunas).Count() > 0;
        }

        private static int AdicionarEspaco(int numeroPalavras)
        {
            return numeroPalavras > 1 ? 1 : 0;
        }

        private static int QuantidadePalavras(List<string> palavras, int limiteLetras)
        {
            int numeroPalavras = 0, totalLetras = 0;

            foreach (string palavra in palavras)
            {
                numeroPalavras += 1;
                totalLetras += palavra.Length + AdicionarEspaco(numeroPalavras);

                if (totalLetras == limiteLetras)
                {
                    return numeroPalavras;
                }

                if (totalLetras > limiteLetras)
                {
                    return numeroPalavras - 1;
                }
            }
            return numeroPalavras;
        }
    }
}
