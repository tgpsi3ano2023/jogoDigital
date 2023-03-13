using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Botões : MonoBehaviour
{
    public Button restartGame;
    public Button mainMenu;

    public Button marcio;
    public Button gonçalo;
    public Button alexandreSilva;
    public Button pedroRibeiro;
    public Button pedroGomes;
    public Button diogo;
    public Button carlos;
    public Button luisMachado;
    public Button alexandreCastro;
    public Button fernandoOliveira;
    public Button danielRego;
    public Button brunoFaria;

    public TextMeshProUGUI textoMarcio;
    public TextMeshProUGUI textgonçalo;
    public TextMeshProUGUI textoAlexandreSilva;
    public TextMeshProUGUI textoPedroRibeiro;
    public TextMeshProUGUI textoPedroGomes;
    public TextMeshProUGUI textDiogo;
    public TextMeshProUGUI textoCarlos;
    public TextMeshProUGUI textoLuisMachado;
    public TextMeshProUGUI textoAlexandreCastro;
    public TextMeshProUGUI textoFernandoOliveira;
    public TextMeshProUGUI textoDanielRego;
    public TextMeshProUGUI textoBrunoFaria;


    // Start is called before the first frame update
    void Start()
    {
        Button RestartButton = restartGame.GetComponent<Button>();
        //Button QuitButton = quitGame.GetComponent<Button>();
        Button MainMenu = mainMenu.GetComponent<Button>();

        RestartButton.onClick.AddListener(RestartGame);
        //QuitButton.onClick.AddListener(QuitGame);
        MainMenu.onClick.AddListener(MainMenuL);

        Button Marcio = marcio.GetComponent<Button>();
        Button Gonçalo = gonçalo.GetComponent<Button>();
        Button AlexandreSilva = alexandreSilva.GetComponent<Button>();
        Button PedroRibeiro = pedroRibeiro.GetComponent<Button>();
        Button PedroGomes = pedroGomes.GetComponent<Button>();
        Button Diogo = diogo.GetComponent<Button>();
        Button Carlos = carlos.GetComponent<Button>();
        Button LuisMachado = luisMachado.GetComponent<Button>();
        Button AlexandreCastro = alexandreCastro.GetComponent<Button>();
        Button FernandoOliveira = fernandoOliveira.GetComponent<Button>();
        Button DanielRego = danielRego.GetComponent<Button>();
        Button BrunoFaria = brunoFaria.GetComponent<Button>();


        BrunoFaria.onClick.AddListener(BrunoOnClick);
        Marcio.onClick.AddListener(MarcioOnClick);
        Gonçalo.onClick.AddListener(GonçaloOnClick);
        AlexandreSilva.onClick.AddListener(AlexandreSilvaOnClick);
        PedroRibeiro.onClick.AddListener(PedroRibeiroOnClick);
        PedroGomes.onClick.AddListener(PedroGomesOnClick);
        Diogo.onClick.AddListener(DiogoOnClick);
        Carlos.onClick.AddListener(CarlosOnClick);
        LuisMachado.onClick.AddListener(LuísOnClick);
        AlexandreCastro.onClick.AddListener(AlexandreCastroOnClick);    

    }



    // Update is called once per frame
    void Update()
    {
        //Invoke("BrunoOff", 5);
        //Invoke("MarcioOff", 5);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenuL()
    {
        SceneManager.LoadScene("cena11MenuPrinc");
    }

    private void BrunoOnClick()
    {
        textoBrunoFaria.gameObject.SetActive(true);
    }
    private void DanielOnClick()
    {
        textoDanielRego.gameObject.SetActive(true);
    }
    private void FernandoOnClick()
    {
        textoFernandoOliveira.gameObject.SetActive(true);
    }
    private void AlexandreCastroOnClick()
    {
        textoAlexandreCastro.gameObject.SetActive(true);

    }
    private void LuísOnClick()
    {
        textoLuisMachado.gameObject.SetActive(true);
    }
    private void CarlosOnClick()
    {
        textoCarlos.gameObject.SetActive(true);
    }
    private void DiogoOnClick()
    {
        textDiogo.gameObject.SetActive(true);
    }
    private void PedroGomesOnClick()
    {
        textoPedroGomes.gameObject.SetActive(true);
    }

    private void PedroRibeiroOnClick()
    {
        textoPedroRibeiro.gameObject.SetActive(true);
    }
    private void AlexandreSilvaOnClick()
    {
        textoAlexandreSilva.gameObject.SetActive(true);
    }
    private void GonçaloOnClick()
    {
        textgonçalo.gameObject.SetActive(true);
    }
    private void MarcioOnClick()
    {
        textoMarcio.gameObject.SetActive(true);
    }
    private void MarcioOff()
    {
        textoMarcio.gameObject.SetActive(false);
    }
}