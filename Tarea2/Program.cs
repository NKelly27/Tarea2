using System;

namespace Tarea2
{
    internal class Program
    {
        static void Main(string[] args)
        {
  
            int cantOperarios = 0, cantTecnicos = 0, cantProfesionales = 0;
            double acumOperarios = 0, acumTecnicos = 0, acumProfesionales = 0;

            string continuar;

            do
            {

                Console.WriteLine("Ingrese la cédula del colaborador:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del colaborador:");
                string nombre = Console.ReadLine();

                int categoria;
                do
                {
                    Console.WriteLine("Ingrese la categoría del colaborador (1-Operario, 2-Técnico, 3-Profesional):");
                } while (!int.TryParse(Console.ReadLine(), out categoria) || categoria < 1 || categoria > 3);

                int salarioHora;
                Console.WriteLine("Ingrese el salario por hora:");
                int.TryParse(Console.ReadLine(), out salarioHora);

                int horas;
                Console.WriteLine("Ingrese la cantidad de horas trabajadas:");
                int.TryParse(Console.ReadLine(), out horas);

                int salarioOrdinario = salarioHora * horas;
                double aumento = 0;

                if (categoria == 1)
                {
                    aumento = salarioOrdinario * 0.15;
                }
                else if (categoria == 2)
                {
                    aumento = salarioOrdinario * 0.10;
                }
                else if (categoria == 3)
                {
                    aumento = salarioOrdinario * 0.05;
                }

                double salarioBruto = salarioOrdinario + aumento;
                double deduccion = salarioBruto * 0.0917;
                double salarioNeto = salarioBruto - deduccion;

                Console.WriteLine("\n--- Detalle del Colaborador ---");
                Console.WriteLine("Cédula: " + cedula);
                Console.WriteLine("Nombre: " + nombre);

                if (categoria == 1)
                {
                    Console.WriteLine("Tipo de empleado: Operario");
                }
                else if (categoria == 2)
                {
                    Console.WriteLine("Tipo de empleado: Técnico");
                }
                else if (categoria == 3)
                {
                    Console.WriteLine("Tipo de empleado: Profesional");
                }

                Console.WriteLine("Salario por hora: ₡" + salarioHora);
                Console.WriteLine("Cantidad de horas: " + horas);
                Console.WriteLine("Salario ordinario: ₡" + salarioOrdinario);
                Console.WriteLine("Aumento: ₡" + aumento);
                Console.WriteLine("Salario bruto: ₡" + salarioBruto);
                Console.WriteLine("Deducción CCSS (9.17%): ₡" + deduccion);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Salario neto: ₡" + salarioNeto);
                Console.ResetColor();

                if (categoria == 1)
                {
                    cantOperarios++;
                    acumOperarios += salarioNeto;
                }
                else if (categoria == 2)
                {
                    cantTecnicos++;
                    acumTecnicos += salarioNeto;
                }
                else if (categoria == 3)
                {
                    cantProfesionales++;
                    acumProfesionales += salarioNeto;
                }

                Console.WriteLine("\n¿Desea ingresar otro colaborador? (s/n):");
                continuar = Console.ReadLine().ToLower();

            } while (continuar == "s");

            Console.WriteLine("\n===== ESTADÍSTICAS =====");
            Console.WriteLine("Cantidad empleados tipo Operario: " + cantOperarios);
            Console.WriteLine("Acumulado salario neto Operarios: ₡" + acumOperarios);
            Console.WriteLine("Promedio salario neto Operarios: ₡" + (cantOperarios > 0 ? (acumOperarios / cantOperarios) : 0));

            Console.WriteLine("Cantidad empleados tipo Técnico: " + cantTecnicos);
            Console.WriteLine("Acumulado salario neto Técnicos: ₡" + acumTecnicos);
            Console.WriteLine("Promedio salario neto Técnicos: ₡" + (cantTecnicos > 0 ? (acumTecnicos / cantTecnicos) : 0));

            Console.WriteLine("Cantidad empleados tipo Profesional: " + cantProfesionales);
            Console.WriteLine("Acumulado salario neto Profesionales: ₡" + acumProfesionales);
            Console.WriteLine("Promedio salario neto Profesionales: ₡" + (cantProfesionales > 0 ? (acumProfesionales / cantProfesionales) : 0));
        }
    }
}