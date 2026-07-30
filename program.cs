using AppCalculoMedia.EntradaDatos;
using AppCalculoMedia.Models;

Asignatura asignatura = EntradaDatos.CrearAsignatura();

Console.WriteLine();
Console.WriteLine($"Asignatura: {asignatura.Nombre}");
Console.WriteLine($"Nota final: {asignatura.CalcularNotaFinal()}");