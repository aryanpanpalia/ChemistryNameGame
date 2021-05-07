using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text optionText;

    public static int optionValue;

    private int giveEither = 1;
    private int giveFormula = 2;
    private int giveName = 3;

    public void PlayGame()
    {
        if(optionText.text == "Give Either" || optionText.text == "Game type")
        {
            // set the optionValue so it gives both types of questions
            optionValue = giveEither;
        }
        else if(optionText.text == "Give Formula")
        {
            // set the optionValue so it gives formula
            optionValue = giveFormula;
        }
        else
        {
            // set the optionValue so it gives name
            optionValue = giveName;
        }

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
