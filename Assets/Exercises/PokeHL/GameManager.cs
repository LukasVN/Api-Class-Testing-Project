using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public List<float> pokemonHeights;
    public GameObject[] buttons;
    public bool canPrint = false;
    private bool printed = false;
    private int score;
    private void Awake() {
        instance = this;
    }

    public void CheckPokemonHeight(string comparisonType){
        if(comparisonType.Equals("Taller")){
            if(pokemonHeights[0] >= pokemonHeights[1]){
                score++;
                scoreText.text = ""+score;
                APIConsumer.instance.NextRound();
            }
            else{
                //Handle lose
                Debug.Log("YOU LOSE");
            }
        }
        else if(comparisonType.Equals("Smaller")){
            if(pokemonHeights[0] <= pokemonHeights[1]){
                score++;
                scoreText.text = ""+score;
                APIConsumer.instance.NextRound();
            }
            else{
                //Handle lose
                Debug.Log("YOU LOSE");
            }
        }
    }

    public void SetButtonsState(){
        
    }



}
