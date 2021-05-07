using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Text optionText;

    private int giveEither = 1;
    private int giveFormula = 2;
    private int giveName = 3;

    public void ResumeGame()
    {
        if(optionText.text == "Give Either")
        {
            // set the optionValue so it gives both types of questions
            MainMenu.optionValue = giveEither;
        }
        else if(optionText.text == "Give Formula")
        {
            // set the optionValue so it gives formula
            MainMenu.optionValue = giveFormula;
        }
        else if(optionText.text == "Give Name")
        {
            // set the optionValue so it gives name
            MainMenu.optionValue = giveName;
        }

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
