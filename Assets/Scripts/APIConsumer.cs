using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;


public class APIConsumer : MonoBehaviour
{
    private string pokemon;
    private float weight;
    private float height;
    private string pokemonID;
    public Image pokemonSprite;
    public int maxRange;
    void Start()
    {
        StartCoroutine(GetRandomPokemonCoroutine());
        //StartCoroutine(GetPokemonDataCoroutine());
        //StartCoroutine(GetPokemonImageCoroutine());
    }


    IEnumerator GetRandomPokemonCoroutine()
    {
        string apiUrl = "https://pokeapi.co/api/v2/pokemon?limit="+maxRange;
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var N = JSON.Parse(request.downloadHandler.text);
            Debug.Log(N.ToString());
            // Now you can access your data dynamically. For example:
            string value = N["results"][Random.Range(0,maxRange+1)]["name"].Value; // Assuming 'key' exists in your JSON
            Debug.Log(value);
            pokemon = value;
            StartCoroutine(GetPokemonDataCoroutine());
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    IEnumerator GetPokemonDataCoroutine()
    {
        string apiUrl = "https://pokeapi.co/api/v2/pokemon/"+pokemon;
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var N = JSON.Parse(request.downloadHandler.text);
            Debug.Log(N.ToString());
            // Now you can access your data dynamically. For example:
            string weightSTR = N["weight"].Value; // Assuming 'key' exists in your JSON
            string heightSTR = N["height"].Value;
            string pokemonIDSTR = N["id"].Value;
            pokemonID = pokemonIDSTR;
            weight = float.Parse(weightSTR)/10;
            height = float.Parse(heightSTR)/10;
            Debug.Log("ID API CALL: "+pokemonIDSTR);
            Debug.Log("ID: "+pokemonID);
            Debug.Log("Weight: "+weightSTR);
            Debug.Log("Height: "+heightSTR);
            StartCoroutine(GetPokemonImageCoroutine());
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    IEnumerator GetPokemonImageCoroutine()
    {
        string apiUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"+pokemonID+".png";
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(apiUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            pokemonSprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            pokemonSprite.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log(request.error);
        }
    }

}


