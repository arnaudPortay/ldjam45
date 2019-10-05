using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject blackImage;

    public void StartGame()
    {
        blackImage.SetActive(true);       
        SceneManager.LoadScene(1);
    }
}
