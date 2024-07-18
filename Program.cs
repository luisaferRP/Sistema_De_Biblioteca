using System.ComponentModel;
using System.Runtime.CompilerServices;
using SistemaBiblioteca.models;

var libro1 = new Libro("La rebelion",new DateOnly (2000,02,12),"Fernando Soto","Novela",25.000);

var biblioteca = new Biblioteca();

biblioteca.ListaLibros.Add(libro1);
var cc = biblioteca.ListaLibros.Select(item => new {
    Titulo = item.Titulo
});



//Menu de usuario 
do
{
    Console.WriteLine(@$"
    =====================================================
        Bienvenido al sistema de gestion de Biblioteca
        1.Agregar un libro.
        2.Buscar libro.
        3.Aplicar descuento a libro.
        4.Eliminar un libro.
        5.Ver descripcion de los libros.
        6.Libros ultimos 5 años.
        7.Libros año de publicacion.
    ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            AgregarLibro();
            break;
        case "2":
            break;
        
        default:
            break;
    }
    
} while (true);


//metodo para agregar libro
void AgregarLibro()
{
    Console.WriteLine(@$"
    =====================================
            Añadir un libro:
    =====================================
    ");
    Console.WriteLine("Ingrese el titulo del libro : ");
    string? titulo = Console.ReadLine();

    Console.WriteLine($"Ingrese el año de publicación de {titulo} : ");
    string? añoPublicacion = Console.ReadLine();

    Console.WriteLine($"Ingrese el autor del libro {titulo}: ");
    string? autor = Console.ReadLine();

    Console.WriteLine("Ingrese el genero del libro : ");
    string? genero = Console.ReadLine();

    Console.WriteLine("Ingrese el precio del libro : ");
    string? precio = Console.ReadLine();

}