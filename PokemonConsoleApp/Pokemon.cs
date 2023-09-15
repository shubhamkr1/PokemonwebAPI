using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonConsoleApp
{
    public class Pokemon
    {
        public string Name {  get; set; }

        [JsonProperty("types")]
        public List<Types> Types { get; set; }
    }

    public class Types
    {
        public int slot { get; set; }

        [JsonProperty("type")]
        public PokeType type { get; set; }
    }

    public class PokeType
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class DamageDetails
    {
        public DamageRelations damage_relations { get; set; }        
    }

    public class DamageRelations
    {
        [JsonProperty("double_damage_from")]
        public List<DoubleDamageFrom> Double_damage_from { get; set; }
        [JsonProperty("double_damage_to")]
        public List<DoubleDamageTo> Double_damage_to { get; set; }
        [JsonProperty("half_damage_from")]
        public List<HalfDamageFrom> Half_damage_from { get; set; }
        [JsonProperty("half_damage_to")]
        public List<HalfDamageTo> Half_damage_to { get; set; }
        [JsonProperty("no_damage_from")]
        public List<NoDamageFrom> No_damage_from { get; set; }
        [JsonProperty("no_damage_to")]
        public List<NoDamageTo> No_damage_to { get; set; }
    }

    public class DoubleDamageFrom
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class DoubleDamageTo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class HalfDamageFrom
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class HalfDamageTo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class NoDamageFrom
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class NoDamageTo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
