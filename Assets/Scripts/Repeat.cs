using UnityEngine;
using UnityEngine.SceneManagement;

public class Repeat : MonoBehaviour
{
    [SerializeField] private Animator _canvasGroup;

    public void Restart() 
    {
        _canvasGroup.SetTrigger("Hide");
        Invoke("RestartScene", 0.5f);
    }

    private void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
