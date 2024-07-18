using System.Runtime.CompilerServices;
using SistemaBiblioteca.models;

var libro1 = new Libro("La rebelion",new DateOnly (2000,02,12),"Fernando Soto","Novela",25.000);
var biblioteca = new Biblioteca();

biblioteca.ListaLibros.Add(libro1);
var cc = biblioteca.ListaLibros.Select(item => new {
    Titulo = item.Titulo
});

//Menu de usuario 
while (true)
{
    Console.WriteLine(@$"
    ===========================================
        Bienvenido al sistema 
    
    ");
    
}

