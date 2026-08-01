using System.Net.Http.Headers;
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
        int cantidadRA;
        while (!int.TryParse(Console.ReadLine(), out cantidadRA))
        {
            Console.WriteLine("Debes introducir un número");
        }

        for (int i = 0; i < cantidadRA; i++)
        {
            Criterio criterio = new Criterio();

            Console.WriteLine($"Nombre del RA {i + 1}: ");
            criterio.Nombre = Console.ReadLine()!;

            Console.WriteLine("Peso del RA: ");
            double Peso;

            while (!double.TryParse(Console.ReadLine(), out Peso))
            {
                Console.WriteLine("Debes introducir un número");
            }

            criterio.Peso = Peso;

            Console.WriteLine("Cantidad de Elementos Evaluables: ");
            int cantidadActividades;
            while (!int.TryParse(Console.ReadLine(), out cantidadActividades))
            {
                Console.WriteLine("Debes introducir un número");
            }

            for (int j = 0; j < cantidadActividades; j++)
            {
                ElementoEvaluable elementoEvaluable = new ElementoEvaluable();

                Console.WriteLine($"Nombre de la actividad {j + 1}: ");
                elementoEvaluable.Nombre = Console.ReadLine()!;

                Console.WriteLine("Peso de la actividad: ");
                while (!double.TryParse(Console.ReadLine(), out Peso))
                {
                    Console.WriteLine("Debes introducir un número");
                }

                elementoEvaluable.Peso = Peso;

                Console.WriteLine("Nota de la actividad: ");

                double Nota;

                while (!double.TryParse(Console.ReadLine(), out Nota))
                {
                    Console.WriteLine("Debes introducir un número");
                }
                elementoEvaluable.Nota = Nota;

                Console.WriteLine("Tipo de Actividad: ");
                Console.WriteLine("0 - Examen");
                Console.WriteLine("1 - Tarea");
                Console.WriteLine("2 - Proyecto");
                Console.WriteLine("3 - Otro");

                int tipo;

                while (!int.TryParse(Console.ReadLine(), out tipo))
                {
                    Console.WriteLine("Debes introducir un número");
                }

                int TipoAct;

                while (!int.TryParse(Console.ReadLine(), out TipoAct) || TipoAct < 0 || TipoAct > 3)
                {
                    Console.WriteLine("Introduce un número entre 0 y 3.");
                }

                elementoEvaluable.Tipo = (TipoActividad)tipo;

                criterio.Actividades.Add(elementoEvaluable);
            }
            

            asignatura.Criterios.Add(criterio);
        }

        return asignatura;
    }

    public static double CalcularMedia(List<Asignatura> asignaturas)
    {
        double suma = 0;

        foreach (Asignatura asignatura in asignaturas)
        {
            suma += asignatura.CalcularNotaFinal();
        }

        return suma / asignaturas.Count();
    }
}