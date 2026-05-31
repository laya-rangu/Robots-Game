using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
 
public class IntroSceneManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI introText;
    public Image backgroundImage;
    
    [Header("Audio References")]
    public AudioSource audioSource;
    public AudioClip tutorialAudio;
    
    [Header("Settings")]
    public string mainSceneName = "MainScene";
    public float delayAfterAudio = 3f;
    
    void Start()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
        
        StartCoroutine(PlayIntroSequence());
    }
    
    IEnumerator PlayIntroSequence()
    {
        Debug.Log("Starting intro sequence...");
        
        if (introText != null)
            introText.gameObject.SetActive(true);
        
        if (audioSource != null && tutorialAudio != null)
        {
            audioSource.clip = tutorialAudio;
            audioSource.Play();
            Debug.Log("Playing audio");
        }
        
        float audioDuration = tutorialAudio != null ? tutorialAudio.length : 5f;
        yield return new WaitForSeconds(audioDuration);
        
        Debug.Log("Audio finished. Waiting " + delayAfterAudio + " seconds...");
        
        yield return new WaitForSeconds(delayAfterAudio);
        
        Debug.Log("Loading main scene: " + mainSceneName);
        SceneManager.LoadScene(mainSceneName);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Skipping intro...");
            SceneManager.LoadScene(mainSceneName);
        }
    }
}
