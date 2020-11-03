using System;

namespace Aula11_CalculoSalarioComComissaoOO
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  Obtendo as informações básicas.
             */ 
            Console.WriteLine("Informe o nome do Vendedor: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe a quantidade de Dependentes: ");
            int qnt_dep = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o salário Base: ");
            double salario_base = Convert.ToDouble(Console.ReadLine());


            /**
             * Calculando a comissão.
             */ 
            CalculadoraComissao cc = new CalculadoraComissao();         
            cc.CalcularComissaoMussarela();
            cc.CalcularComissaoMortadela();
            cc.CalcularComissaoPresunto();
            cc.CalcularComissaoPeitoPeru();

            //cc.MostrarComissao();

            /**
             * Calculando salário liquido.
             */
            double salario_bruto = salario_base + cc.TotalComissao;
            
            CalculadoraSalarioLiquido sl = new CalculadoraSalarioLiquido(salario_bruto, qnt_dep);

            

            sl.MostrarSalarioLiquido();


            /**
             * Caso o usuário queira detalhamentos
             */
            string detalhar_inss = "N";
            string detalhar_comissao = "N";

            Console.WriteLine("");
            Console.WriteLine("Detalhar Descontos do INSS? S/N");
            detalhar_inss = Console.ReadLine();

            if (detalhar_inss.Equals("S"))
                sl.MostrarCalculoINSS();



            Console.WriteLine("");
            Console.WriteLine("Detalhar Ganhos de Comissão? S/N");
            detalhar_comissao = Console.ReadLine();

            if (detalhar_comissao.Equals("S"))
                cc.MostrarComissao();












            Console.ReadKey();
                
        }
    }
}
