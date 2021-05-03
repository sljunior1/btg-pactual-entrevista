using System;
using System.Collections.Generic;
using System.Linq;

namespace BTG_IT_PME_CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Cabecalho();

            Console.WriteLine("Dados de Entrada: ");
            string dadosEntrada = Console.ReadLine();

            IList<IList<int>> lista = ValidaDadosDeEntrada(dadosEntrada);

            Console.WriteLine();
            Console.WriteLine();

            if (lista != null && lista.Count() > 0)
                Console.WriteLine(String.Concat("Número de tijolos cortados: ", CortarMenosTijolos(lista)));

            else
                Error("Os dados de entrada não estão no formato esperado.");

            ExecutarNovamente();

            Console.ReadKey();
        }
        private static void Cabecalho()
        {
            Console.WriteLine();
            Console.WriteLine("**********************************************************************************************************");
            Console.WriteLine("BTG PACTUAL (IT-PME)");
            Console.WriteLine();
            Console.WriteLine("Desenvolvedor: Silas Lima da Silva Júnior");
            Console.WriteLine("Atividade: Cortar o menor número de tijolos possível e retornar o número de tijolos cortados.");
            Console.WriteLine();
        }
        private static IList<IList<int>> ValidaDadosDeEntrada(string dadosEntrada)
        {
            IList<IList<int>> lista = new List<IList<int>>();
            List<int> itens = new List<int>();

            if (dadosEntrada.StartsWith("[") && dadosEntrada.EndsWith("]"))
            {
                dadosEntrada = dadosEntrada.Substring(0, dadosEntrada.Length - 1);
                dadosEntrada = dadosEntrada.Substring(1);

                var resultado = dadosEntrada.Split('[', ']');

                foreach (var item in resultado)
                {
                    if (item.Where(c => char.IsNumber(c)).Count() > 0)
                    {
                        var itemEntrada = item.Split(",");

                        for (int i = 0; i < itemEntrada.Length; i++)
                        {
                            itens.Add(Convert.ToInt32(itemEntrada[i]));
                        }

                        lista.Add(itens);
                        itens = new List<int>();
                    }
                }
            }

            return lista;
        }
        private static int CortarMenosTijolos(IList<IList<int>> parede)
        {
            var dicParede = new Dictionary<int, int>();

            for (int i = 0; i < parede.Count; i++)
            {
                int soma = 0;
                for (int j = 0; j < parede[i].Count - 1; j++)
                {
                    soma += parede[i][j];

                    if (!dicParede.ContainsKey(soma))
                        dicParede[soma] = 0;

                    dicParede[soma]++;
                }
            }

            int maxPos = int.MinValue;
            foreach (var dicItem in dicParede)
            {
                maxPos = Math.Max(dicItem.Value, maxPos);
            }

            return maxPos == int.MinValue ? parede.Count : parede.Count - maxPos;
        }
        private static void ExecutarNovamente()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********************************************************************************************************");
            Console.WriteLine("DESEJA EXECUTAR NOVAMENTE? Digite S para SIM e N para NÃO");
            Console.WriteLine("Digite a opção: ");

            var executar = Console.ReadLine();

            if (executar.ToUpper().Equals("S"))
            {
                Console.Clear();
                string[] args = new string[1];

                Main(args);
            }
            else
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("OBRIGADO, BTG PACTUAL, PELA OPORTUNIDADE!");
            }
        }
        private static void Error(string mensagem)
        {
            Console.WriteLine();
            Console.Error.WriteLine(String.Concat("ERROR: ", mensagem));
        }
    }
}
