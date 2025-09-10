using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        // Pressing the 'S' key will start the game
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("Game Scene");
        }

        // Pressing the 'I" key will go to the game info and conrtoles screen
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Information Scene");
        }
    }
}
