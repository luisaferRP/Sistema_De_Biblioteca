using System.ComponentModel;
using System.Runtime.CompilerServices;
using SistemaBiblioteca.models;

// var libro1 = new Libro("La rebelion",new DateTime(2000,02,12),"Fernando Soto","Novela",25.000);

// var biblioteca = new Biblioteca();

//Menu de usuario 


var biblioteca = new Biblioteca();
do
{
    Console.WriteLine(@$"
    =====================================================
        Bienvenido al sistema de gestion de Biblioteca
        1.Agregar un libro.
        2.Buscar libro.
        3.Eliminar un libro.
        4.Ver descripcion de los libros.
        5.Aplicar descuento a libro.
        6.Libros ultimos 5 años.
        7.Libros año de publicacion.
    ");

    var opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            biblioteca.AgregarLibro();
            break;
        case "2":
            biblioteca.BuscarLibro();
            break;
        
        default:
            break;
    }
    
} while (true);

