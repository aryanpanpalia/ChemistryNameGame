using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question [] questions;
    public Question currentQuestion;

    [SerializeField]
    private Text questionText;

    // where the answer input is stored
    [SerializeField]
    private InputField answerInputFieldText;

    [SerializeField]
    private Text inputText;

    [SerializeField]
    private Text displayText;

    // end of where answer input is stored

    [SerializeField]
    private Feedback feedback;

    [SerializeField]
    private GameObject buttonArea;

    [SerializeField]
    private Button button;

    [SerializeField]
    public static int points;

    [SerializeField]
    private Text pointsText;

    [SerializeField]
    private TextAsset textAsset;

    private bool gaveUp;
    public bool justGotItRight;

    void Start() 
    {
        points = 0;
        pointsText.text = "0";

        gaveUp = false;
        justGotItRight = false;
        
        buttonArea.SetActive(false);
        button.enabled = false;

        string [] lines = textAsset.text.Split('\n');
        questions = new Question[lines.Length - 1];

        for(int i = 0; i < lines.Length - 1; i++)
        {
            string line = lines[i];
            int firstSpaceIndex = line.IndexOf(" ");
            string formula = line.Substring(0, firstSpaceIndex).Trim();
            string name = line.Substring(firstSpaceIndex + 1).Trim();

            Question question;

            int optionValue = MainMenu.optionValue;
            if(optionValue == 1)
            {
                // both type of questions
                int rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    questions[i] = new Question(formula, name);
                }
                else
                {
                    questions[i] = new Question(name, formula);
                }
            }
            else if(optionValue == 2)
            {
                // Give formula as question
                questions[i] = new Question(formula, name);
            }
            else if(optionValue == 3)
            {
                // give name as question
                questions[i] = new Question(name, formula);
            }
        }

        SetCurrentQuestion();       
    }

    void SetCurrentQuestion()
    {
        int rand = Random.Range(0, questions.Length);
        currentQuestion = questions[rand];

        questionText.text = currentQuestion.question;
    }

    public void UserAnswerCorrect()
    {
        if(justGotItRight)
        {
            return;
        }  

        if(displayText.text == currentQuestion.answer)
        {
            answerInputFieldText.text = "";
            displayText.text = "";
            inputText.text = "";

            feedback.UserWasCorrect();
            buttonArea.SetActive(true);
            button.enabled = true;

            if(!gaveUp)
            {
                AddTwoPoints();
            }
            gaveUp = false;
            justGotItRight = true;
        }
        else
        {
            feedback.UserWasWrong();
            SubtractOnePoint();
        }
    }

    public void ProcessNextButton()
    {
        feedback.RemoveFeedback();
        SetCurrentQuestion();
        buttonArea.SetActive(false);
        button.enabled = false;
        justGotItRight = false;

    }

    public void AddTwoPoints()
    {
        points += 2;
        pointsText.text = "" + points;
    }

    public void SubtractOnePoint()
    {
        points -= 1;
        pointsText.text = "" + points;
    }

    public void SubtractThreePoints()
    {
        // clicking give up after getting it right or giving up but before clicking next
        if(justGotItRight || gaveUp)
        {
            return;
        }

        // just gave up, so next right answer is forced and shouldn't be counted
        gaveUp = true;

        points -= 3;
        pointsText.text = "" + points;
    }


}
