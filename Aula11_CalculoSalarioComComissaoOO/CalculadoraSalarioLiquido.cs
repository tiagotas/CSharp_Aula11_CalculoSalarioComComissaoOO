using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aula11_CalculoSalarioComComissaoOO
{
    class CalculadoraSalarioLiquido
    {
        // Protegendo as propriedades com o modificador de acesso private.
        // propriedades ou métodos private somente são acessíveis (usáveis) dentro da classe em si.
        private double SalarioBruto;
        private int QntDependentes;


        private double PrimeiraFaixa, SegundaFaixa, TerceiraFaixa, QuartaFaixa;



        public double TotalINSS, TotalIRPF;

        NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;


        public CalculadoraSalarioLiquido(double _salarioBruto, int _qntDependentes)
        {
            SalarioBruto = _salarioBruto; // Definindo o valor da PROPRIEDADE SalarioBruto através do PARAMETRO _salarioBruto
            QntDependentes = _qntDependentes;

            CalcularINSS();
            CalcularIRPF();
        }

        // Definindo os métodos de calculo interno como private para serem usados somente dentro da classe.
        private void CalcularINSS()
        {
            if (SalarioBruto <= 1045.00)    // 3000 -NO
            {
                PrimeiraFaixa = SalarioBruto * 0.075;
            }


            if (SalarioBruto > 1045.00)
            {
                PrimeiraFaixa = 1045.00 * 0.075;

                // Se menor q 2089.60 é a segunda faixa
                if (SalarioBruto <= 2089.60)
                {
                    SegundaFaixa = (SalarioBruto - 1045.00) * 0.09;
                }

                // Se maior ou igual que 2086.61 calcular a segunda faixa sobre o valor devido
                if (SalarioBruto >= 2086.61)
                {
                    SegundaFaixa = (2086.60 - 1045) * 0.09;

                    // Se até 3134.40, calcular a terceira faixa do valor devido
                    if (SalarioBruto <= 3134.40)
                    {
                        TerceiraFaixa = (SalarioBruto - 2086.61) * 0.12;
                    }

                    if (SalarioBruto >= 3134.41)
                    {
                        TerceiraFaixa = (3134.40 - 2086.61) * 0.12;

                        // Se até 6101.06
                        if (SalarioBruto <= 6101.06)
                        {
                            QuartaFaixa = (SalarioBruto - 3134.41) * 0.14;
                        }

                        if (SalarioBruto >= 6101.07)
                        {
                            QuartaFaixa = (6101.06 - 3134.41) * 0.14;
                        }
                    }
                }
            }

            TotalINSS = PrimeiraFaixa + SegundaFaixa + TerceiraFaixa + QuartaFaixa;
        }


        private void CalcularIRPF()
        {
            double salario_descontado_inss = SalarioBruto - TotalINSS;


            double salario_descontado_depententes = salario_descontado_inss - (QntDependentes * 189.59);




            if (salario_descontado_depententes >= 1903.99 && salario_descontado_depententes <= 2826.65)
            {
                TotalIRPF = (salario_descontado_depententes * 0.075) - 142.8;
            }

            if (salario_descontado_depententes >= 2826.66 && salario_descontado_depententes <= 3751.05)
            {
                TotalIRPF = (salario_descontado_depententes * 0.15) - 354.8;
            }

            if (salario_descontado_depententes >= 3751.06 && salario_descontado_depententes <= 4664.68)
            {
                TotalIRPF = (salario_descontado_depententes * 0.225) - 636.13;
            }

            if (salario_descontado_depententes > 4664.68)
            {
                TotalIRPF = (salario_descontado_depententes * 0.275) - 869.36;
            }
        }




        public void MostrarCalculoINSS()
        {
            Console.WriteLine("Descontos por Faixa:");
            Console.WriteLine("Primeira 7.5%: {0}", PrimeiraFaixa.ToString("C", nfi));
            Console.WriteLine("Segunda    9%: {0}", SegundaFaixa.ToString("C", nfi));
            Console.WriteLine("Terceira  12%: {0}", TerceiraFaixa.ToString("C", nfi));
            Console.WriteLine("Quarta    14%: {0}", QuartaFaixa.ToString("C", nfi));
        }




        public void MostrarSalarioLiquido()
        {
            double total_descontos = TotalIRPF + TotalINSS;
            double salario_liquido = SalarioBruto - total_descontos;


            Console.WriteLine("");
            Console.WriteLine("Seu salário bruto (com comissão) é {0}", SalarioBruto.ToString("C", nfi));
            Console.WriteLine("Desconto do INSS: {0}", (TotalINSS * -1).ToString("C", nfi));
            Console.WriteLine("Desconto IRPF: {0}", (TotalIRPF * -1).ToString("C", nfi));
            Console.WriteLine("Total de Descontos: {0}", (total_descontos * -1).ToString("C", nfi));
            Console.WriteLine("Salário Liquido: {0}", salario_liquido.ToString("C", nfi));
        }

    }
}
