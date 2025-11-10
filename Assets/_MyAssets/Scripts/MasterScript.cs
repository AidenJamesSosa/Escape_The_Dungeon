using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour
{
    private bool mHidemouse = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

    }
    void update()
    {
     if (mHidemouse == false)
     {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
     }
     else
     {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
     }
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void LoadLevel01()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        mHidemouse = true;
        SceneManager.LoadScene(1);
    }
}
