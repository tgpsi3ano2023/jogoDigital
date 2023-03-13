using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ListennersButtons : MonoBehaviour
{
    public Button quitGame;
    public Button restartGame;
    public Button mainMenu;
    public Button creditos;
    public Button tutorial;
    public Button objetivos;
    public Button start;

    // Start is called before the first frame update
    void Start()
    {
        Button RestartButton = restartGame.GetComponent<Button>();
        Button QuitButton = quitGame.GetComponent<Button>();
        Button MainMenu = mainMenu.GetComponent<Button>();
        Button Creditos = creditos.GetComponent<Button>();
        Button Tutorial = tutorial.GetComponent<Button>();
        Button Objetivos = objetivos.GetComponent<Button>();
        Button Start = start.GetComponent<Button>();

        RestartButton.onClick.AddListener(RestartGame);
        QuitButton.onClick.AddListener(QuitGame);
        MainMenu.onClick.AddListener(MainMenuL);
        Creditos.onClick.AddListener(CreditosL);
        Tutorial.onClick.AddListener(TutorialL);
        Objetivos.onClick.AddListener(ObjetivosL);
        Start.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("cena1aviao");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenuL()
    {
        SceneManager.LoadScene("cena11MenuPrinc");
    }
    public void CreditosL()
    {
        SceneManager.LoadScene("cena10creditos");
    }
    public void TutorialL()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void ObjetivosL()
    {
        SceneManager.LoadScene("objetivos");
    }
}