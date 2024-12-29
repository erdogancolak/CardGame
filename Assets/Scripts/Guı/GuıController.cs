using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class GuıController : MonoBehaviour
{
    public static GuıController instance;
    [SerializeField] private string SceneName;
    [Space]
    [SerializeField] private GameObject PlayButtonObject;
    [SerializeField] private GameObject OptionsButtonObject;
    [SerializeField] private GameObject ExitButtonObject;
    [SerializeField] private GameObject CloseButtonObject;
    [SerializeField] private GameObject ApplyButtonObject;
    [SerializeField] private GameObject ResLeftButtonObject;
    [SerializeField] private GameObject ResRightButtonObject;
    [Space]
    [SerializeField] private GameObject OptionsCanvas;
    [Space]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle vsyncToggle;
    [Space]
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider MusicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;
    [Space]
    [SerializeField] private TMP_Text resolutionsText;
    [SerializeField] private ResItem[] resolutions;
    private int selectedResolutions;
    [Space]
    [SerializeField] private GameObject DeckControllCanvas;
    [Space]
    [SerializeField] private GameObject DeckErrorText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        selectedResolutions = 0;
        UpdateResolutionText();
    }
    public void PlayButton()
    {
        if(DeckControllCanvas.GetComponent<DeckMakerController>().isApply)
        {
            Animator playAnimator = PlayButtonObject.GetComponent<Animator>();
            playAnimator.SetTrigger("Clicked");
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            DeckErrorText.SetActive(true);
            StartCoroutine(deckErrorIE());
        }
    }
    IEnumerator deckErrorIE()
    {
        yield return new WaitForSeconds(2f);
        DeckErrorText.SetActive(false);
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
    public void CloseButton()
    {
        OptionsCanvas.SetActive(false);
        DeckControllCanvas.SetActive(false);
    }
    public void ApplyButton()
    {
        Animator playAnimator = ApplyButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        Screen.fullScreen = fullscreenToggle.isOn;

        if(vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectedResolutions].Horizontal, resolutions[selectedResolutions].Vertical, fullscreenToggle.isOn);
    }
    public void ResLeftButton()
    {
        Animator playAnimator = ResLeftButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        selectedResolutions--;
        if(selectedResolutions < 0)
        {
            selectedResolutions = 0;
        }
        UpdateResolutionText();
    }
    public void ResRightButton()
    {
        Animator playAnimator = ResRightButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        selectedResolutions++;
        if (selectedResolutions > resolutions.Length - 1)
        {
            selectedResolutions = resolutions.Length - 1;
        }
        UpdateResolutionText();
    }
    public void UpdateResolutionText()
    {
        resolutionsText.text = resolutions[selectedResolutions].Horizontal.ToString() + " X " +  resolutions[selectedResolutions].Vertical.ToString();
    }
    public void MusicVolumeSet()
    {
        Mixer.SetFloat("MusicVol", MusicVolumeSlider.value);
    }

    public void DeckControlButton()
    {
        Animator playAnimator = PlayButtonObject.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        DeckControllCanvas.SetActive(true);
    }
}
[System.Serializable]
public class ResItem
{
    public int Horizontal;
    public int Vertical;
}
