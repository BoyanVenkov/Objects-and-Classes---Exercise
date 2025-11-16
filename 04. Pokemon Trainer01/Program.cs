using System.Linq.Expressions;

namespace _04._Pokemon_Trainer01
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
    public class Program
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] data = input.Split();
                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);
                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Any(t => t.Name == trainerName))
                {
                    Trainer existingTrainer = trainers.First(t => t.Name == trainerName);
                    existingTrainer.Pokemons.Add(newPokemon);
                }
                else
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.Pokemons.Add(newPokemon);
                    trainers.Add(newTrainer);
                }

                input = Console.ReadLine();
            }
            string element = Console.ReadLine();

            while (element != "End")
            {
                foreach (Trainer currentTrainer in trainers)
                {
                    if (currentTrainer.Pokemons.Any(p => p.Element == element))
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in currentTrainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        currentTrainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
                element = Console.ReadLine();
            }
            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}