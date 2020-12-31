using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QusAns;//Array list of all possible question
    public GameObject[] options;
    public int currentQuestion;
    public Text questionText;
   private void Start()
   {
        GenerateQuestion();
       // QusAns.RemoveAt(currentQuestion);
   }
   public void Correct()
   {
       Debug.Log("I am in correct method");
       QusAns.RemoveAt(currentQuestion); // remove question once displayed
       GenerateQuestion();
   }
    public void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QusAns[currentQuestion].answers[i];// will get the answer (option text )
            if(QusAns[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
      }
    }

   public void GenerateQuestion() //Generate question to display
   {
       if(QusAns.Count > 0)
       {
            currentQuestion = Random.Range(0, QusAns.Count);

            questionText.text = QusAns[currentQuestion].question;

            SetAnswer();
            //QusAns.RemoveAt(currentQuestion);
      
       }
       else
       {
           Debug.Log("Out of Questions");
       }


   }

}
