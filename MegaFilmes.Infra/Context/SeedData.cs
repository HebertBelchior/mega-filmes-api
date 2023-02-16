using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Infra.Context;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (!context.Generos.Any())
        {
            var generos = new Genero[]
            {
                new Genero { Nome = "Aventura" },
                new Genero { Nome = "Ação" },
                new Genero { Nome = "Comédia" },
                new Genero { Nome = "Suspense" },
                new Genero { Nome = "Terror" },
            };

            context.Generos.AddRange(generos);
            context.SaveChanges();
        }

        if (!context.Filmes.Any())
        {
            var filmes = new Filme[]
            {
                new Filme {
                    Nome = "Homem de Ferro",
                    Descricao = "Um bilionário constrói um traje de alta tecnologia para se tornar um super-herói e lutar contra o mal.",
                    Ano = 2008,
                    Diretor = "Jon Favreau",
                    GeneroId = 1
                },
                new Filme {
                    Nome = "Vingadores: Guerra Infinita",
                    Descricao = "Os Vingadores se unem para impedir que Thanos obtenha todas as seis Joias do Infinito e destrua metade do universo.",
                    Ano = 2018,
                    Diretor = "Anthony Russo",
                    GeneroId = 1
                },
                new Filme {
                    Nome = "Pantera Negra",
                    Descricao = "T'Challa retorna para Wakanda após a morte de seu pai, o rei, para assumir o trono e se tornar o Pantera Negra, um herói que protege seu povo e seu país.",
                    Ano = 2018,
                    Diretor = "Ryan Coogler",
                    GeneroId = 2

                },
                new Filme {
                    Nome = "Liga da Justiça",
                    Descricao = "Batman, Mulher-Maravilha, Aquaman, Flash e Ciborgue se unem para enfrentar uma ameaça cósmica que pode destruir o mundo.",
                    Ano = 2017,
                    Diretor = "Zack Snyder",
                    GeneroId = 2

                },
                new Filme {
                    Nome = "Batman: O Cavaleiro das Trevas",
                    Descricao = "Batman enfrenta o Coringa, um vilão insano que espalha o caos em Gotham City.",
                    Ano = 2008,
                    Diretor = "Christopher Nolan",
                    GeneroId = 4
                },
                new Filme {
                    Nome = "Mulher-Maravilha",
                    Descricao = "Diana, uma princesa das Amazonas, deixa sua ilha para ajudar a acabar com a Primeira Guerra Mundial, descobrindo sua verdadeira vocação como a heroína conhecida como Mulher-Maravilha.",
                    Ano = 2017,
                    Diretor = "Patty Jenkins",
                    GeneroId = 4
                },
            };

            context.Filmes.AddRange(filmes);
            context.SaveChanges();
        }

        if (!context.Atores.Any())
        {
            var atores = new Ator[]
            {
                new Ator { Nome = "Robert Downey Jr." },
                new Ator { Nome = "Chris Evans" },
                new Ator { Nome = "Scarlett Johansson" },
                new Ator { Nome = "Mark Ruffalo" },
                new Ator { Nome = "Tom Holland" },
                new Ator { Nome = "Chadwick Boseman" },
                new Ator { Nome = "Ben Affleck" },
                new Ator { Nome = "Gal Gadot" },
                new Ator { Nome = "Henry Cavill" },
                new Ator { Nome = "Jason Momoa" },
            };

            context.Atores.AddRange(atores);
            context.SaveChanges();
        }

        if (!context.FilmesAtores.Any())
        {
            var elenco = new FilmeAtor[]
            {
                new FilmeAtor { AtorId = 1, FilmeId = 1, Papel = "Homem de Ferro" },
                new FilmeAtor { AtorId = 1, FilmeId = 2, Papel = "Homem de Ferro" },
                new FilmeAtor { AtorId = 2, FilmeId = 2, Papel = "Capitão América" },
                new FilmeAtor { AtorId = 3, FilmeId = 2, Papel = "Viúva Negra" },
                new FilmeAtor { AtorId = 6, FilmeId = 3, Papel = "Pantera Negra" },
                new FilmeAtor { AtorId = 7, FilmeId = 4, Papel = "Batman" },
                new FilmeAtor { AtorId = 9, FilmeId = 4, Papel = "Superman" },
                new FilmeAtor { AtorId = 8, FilmeId = 6, Papel = "Mulher Maravilha" },
            };

            context.FilmesAtores.AddRange(elenco);
            context.SaveChanges();
        }

    }
}


