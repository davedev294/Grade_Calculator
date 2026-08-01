using AppCalculoMedia.EntradaDatos;
using AppCalculoMedia.Models;

List<Asignatura> asignaturas = new();

while (true)
{
    Console.WriteLine("========================");
    Console.WriteLine("CALCULADORA DE NOTAS");
    Console.WriteLine("========================");
    Console.WriteLine();
    Console.WriteLine("1. Añadir asignatura");
    Console.WriteLine("2. Ver asignaturas");
    Console.WriteLine("3. Ver nota de una asignatura");
    Console.WriteLine("4. Ver media general");
    Console.WriteLine("5. Salir");
    Console.WriteLine();
    Console.WriteLine("Opción:");
    

    if (!int.TryParse(Console.ReadLine(), out int opcion))
    {
        Console.WriteLine("Debes introducir un número");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    switch (opcion)
    {
        case 1:
            {
                Asignatura asignatura = EntradaDatos.CrearAsignatura();
                asignaturas.Add(asignatura);

                Console.WriteLine("Asignatura añadida Correctamente");
                Console.ReadKey();
                break;
            }

        case 2:
            {
                foreach (Asignatura asignatura in asignaturas)
                {
                    Console.WriteLine(asignatura.Nombre);
                }
                Console.ReadKey();
                break;
            }
        case 3:
            {
                bool encontrada = false;

                Console.WriteLine("Aquí tienes una lista con todos los nombres de las asignaturas: ");
                foreach (Asignatura asignatura in asignaturas)
                {
                    Console.WriteLine(asignatura.Nombre);
                }

                Console.WriteLine("\n\nEscriba el nombre de la asignatura deseada:");
                string nombreAsignatura = Console.ReadLine()!;

                foreach (Asignatura asignatura in asignaturas)
                {
                    if (nombreAsignatura == asignatura.Nombre)
                    {
                        encontrada = true;
                        Console.WriteLine($"Nota de la asignatura: {asignatura.CalcularNotaFinal()}");

                        foreach (Criterio criterio in asignatura.Criterios)
                        {
                            Console.WriteLine($"{criterio.Nombre}: {criterio.CalcularNota():F2}");
                            
                            foreach (ElementoEvaluable actividad in criterio.Actividades)
                                {
                                    Console.WriteLine($"  - {actividad.Nombre}");
                                    Console.WriteLine($"    Tipo: {actividad.Tipo}");
                                    Console.WriteLine($"    Peso: {actividad.Peso}%");
                                    Console.WriteLine($"    Nota: {actividad.Nota}");
                                }
                        }

                        break;
                    }
                }

                if (!encontrada)
                {
                    Console.WriteLine("No hemos encontrado ninguna asignatura con ese nombre");   
                }
                Console.ReadKey();
                break;
            }
        case 4:
            {
                Console.WriteLine($"Media: {EntradaDatos.CalcularMedia(asignaturas):F2}");
                Console.ReadKey();
                break;
            }
        case 5:
            {
                return;
            }
        default:
            {
                Console.WriteLine("Elija una opción correcta");
                Console.ReadKey();
                break;
            }

    }
}