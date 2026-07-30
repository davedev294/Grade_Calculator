namespace AppCalculoMedia.Models
{
    // Primero tenemos la asignatura, cada asignatura tiene varios criterios de evaluación, y cada uno de esos criterios tiene actividades con distintos valores.
    // Cada actividad tiene nota y peso dentro del criterio, el criterio luego calcula todas las actividades con sus porcentajes y así tienes la nota final del criterio
    // Luego la asignatura calcula la nota final haciendo lo mismo de antes solo que con los criterios.
    public class Asignatura
    {
        public string Nombre { get; set; } = "";
        public List<Criterio> Criterios { get; set; } = new List<Criterio>();

        public double CalcularNotaFinal()
        {
            double notaFinal = 0;

            foreach (Criterio criterio in Criterios)
            {
                notaFinal += criterio.CalcularNota() * (criterio.Peso / 100);
            }

            return notaFinal;
        }
    }

    public class Criterio
    {
        public string Nombre { get; set; } = "";
        public double Peso { get; set; }

        public List<ElementoEvaluable> Actividades { get; set; } = new List<ElementoEvaluable>();

        public double CalcularNota()
        {
            double nota = 0;

            foreach (ElementoEvaluable actividad in Actividades)
            {
                nota += actividad.Nota * (actividad.Peso / 100);
            }

            return nota;
        }
    }

    public class ElementoEvaluable
    {
        public string Nombre { get; set; } = "";
        public double Peso { get; set; }
        public double Nota { get; set; }

        public TipoActividad Tipo { get; set; }
    }

    public enum TipoActividad
    {
        Examen,
        Tarea,
        Proyecto,
        Otro
    }
}