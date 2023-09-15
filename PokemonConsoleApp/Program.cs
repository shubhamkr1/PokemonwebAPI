using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string pokemonName;
            Console.WriteLine("Pleaes enter the name of Pokemon:");
            pokemonName = Console.ReadLine();
            string url = "https://pokeapi.co/api/v2/pokemon/" + pokemonName;

            var apiClient = new PokeClient();

            var pokemon = await apiClient.GetPokemonAsync(pokemonName);
            

            if (pokemon != null)
            {
                // Analyze the type(s) of the Pokémon and fetch type relations
               
                Console.WriteLine("This pokemon has following types: ");
                foreach(var type in pokemon.Types )
                {
                    Console.WriteLine("type : " + type.type.name);
                    var typeRelations = await apiClient.GetTypeDataAsync(type.type.url);
                    if(typeRelations != null)
                    {
                        var mylist = typeRelations.damage_relations;
                        Console.WriteLine("This pokemon is strong against following types: ");
                        foreach(var damagedata in mylist.Double_damage_to)
                        {
                            Console.Write(damagedata.name+" ,");
                        }
                        foreach (var damagedata in mylist.No_damage_from)
                        {
                            Console.Write(damagedata.name + " ,");
                        }
                        foreach (var damagedata in mylist.Half_damage_from)
                        {
                            Console.Write(damagedata.name + " ,");
                        }
                        Console.WriteLine();

                        Console.WriteLine("This pokemon is weak against following types: ");
                        foreach (var damagedata in mylist.Double_damage_from)
                        {
                            Console.Write(damagedata.name + " ,");
                        }
                        foreach (var damagedata in mylist.No_damage_to)
                        {
                            Console.Write(damagedata.name + " ,");
                        }
                        foreach (var damagedata in mylist.Half_damage_to)
                        {
                            Console.Write(damagedata.name + " ,");
                        }
                        Console.WriteLine();

                    }

                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Could not retrieve Pokémon data.");
                Console.ReadLine();
            }
        }

      
    }
}
