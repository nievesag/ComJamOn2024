using UnityEngine;

public class UIManager : MonoBehaviour
{
    // References
    [SerializeField] // sigue el orden de los estados del gamemanager
    public GameObject[] menus;

    // Properties
    private GameManager.GameStates _activeMenu;

    #region ON CLICKS
    /// <param name="state"></param>
    public void RequestStateChange(GameManager.GameStates state)
    {
        if (GameManager.Instance != null)
            GameManager.Instance.requestSateChange(state);
    }

    /// Metodo para el onClick de los botones, para pasar al juego
    public void GoToGame()
    {
        RequestStateChange(GameManager.GameStates.GAME); // referenciando al gamemanager (importante! si no no cambia de estado)
        //...
    }

    // Metodo para pasar de pagina
    public void TurnPage()
    {
        if (GameManager.Instance != null)
        {
            // cambia de p�ginas
            GameManager.Instance.NextPage();
            Debug.Log(GameManager.Instance.CurrentPage);
        }
    }

    public void ErasePage()
    { // ESTO ES UNA PUTA MIERDA XD 
        if (GameManager.Instance != null && GameManager.Instance.Input != null)
        {
            if (GameManager.Instance.Input.DrawingComponent != null)
            {
                GameManager.Instance.Input.DrawingComponent.EraseDrawing();
            }
        }
    }

    /// Metodo para el onClick de los botones, para pasar al final del juego
    public void GoToEnding()
    {
        RequestStateChange(GameManager.GameStates.END); // referenciando al gamemanager (importante! si no no cambia de estado)
        //...
    }

    /// Metodo para el onClick de los botones, para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion

    public void SetMenu(GameManager.GameStates newMenu)
    {
        menus[(int)_activeMenu].SetActive(false);
        _activeMenu = newMenu;
        menus[(int)_activeMenu].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.RegisterUIManager(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
