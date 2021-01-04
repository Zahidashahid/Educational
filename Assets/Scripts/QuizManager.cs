using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : MonoBehaviour
{
    public LevelDataOfProgramming[] allLevel;
    public List<QuestionAnswer> QusAns;//Array list of all possible question
    public GameObject[] options;
    public int currentQuestion;
    public Text questionText;
    public GameObject quizPanel;
    public GameObject statusPanel;
    public Text scoreText;
    public int totalQuestion = 0;
    public int score;
   private void Start()
   {
        //DontDestroyedOnLoad(gameObject);
        totalQuestion = QusAns.Count;
        statusPanel.SetActive(false);
        GenerateQuestion();
       // QusAns.RemoveAt(currentQuestion);
   }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        quizPanel.SetActive(false);
        statusPanel.SetActive(true);
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
         scoreText.text = score + "/" + totalQuestion;
    }
   public void Correct()
   {
       Debug.Log("I am in correct method");
        score += 1;
       QusAns.RemoveAt(currentQuestion); // remove question once displayed
       GenerateQuestion();
   }
    public void Wrong()
    {
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
            GameOver();
       }


   }


    ///public LevelDataOfProgramming GetLevelData()
   // {
    //    return allLevel[0];
    //}
}
