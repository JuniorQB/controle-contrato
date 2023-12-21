using ControleContrato.Entities;
using ControleContrato.Entities.Enums;

namespace ControleContrato
{
   class Program
    {
        public static void Main(string[] args)
        {
            
            Console.Write("Digite o nome do departamento: ");
            
            string nameDpto = Console.ReadLine();
            Console.Write("Digite o nome do profissional: ");
            string name = Console.ReadLine();
            Console.Write("Digite o nível[Junior/MidLevel/Senior]: ");
            WorkLevel level = Enum.Parse<WorkLevel>(Console.ReadLine());
            Console.Write("Quantidade de contratos: ");
            int qtdeContracts = int.Parse(Console.ReadLine());
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine());
            Departament departament = new Departament(nameDpto);
            Worker worker = new Worker(name, level, baseSalary, departament);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Dados dos contratos");

            for (int i = 0; i < qtdeContracts; i++)
            {
                Console.Write("Digite a data: ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Digite o valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Digite a duração: ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(dateTime, valuePerHour, duration);
                worker.AddContract(contract);
            }


            Console.Write("Enter month and year to calculate income (MM/YYYY)");
            string[] dateYear = Console.ReadLine().Split('/');
            Console.WriteLine("Name: "+worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for " +
                dateYear[0] + "/" +
                dateYear[1] + ": " +
                worker.Income(int.Parse(dateYear[1]), int.Parse(dateYear[0])));

        }
    }
}