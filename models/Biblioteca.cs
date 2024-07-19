using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.models
{
    public class Biblioteca
    {
        public List<Libro> ListaLibros;

        //constructor
        public Biblioteca()
        {
            ListaLibros = new List<Libro>();
            // Crear e inicializar la lista

        }

        //metodo para agregar libro 
        public void AgregarLibro()
        {
            Console.WriteLine(@$"
            =====================================
                    Añadir un libro:
            =====================================
            ");
            Console.WriteLine("Ingrese el titulo del libro : ");
            string? titulo = Console.ReadLine();

            Console.WriteLine($"Ingrese el año de publicación de {titulo} : YYYY/MM/DD");
            DateTime añoPublicacion = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine($"Ingrese el autor de el libro {titulo}: ");
            string? autor = Console.ReadLine();

            Console.WriteLine("Ingrese el genero de el libro : ");
            string? genero = Console.ReadLine();

            Console.WriteLine("Ingrese el precio de el libro : ");
            double precio = Convert.ToDouble(Console.ReadLine());

            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor) || string.IsNullOrEmpty(genero))
            {
                Console.WriteLine("Algún dato ingresado no es valido");
            }
            else
            {

                var newLibro = new Libro(titulo, añoPublicacion, autor, genero, precio);
                ListaLibros.Add(newLibro);

                var listaBiblioteca = ListaLibros.Select(item => new
                {
                    titulo = item.Titulo,
                    año = item.AñoPublicacion,
                    autor = item.Autor,
                    genero = item.Genero,
                    precio = item.Precio
                }).ToList();

                Console.WriteLine(@$"
                ================================================================================
                                                 Libros
                ================================================================================");

                foreach (var libro in listaBiblioteca)
                {
                    Console.WriteLine(@$"Título: {libro.titulo,-10} | Fecha de publicación: {libro.año,-10} | Autor: {libro.autor} | Género: {libro.genero,-10} | Precio: {libro.precio,-10}");
                }
            }

        }

        //metodo para buscar libros ----------------
        public void BuscarLibro()
        {
            Console.WriteLine(@"
            ========================================================
                            Buscador de libro
            ========================================================");
            Console.WriteLine("Por favor ingresa el titulo o autor del libro: ");
            //? si al leerse la linea el resultado es null evita que trim se ejecute 
            string? nombreBuscar = Console.ReadLine()?.Trim();
            Console.WriteLine("llegando" + nombreBuscar);

            if (string.IsNullOrEmpty(nombreBuscar))
            {
                Console.WriteLine("¡Ey! El titulo o autor no pueden esta vacios.");
            }
            else
            {
                var encontrado = ListaLibros.Where(item => item.Autor.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase) || item.Titulo.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase)).Select(item => new
                {
                    titulo = item.Titulo,
                    añoPublicacion = item.AñoPublicacion,
                    autor = item.Autor,
                    genero = item.Genero,
                    precio = item.Precio
                }).ToList();

                if (encontrado.Count() == 0)
                {
                    Console.WriteLine("El libro o autor no han sido encontrados...");
                }
                else
                {
                    foreach (var libro in encontrado)
                    {
                        Console.WriteLine(@$"Titulo: {libro.titulo,-10} | Fecha de publicación: {libro.añoPublicacion,-10} | Autor: {libro.autor,-10} | Genero: {libro.genero,-10} | Precio: {libro.precio,-10}");
                    }
                }
            }
        }
    }


}