using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCheckHeight : MonoBehaviour
{
    public string comparisonType;

    public void CheckHeightButton(){
        GameManager.instance.CheckPokemonHeight(comparisonType);
    }
}
