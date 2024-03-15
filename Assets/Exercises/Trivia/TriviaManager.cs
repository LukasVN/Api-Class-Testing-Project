using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaManager : MonoBehaviour
{
    public static TriviaManager instance;
    public List<string> questions = new List<string>();
    private bool printedQuestions = false;
    public string difficulty {get;set;}
    public string category {get;set;}
    public List<string> answers = new List<string>();
    private bool firstQuestion = false;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(questions.Count == 10 && !printedQuestions){
            foreach (string question in questions)
            {
                Debug.Log(question);
                if(!firstQuestion){
                    Debug.Log("Difficulty: "+difficulty);
                    Debug.Log(category);
                    foreach (string answer in answers)
                    {
                        Debug.Log(answer);
                    }
                    firstQuestion = true;
                }
            }
            printedQuestions = true;
        }
    }

    public void AddQuestions(string question){
        questions.Add(question);
    }
}
