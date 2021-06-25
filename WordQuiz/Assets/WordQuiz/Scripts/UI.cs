using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public GameObject ChooseGameStyle;
    public GameObject MainMenu;

    public void playButton()
    {
        ChooseGameStyle.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void chooseFruit()
    {
        SceneManager.LoadScene("FruitQuiz");
    }
    public void chooseAnimal()
    {
        SceneManager.LoadScene("AnimalQuiz");
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
