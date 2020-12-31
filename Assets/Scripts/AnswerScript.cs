using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager = GameObject.Find("GameController").GetComponent<QuizManager>();
            quizManager.Correct();
            //Debug.Log("Correct Method called");
        }
        else
        {
            Debug.Log("Wrong Answer");
             quizManager = GameObject.Find("GameController").GetComponent<QuizManager>();
            quizManager.Correct();
        }
    }

}
