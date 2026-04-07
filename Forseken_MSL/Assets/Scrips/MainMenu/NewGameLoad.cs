using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameLoad : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
