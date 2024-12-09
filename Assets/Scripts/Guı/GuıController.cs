using UnityEngine;
using UnityEngine.SceneManagement;

public class GuıController : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject PlayButtonObject;
    [SerializeField] private GameObject OptionsButtonObject;
    [SerializeField] private GameObject ExitButtonObject;
    [SerializeField] private GameObject OptionsCanvas;
    public void PlayButton()
    {
        Animator playAnimator = PlayButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        SceneManager.LoadScene(SceneName);
    }
    public void OptionsButton()
    {
        Animator playAnimator = OptionsButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        OptionsCanvas.SetActive(true);
    }
    public void ExitButton()
    {
        Animator playAnimator = ExitButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        Application.Quit();
    }
}
