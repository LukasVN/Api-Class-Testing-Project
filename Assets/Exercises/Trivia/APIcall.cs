using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class APIcall : MonoBehaviour
{
    [Serializable]
    class Questions{
        public int response_code;
        public List<Question> results;
    }
    
    [Serializable]
    class Question{
        public string type;
        public string difficulty;
        public string category;
        public string question;
        public string correct_answer;
        public string[] incorrect_answers;
    }

    void Start()
    {
        //Api call to a Json
        StartCoroutine(GetRequest("https://opentdb.com/api.php?amount=10"));
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

                    Questions questions = JsonUtility.FromJson<Questions>(webRequest.downloadHandler.text);

                    foreach (Question question in questions.results)
                    {
                        TriviaManager.instance.AddQuestions(question.question);
                    }

                    TriviaManager.instance.difficulty = questions.results[0].difficulty;
                    TriviaManager.instance.category = questions.results[0].category;
                    TriviaManager.instance.answers.Add(questions.results[0].correct_answer);
                    foreach (string answer in questions.results[0].incorrect_answers)
                    {
                        TriviaManager.instance.answers.Add(answer);
                    }
                    break;
            }
        }
    }


}
