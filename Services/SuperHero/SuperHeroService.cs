﻿using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Models;

public class SuperHeroService : ISuperHeroService
{
    private static List<SuperHero> superHeroes = new List<SuperHero>
    {
        new SuperHero
        {
            Id = 1,
            Name = "Spider Man",
            FirstName = "Peter",
            LastName = "Parker",
            Place = "New York City"
        },
        new SuperHero
        {
            Id = 2,
            Name = "Iron Man",
            FirstName = "Tony",
            LastName = "Stark",
            Place = "Malibu"
        }
    };

    public List<SuperHero> GetAllHeroes()
    {
        return superHeroes;
    }

    public SuperHero? GetSingleHero(int id)
    {
        var hero = superHeroes.Find(sh => sh.Id == id);

        if (hero is null) return null;

        return hero;
    }

    public List<SuperHero> AddHero(SuperHero hero)
    {
        superHeroes.Add(hero);

        return superHeroes;
    }

    public List<SuperHero>? UpdateHero(int id, SuperHero request)
    {
        var hero = superHeroes.Find(sh => sh.Id == id);

        if (hero is null) return null;

        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Name = request.Name;
        hero.Place = request.Place;

        return superHeroes;
    }

    public List<SuperHero>? DeleteHero(int id)
    {
        var hero = superHeroes.Find(sh => sh.Id == id);

        if (hero is null) return null;

        superHeroes.Remove(hero);

        return superHeroes;
    }
}