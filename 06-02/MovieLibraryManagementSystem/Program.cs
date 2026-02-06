using System;
using System.Collections.Generic;

public class DefaultSolution
{
    public static void Main(string[] args)
    {
        IFilmLibrary library = new FilmLibrary();

        Console.WriteLine("TEST CASE 1: Adding films");

        Film f1 = new Film("Inception", "Christopher Nolan", 2010);
        Film f2 = new Film("Interstellar", "Christopher Nolan", 2014);
        Film f3 = new Film("Titanic", "James Cameron", 1997);

        library.AddFilm(f1);
        library.AddFilm(f2);
        library.AddFilm(f3);

        Console.WriteLine("Films added successfully\n");

        Console.WriteLine("TEST CASE 2: Displaying all films");
        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
        }
        Console.WriteLine();

        Console.WriteLine("TEST CASE 3: Search films by director 'Nolan'");
        List<IFilm> searchResult = library.SearchFilms("Nolan");
        foreach (Film film in searchResult)
        {
            Console.WriteLine($"{film.Title} | {film.Director}");
        }
        Console.WriteLine();

        Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
        library.RemoveFilm("Titanic");

        Console.WriteLine("Remaining films:");
        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine(film.Title);
        }
        Console.WriteLine();

        Console.WriteLine("TEST CASE 5: Total film count");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}
