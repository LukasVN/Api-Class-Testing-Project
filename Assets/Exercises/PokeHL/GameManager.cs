using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public List<float> pokemonHeights;
    public GameObject[] buttons;
    public GameObject gameOverText;
    public bool canPrint = false;
    private int score;
    public bool isGameOver {get;set;}
    private void Awake() {
        instance = this;
    }

private void Update() {
    if(isGameOver){
        gameOverText.SetActive(true);
        SetButtonsState(false);
    }
}
    public void CheckPokemonHeight(string comparisonType){
        if(comparisonType.Equals("Taller")){
            if(pokemonHeights[0] >= pokemonHeights[1]){
                score++;
                scoreText.text = ""+score;
                pokemonHeights.Clear();
                APIConsumer.instance.NextRound();               
            }
            else{
                Debug.Log("YOU LOSE");
                isGameOver = true;
            }
        }
        else if(comparisonType.Equals("Smaller")){
            if(pokemonHeights[0] <= pokemonHeights[1]){
                score++;
                scoreText.text = ""+score;
                pokemonHeights.Clear();
                APIConsumer.instance.NextRound();
            }
            else{
                Debug.Log("YOU LOSE");
                isGameOver = true;
            }
            
        }

    }

    public void SetButtonsState(bool state){
        foreach (GameObject item in buttons)
        {
            item.SetActive(state);
        }
    }



}
