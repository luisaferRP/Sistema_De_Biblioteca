using System;
using System.Collections.Generic;

namespace SistemaBiblioteca.models
{
    public class Libro : Publicacion
    {
        public Guid ISBN;
        public string Autor;
        public string Genero;
        public double Precio;


        //Constructor
        public Libro(string titulo,DateTime añoPublicacion,string autor, string genero,double precio)
        {
            this.Titulo = titulo;
            this.AñoPublicacion = añoPublicacion;
            this.ISBN = Guid.NewGuid();
            this.Autor = autor;
            this.Genero = genero;
            this.Precio = precio; 
        }

        //Metodo Descripcion
        public void Descripcion()
        {
            Console.WriteLine(@$"
            --------------------------------
                    Datos del libro:
            
            Titulo : {Titulo}
            Autor: {Autor}
            Genero : {Genero}
            Precio : {Precio}
            ");

        }
    }
}