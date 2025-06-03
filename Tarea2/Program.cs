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
                string cedula = SolicitarTexto("Ingrese la cédula del colaborador:");
                string nombre = SolicitarTexto("Ingrese el nombre del colaborador:");
                int categoria = SolicitarCategoria();
                int salarioHora = SolicitarEntero("Ingrese el salario por hora:");
                int horas = SolicitarEntero("Ingrese la cantidad de horas trabajadas:");

                double salarioNeto = ProcesarColaborador(cedula, nombre, categoria, salarioHora, horas);

                // Acumuladores y contadores por categoría
                switch (categoria)
                {
                    case 1:
                        cantOperarios++;
                        acumOperarios += salarioNeto;
                        break;
                    case 2:
                        cantTecnicos++;
                        acumTecnicos += salarioNeto;
                        break;
                    case 3:
                        cantProfesionales++;
                        acumProfesionales += salarioNeto;
                        break;
                }

                continuar = SolicitarTexto("\n¿Desea ingresar otro colaborador? (s/n):").ToLower();

            } while (continuar == "s");

            MostrarEstadisticas("Operario", cantOperarios, acumOperarios);
            MostrarEstadisticas("Técnico", cantTecnicos, acumTecnicos);
            MostrarEstadisticas("Profesional", cantProfesionales, acumProfesionales);
        }

        static string SolicitarTexto(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        static int SolicitarEntero(string mensaje)
        {
            int valor;
            Console.WriteLine(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Intente de nuevo:");
            }
            return valor;
        }

        static int SolicitarCategoria()
        {
            int categoria;
            do
            {
                Console.WriteLine("Ingrese la categoría del colaborador (1-Operario, 2-Técnico, 3-Profesional):");
            } while (!int.TryParse(Console.ReadLine(), out categoria) || categoria < 1 || categoria > 3);
            return categoria;
        }

        static double ProcesarColaborador(string cedula, string nombre, int categoria, int salarioHora, int horas)
        {
            int salarioOrdinario = salarioHora * horas;
            double aumento = CalcularAumento(categoria, salarioOrdinario);
            double salarioBruto = salarioOrdinario + aumento;
            double deduccion = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccion;

            MostrarDetalle(cedula, nombre, categoria, salarioHora, horas, salarioOrdinario, aumento, salarioBruto, deduccion, salarioNeto);

            return salarioNeto;
        }

        static double CalcularAumento(int categoria, int salarioOrdinario)
        {
            switch (categoria)
            {
                case 1: return salarioOrdinario * 0.15;
                case 2: return salarioOrdinario * 0.10;
                case 3: return salarioOrdinario * 0.05;
                default: return 0;
            }
        }

        static void MostrarDetalle(string cedula, string nombre, int categoria, int salarioHora, int horas, int salarioOrdinario, double aumento, double salarioBruto, double deduccion, double salarioNeto)
        {
            Console.WriteLine("\n--- Detalle del Colaborador ---");
            Console.WriteLine("Cédula: " + cedula);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Tipo de empleado: " + CategoriaTexto(categoria));
            Console.WriteLine("Salario por hora: ₡" + salarioHora);
            Console.WriteLine("Cantidad de horas: " + horas);
            Console.WriteLine("Salario ordinario: ₡" + salarioOrdinario);
            Console.WriteLine("Aumento: ₡" + aumento);
            Console.WriteLine("Salario bruto: ₡" + salarioBruto);
            Console.WriteLine("Deducción CCSS (9.17%): ₡" + deduccion);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Salario neto: ₡" + salarioNeto);
            Console.ResetColor();
        }

        static string CategoriaTexto(int categoria)
        {
            return categoria == 1 ? "Operario" : categoria == 2 ? "Técnico" : "Profesional";
        }

        static void MostrarEstadisticas(string tipo, int cantidad, double acumulado)
        {
            Console.WriteLine($"\nCantidad empleados tipo {tipo}: {cantidad}");
            Console.WriteLine($"Acumulado salario neto {tipo}s: ₡{acumulado}");
            Console.WriteLine($"Promedio salario neto {tipo}s: ₡{(cantidad > 0 ? acumulado / cantidad : 0)}");
        }
    }
}
