using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections; 


public class APIConsumer : MonoBehaviour
{
    private string pokemon;
    void Start()
    {
        StartCoroutine(GetRandomPokemonCoroutine());
        //StartCoroutine(GetPokemonDataCoroutine());
    }

    

    IEnumerator GetRandomPokemonCoroutine()
    {
        string apiUrl = "https://pokeapi.co/api/v2/pokemon?limit=1301";
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var N = JSON.Parse(request.downloadHandler.text);
            Debug.Log(N.ToString());
            // Now you can access your data dynamically. For example:
            pokemon = N["results"][Random.Range(0,1301)]["name"].Value; // Assuming 'key' exists in your JSON

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
            string weight = N["weight"].Value; // Assuming 'key' exists in your JSON
            string height = N["height"].Value;
            Debug.Log("Pokemon weight: "+weight);
            Debug.Log("Pokemon height: "+height);

        }
        else
        {
            Debug.LogError(request.error);
        }
    }


}


