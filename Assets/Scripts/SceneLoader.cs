using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain(){
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OnApplicationQuit() {
        Application.Quit();
    }

    public void PVP(){
        SceneManager.LoadScene("PVP_Scene");
    }

    public void PVC(){
        SceneManager.LoadScene("PVC_Scene");
    }
}
