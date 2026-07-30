using AppCalculoMedia.Models;

namespace AppCalculoMedia.EntradaDatos;

public static class EntradaDatos
{
    public static Asignatura CrearAsignatura()
    {
        Asignatura asignatura = new Asignatura();

        Console.WriteLine("Nombre de la asignatura: ");
        asignatura.Nombre = Console.ReadLine()!;

        Console.WriteLine("¿Cuántos criterios (RAs) tiene?");
        int cantidadRA = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < cantidadRA; i++)
        {
            Criterio criterio = new Criterio();

            Console.WriteLine($"Nombre del RA {i + 1}: ");
            criterio.Nombre = Console.ReadLine()!;

            Console.WriteLine("Peso del RA: ");
            criterio.Peso = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Cantidad de Elementos Evaluables: ");
            int cantidadActividades = int.Parse(Console.ReadLine()!);

            for (int j = 0; j < cantidadActividades; j++)
            {
                ElementoEvaluable elementoEvaluable = new ElementoEvaluable();

                Console.WriteLine($"Nombre de la actividad {j + 1}: ");
                elementoEvaluable.Nombre = Console.ReadLine()!;

                Console.WriteLine("Peso de la actividad: ");
                elementoEvaluable.Peso = double.Parse(Console.ReadLine()!);

                Console.WriteLine("Nota de la actividad: ");
                elementoEvaluable.Nota = double.Parse(Console.ReadLine()!);

                Console.WriteLine("Tipo de Actividad: ");
                Console.WriteLine("0 - Examen");
                Console.WriteLine("1 - Tarea");
                Console.WriteLine("2 - Proyecto");
                Console.WriteLine("3 - Otro");

                elementoEvaluable.Tipo = (TipoActividad)int.Parse(Console.ReadLine()!); 

                criterio.Actividades.Add(elementoEvaluable);
            }
            

            asignatura.Criterios.Add(criterio);
        }

        return asignatura;
    }
}