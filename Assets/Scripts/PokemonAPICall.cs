using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PokemonAPICall : MonoBehaviour
{
    public string pokemon;
    
    // SimpleJSON Need to be added
    void Start()
    {
        //Api call to a Json
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/pokemon/"+pokemon));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                    Root pokemonRoot = JsonUtility.FromJson<Root>(webRequest.downloadHandler.text);

                    Debug.Log(pokemonRoot.weight);
                    Debug.Log(pokemonRoot.height);
                    
                    break;
            }
        }
    }
    [Serializable]
    public class Ability
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
    [Serializable]
    public class Ability2
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class Animated
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class BlackWhite
    {
        public Animated animated { get; set; }
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Cries
    {
        public string latest { get; set; }
        public string legacy { get; set; }
    }
    [Serializable]
    public class Crystal
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_transparent { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_transparent { get; set; }
        public string front_transparent { get; set; }
    }
    [Serializable]
    public class DiamondPearl
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class DreamWorld
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
    }
    [Serializable]
    public class Emerald
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
    [Serializable]
    public class FireredLeafgreen
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
    [Serializable]
    public class Form
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class GameIndex
    {
        public int game_index { get; set; }
        public Version version { get; set; }
    }
    [Serializable]
    public class GenerationI
    {
        public RedBlue redblue { get; set; }
        public Yellow yellow { get; set; }
    }
    [Serializable]
    public class GenerationIi
    {
        public Crystal crystal { get; set; }
        public Gold gold { get; set; }
        public Silver silver { get; set; }
    }
    [Serializable]
    public class GenerationIii
    {
        public Emerald emerald { get; set; }
        public FireredLeafgreen fireredleafgreen { get; set; }
        public RubySapphire rubysapphire { get; set; }
    }
    [Serializable]
    public class GenerationIv
    {
        public DiamondPearl diamondpearl { get; set; }

        public HeartgoldSoulsilver heartgoldsoulsilver { get; set; }
        public Platinum platinum { get; set; }
    }
    [Serializable]
    public class GenerationV
    {
        public BlackWhite blackwhite { get; set; }
    }
    [Serializable]  
    public class GenerationVi
    {
        public OmegarubyAlphasapphire omegarubyalphasapphire { get; set; }

        public XY xy { get; set; }
    }
    [Serializable]
    public class GenerationVii
    {
        public Icons icons { get; set; }

        public UltraSunUltraMoon ultrasunultramoon { get; set; }
    }
    [Serializable]
    public class GenerationViii
    {
        public Icons icons { get; set; }
    }
    [Serializable]
    public class Gold
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_transparent { get; set; }
    }
    [Serializable]
    public class HeartgoldSoulsilver
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class HeldItem
    {
        public Item item { get; set; }
        public List<VersionDetail> version_details { get; set; }
    }
    [Serializable]
    public class Home
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Icons
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
    }
    [Serializable]
    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class Move
    {
        public Move move { get; set; }
        public List<VersionGroupDetail> version_group_details { get; set; }
    }
    [Serializable]
    public class Move2
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class MoveLearnMethod
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class OfficialArtwork
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
    [Serializable]
    public class OmegarubyAlphasapphire
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Other
    {
        public DreamWorld dream_world { get; set; }
        public Home home { get; set; }

        public OfficialArtwork officialartwork { get; set; }
        public Showdown showdown { get; set; }
    }
    [Serializable]
    public class Platinum
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class RedBlue
    {
        public string back_default { get; set; }
        public string back_gray { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_gray { get; set; }
        public string front_transparent { get; set; }
    }
    [Serializable]
    public class Root
    {
        public List<Ability> abilities { get; set; }
        public int base_experience { get; set; }
        public Cries cries { get; set; }
        public List<Form> forms { get; set; }
        public List<GameIndex> game_indices { get; set; }
        public int height { get; set; }
        public List<HeldItem> held_items { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public List<Move> moves { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public List<object> past_abilities { get; set; }
        public List<object> past_types { get; set; }
        public Species species { get; set; }
        public Sprites sprites { get; set; }
        public List<Stat> stats { get; set; }
        public List<Type> types { get; set; }
        public int weight { get; set; }
    }
    [Serializable]
    public class RubySapphire
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
    [Serializable]
    public class Showdown
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Silver
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_transparent { get; set; }
    }
    [Serializable]
    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class Sprites
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
        public Other other { get; set; }
        public Versions versions { get; set; }
    }
    [Serializable]
    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat stat { get; set; }
    }
    [Serializable]
    public class Stat2
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class Type
    {
        public int slot { get; set; }
        public Type type { get; set; }
    }
    [Serializable]
    public class Type2
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class UltraSunUltraMoon
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class VersionDetail
    {
        public int rarity { get; set; }
        public Version version { get; set; }
    }
    [Serializable]
    public class VersionGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [Serializable]
    public class VersionGroupDetail
    {
        public int level_learned_at { get; set; }
        public MoveLearnMethod move_learn_method { get; set; }
        public VersionGroup version_group { get; set; }
    }
    [Serializable]
    public class Versions
    {
        public GenerationI generationi { get; set; }

        public GenerationIi generationii { get; set; }

        public GenerationIii generationiii { get; set; }

        public GenerationIv generationiv { get; set; }

        public GenerationV generationv { get; set; }

        public GenerationVi generationvi { get; set; }

        public GenerationVii generationvii { get; set; }

        public GenerationViii generationviii { get; set; }
    }
    [Serializable]
    public class XY
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }
    [Serializable]
    public class Yellow
    {
        public string back_default { get; set; }
        public string back_gray { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_gray { get; set; }
        public string front_transparent { get; set; }
    }


}
