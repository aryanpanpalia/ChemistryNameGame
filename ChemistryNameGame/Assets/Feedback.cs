using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Feedback : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        text.enabled = false;
    }

    public void GiveAnswer()
    {
        if(gameManager.justGotItRight)
        {
            return;
        }

        image.GetComponent<Image>().color = new Color32(255,0,0,100);
        image.enabled = true;

        text.text = gameManager.currentQuestion.answer;
        text.enabled = true;
    }

    public void UserWasCorrect()
    {
        image.GetComponent<Image>().color = new Color32(0,255,0,100);
        image.enabled = true;

        text.text = "Correct!";
        text.enabled = true;
    }

    public void UserWasWrong()
    {
        image.GetComponent<Image>().color = new Color32(255,0,0,100);
        image.enabled = true;

        text.text = "Incorrect! Try again!";
        text.enabled = true;
    }    

    public void RemoveFeedback()
    {
        image.enabled = false;
        text.enabled = false;
    }

}
