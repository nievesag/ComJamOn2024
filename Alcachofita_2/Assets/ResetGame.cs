using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("COOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOJONES");
    }
}
