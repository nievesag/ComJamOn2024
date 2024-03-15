using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Parameters

    [SerializeField] private LineRenderer _line;

    #endregion

    #region References

    private DrawingComponent _drawingComponent;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (_line != null) _drawingComponent = _line.GetComponent<DrawingComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Al pulsar, se a�ade una l�nea
        if (Input.GetMouseButtonDown(0))
        {
            _drawingComponent.VariasLineas();
        }

        // CCAMBIAR ANTES DE COMMITEAR !!!!!!!

        /*//Cada vez que se pulsa, empieza o termina el trazo
        if (Input.GetMouseButton(0))
        {
            _drawingComponent.Paint(newPoint);
        }*/
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("boton derecho");
        }
        else if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("boton medio");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Borra eso");
            // Existe el script GameManager puesto.
            if (GameManager.Instance != null)
                GameManager.Instance.QuitaDedo();
            
        }
    }
}
