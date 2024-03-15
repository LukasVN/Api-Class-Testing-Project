using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;


public class APIConsumer : MonoBehaviour
{
    public static APIConsumer instance;
    private string pokemon;
    // private float weight;
    private float height;
    private string pokemonID;
    public Image leftPokemonSprite;
    public Image rightPokemonSprite;
    public int maxRange;
    
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(GetRandomPokemonCoroutine(leftPokemonSprite));
        Invoke("Delay",0.5f);
    }

    private void Update() {
        if(leftPokemonSprite.sprite != null && rightPokemonSprite.sprite != null){
            leftPokemonSprite.gameObject.SetActive(true); rightPokemonSprite.gameObject.SetActive(true);
            GameManager.instance.SetButtonsState(true);
        }
        else{
            leftPokemonSprite.gameObject.SetActive(false); rightPokemonSprite.gameObject.SetActive(false);
        }
    }

    public void NextRound(){
        leftPokemonSprite.sprite = null; rightPokemonSprite.sprite = null;
        StartCoroutine(GetRandomPokemonCoroutine(leftPokemonSprite));
        Invoke("Delay",0.5f);
    }
    
    private void Delay(){
        StartCoroutine(GetRandomPokemonCoroutine(rightPokemonSprite));
    }

    IEnumerator GetRandomPokemonCoroutine(Image pokemonSprite)
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
            StartCoroutine(GetPokemonDataCoroutine(pokemonSprite));
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    IEnumerator GetPokemonDataCoroutine(Image pokemonSprite)
    {
        string apiUrl = "https://pokeapi.co/api/v2/pokemon/"+pokemon;
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var N = JSON.Parse(request.downloadHandler.text);
            Debug.Log(N.ToString());
            // Now you can access your data dynamically. For example:
            // string weightSTR = N["weight"].Value; // Assuming 'key' exists in your JSON
            string heightSTR = N["height"].Value;
            string pokemonIDSTR = N["id"].Value;
            pokemonID = pokemonIDSTR;
            // weight = float.Parse(weightSTR)/10;
            height = float.Parse(heightSTR)/10;
            StartCoroutine(GetPokemonImageCoroutine(pokemonSprite));
            GameManager.instance.pokemonHeights.Add(height);
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    IEnumerator GetPokemonImageCoroutine(Image pokemonSprite)
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


