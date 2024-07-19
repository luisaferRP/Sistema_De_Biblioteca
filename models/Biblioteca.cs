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
                        Console.WriteLine(@$"Titulo: {libro.titulo,-8} | Fecha de publicación: {libro.añoPublicacion,-10} | Autor: {libro.autor,-8} | Genero: {libro.genero,-8} | Precio: {libro.precio,-8}");
                    }
                }
            }
        }

        //metodo para eliminar un libro
        public void EliminarLibro()
        {
            Console.WriteLine(@$"
            ==================================================================
                                Lista de libros
            ================================================================== ");
            foreach (var item in ListaLibros)
            {
                Console.WriteLine(@$"Título: {item.Titulo,-8} | Fecha de publicación: {item.AñoPublicacion,-10} | Autor: {item.Autor,-8} | Género: {item.Genero,-8} | Precio: {item.Precio,-8}");
            }

            Console.WriteLine("Ingrese el titulo del libro que desea eliminar: ");
            string? nombreEliminar = Console.ReadLine()?.Trim();

            //se busca la primera coincidencia con el dato que se ingreso para eliminar
            var eliminar = ListaLibros.FirstOrDefault(item => item.Titulo == nombreEliminar);
            if (eliminar != null)
            {
                Console.WriteLine($"Esta seguro de eliminar {nombreEliminar} , SI/NO");
                string? opcionEliminar = Console.ReadLine()?.Trim();

                //confirmacion para eliminar
                if (opcionEliminar?.ToLower() == "si")
                {
                    ListaLibros.Remove(eliminar);
                    Console.WriteLine("¡Libro eliminado de forma exitosa!");

                    Console.WriteLine("========================== Libros disponibles ==========================");
                    foreach (var item in ListaLibros)
                    {
                        Console.WriteLine(@$"Título: {item.Titulo,-8} | Fecha de publicación: {item.AñoPublicacion,-10} | Autor: {item.Autor,-8} | Género: {item.Genero,-8} | Precio: {item.Precio,-8}");
                    }

                }
                else
                {
                    Console.WriteLine("Eliminacionn detenida.");
                }
            }

        }

        //Metodo para aplicar decuento
        public void AplicarDescuento()
        {
            Console.WriteLine("Ingrese el titulo de el libro al cual desea aplicarle el descuento: ");
            string? nombre = Console.ReadLine()?.Trim();

            Console.WriteLine("¿ De cuanto es el descuento que desea aplicar ?");
            double descuento = Convert.ToDouble(Console.ReadLine());

            var aplicarDescuento = ListaLibros.Where(item => item.Titulo == nombre).Select(i => new
            {
                Titulo = i.Titulo,
                AñoPublicacion = i.AñoPublicacion,
                Autor = i.Autor,
                Genero = i.Genero,
                Precio = i.Precio - (i.Precio * descuento)
            });

            if (aplicarDescuento != null || aplicarDescuento.Count() == 0)
            {
                Console.WriteLine("========================== Libro con descuento ==========================");
                foreach (var item in aplicarDescuento)
                {
                    Console.WriteLine(@$"Título: {item.Titulo,-8} | Autor: {item.Autor,-8} | Género: {item.Genero,-8} | Precio con descuento: {item.Precio,-8}");
                }

            }
            else
            {
                Console.WriteLine("No se encontró ningún libro con ese título.");
            }

        }

        //metodo libros ultimos 5 años
        public void LibroUltimosAños()
        {
            var today = DateTime.Now;

            //consulta para ver si esta entre los ultimos 5 años
            var librosUltimosAños = ListaLibros.Where(item => item.AñoPublicacion.Year >= today.Year - 5)
            .OrderByDescending(item => item.AñoPublicacion).Take(5).ToList(); // Asegúrate de materializar la consulta

            //si libros contiene cualquier elemento
            if (librosUltimosAños.Any())
            {
                foreach (var item in librosUltimosAños)
                {
                    Console.WriteLine($"Título: {item.Titulo,-8} | Autor: {item.Autor,-8} | Género: {item.Genero,-8} | Precio con descuento: {item.Precio,-8}");
                }
            }
            else
            {
                Console.WriteLine("No hay libros publicados en los últimos 5 años.");
            }
        }

        //libros año de publicacion
        public void AñoPublicacion()
        {
            Console.WriteLine("¿Por qué año deseas buscar?");
            DateTime AñoBusquedad = Convert.ToDateTime(Console.ReadLine());

            //consulta para ver si los libros que esten en ese año
            var busquedadAño = ListaLibros.Where(item => item.AñoPublicacion.Year == AñoBusquedad.Year)
            .OrderByDescending(item => item.AñoPublicacion).ToList();

            if (busquedadAño.Any())
            {

                 foreach (var item in busquedadAño)
                {
                    Console.WriteLine($"Año Publicación: {item.AñoPublicacion,-2} | Título: {item.Titulo,-5} | Autor: {item.Autor,-5} | Género: {item.Genero,-5} | Precio con descuento: {item.Precio,-5}");
                }
            }
        }
    }


}