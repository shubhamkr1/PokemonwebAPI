using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace PokemonConsoleApp
{
    public class PokeClient
    {
        HttpClient client = new HttpClient();
        Pokemon pokemonData = new Pokemon();
        DamageDetails damageRelationsData = new DamageDetails();
        string url = "";
        public PokeClient() { }

        public async Task<Pokemon> GetPokemonAsync(string pokemonName)
        {
           
            var responseTask = client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + pokemonName);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var message = result.Content.ReadAsStringAsync();

                    pokemonData = JsonConvert.DeserializeObject<Pokemon>(message.Result);
                    //pokemonData
                    return pokemonData;
                }
                else
                {
                    Console.WriteLine("Pokémon not found or there was an error.");

                }
            }
            else
            {
                Console.WriteLine("Pokémon not found or there was an error.");
                return null;
            }
            return null;
        }


        public async Task<DamageDetails> GetTypeDataAsync(string url)
        {
            var responseTask = client.GetAsync(url);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var message = result.Content.ReadAsStringAsync();                  

                    damageRelationsData = JsonConvert.DeserializeObject<DamageDetails>(message.Result);
                    
                    return damageRelationsData;
                }
                else
                {
                    Console.WriteLine("Pokémon type details had some errors");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Pokémon type details not found");
            return null;
        }

           
    }
}
