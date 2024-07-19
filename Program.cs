using System.ComponentModel;
using System.Runtime.CompilerServices;
using SistemaBiblioteca.models;

// var libro1 = new Libro("La rebelion",new DateTime(2000,02,12),"Fernando Soto","Novela",25.000);

// var biblioteca = new Biblioteca();

//Menu de usuario 

//instaciamos la biblioteca
var biblioteca = new Biblioteca();

//bandera 
bool bandera = true;
do
{
    Console.WriteLine(@$"
    ===========================================================
    |       Bienvenio al sistema gestion de Biblioteca        |
    ===========================================================
    |   0.Salir del programa.                                 |
    |   1.Agregar un libro.                                   |
    |   2.Buscar libro.                                       |
    |   3.Eliminar un libro.                                  |
    |   4.Ver descripcion de los libros.                      |
    |   5.Aplicar descuento a libro.                          |
    |    6.Libros ultimos 5 años.                             |
    |    7.Libros año de publicacion.                         |
    ===========================================================
                ¿ Que deseas hacer ?
    ");

    var opcion = Console.ReadLine();
    switch (opcion)
    {
        case "0":
            Console.WriteLine("¡Que te vaya muy bien!");
            bandera = false;
            break;
        case "1":
            biblioteca.AgregarLibro();
            break;
        case "2":
            biblioteca.BuscarLibro();
            break;
        case "3":
            biblioteca.EliminarLibro();
            break;
        case "4":
            break;
        case "5":
            biblioteca.AplicarDescuento();
            break;
        case "6":
            biblioteca.LibroUltimosAños();
            break;
        case "7":

            break;
        
        default:
            Console.WriteLine("Ingresaste una opción invalida ");
            break;
    }
    
} while (bandera);

