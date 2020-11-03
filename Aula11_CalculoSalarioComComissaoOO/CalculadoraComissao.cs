using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aula11_CalculoSalarioComComissaoOO
{
    public class CalculadoraComissao
    {
        private double ValorVendidoMussarela, ValorVendidoMortadela, ValorVendidoPresunto, ValorVendidoPeitoPeru;
        
        private double ComissaoMussarela, ComissaoMortadela, ComissaoPresunto, ComissaoPeitoPeru;

        public double TotalComissao = 0;


        NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;


        public void CalcularComissaoMussarela()
        {
            // Para calcular a comissão, necessário:
            // Qnt Vendida, Preço por Kilo e  % da comissão

            Console.WriteLine("Qual a quantidade de mussarela vendida em kilos:");
            double qnt_vendida_mussarela = Convert.ToDouble(Console.ReadLine());


            ValorVendidoMussarela = qnt_vendida_mussarela * 22.6; // R$
            ComissaoMussarela = ValorVendidoMussarela * 0.05; // R$

            TotalComissao += ComissaoMussarela;
        }

        public void CalcularComissaoMortadela()
        {
            Console.WriteLine("Qual a quantidade de mortadela vendida em kilos:");
            double qnt_vendida_mortadela = Convert.ToDouble(Console.ReadLine());

            ValorVendidoMortadela = qnt_vendida_mortadela * 8.98;

            ComissaoMortadela = ValorVendidoMortadela * 0.065;

            TotalComissao += ComissaoMortadela;
        }

        public void CalcularComissaoPresunto()
        {
            Console.WriteLine("Qual a quantidade de presunto vendida em kilos:");
            double qnt_vendida_presunto = Convert.ToDouble(Console.ReadLine());

            ValorVendidoPresunto = qnt_vendida_presunto * 31.03;

            ComissaoPresunto = ValorVendidoPresunto * 0.045;

            TotalComissao += ComissaoPresunto;
        }

        public void CalcularComissaoPeitoPeru()
        {
            Console.WriteLine("Qual a quantidade de peito de peru vendida em kilos:");
            double qnt_vendida_peito_peru = Convert.ToDouble(Console.ReadLine());
            
            ValorVendidoPeitoPeru = qnt_vendida_peito_peru * 58.90;

            ComissaoPeitoPeru = ValorVendidoPeitoPeru * 0.025;

            TotalComissao += ComissaoPeitoPeru;
        }


        public void MostrarComissao()
        {
            Console.WriteLine("Você vendeu {0} de MUSSARELA e comissão de {1}", ValorVendidoMussarela.ToString("C", nfi), ComissaoMussarela.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de MORTADELA e comissão de {1}", ValorVendidoMortadela.ToString("C", nfi), ComissaoMortadela.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de PRESUNTO e comissão de {1}", ValorVendidoPresunto.ToString("C", nfi), ComissaoPresunto.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de PEITO DE PERU e comissão de {1}", ValorVendidoPeitoPeru.ToString("C", nfi), ComissaoPeitoPeru.ToString("C", nfi));

            //TotalComissao = ComissaoMussarela + ComissaoMortadela + ComissaoPresunto + ComissaoPeitoPeru;

            Console.WriteLine("Você tem {0} de comissão.", TotalComissao.ToString("C", nfi));
        }
    }
}
