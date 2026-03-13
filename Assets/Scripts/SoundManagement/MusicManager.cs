using UnityEngine;
using Unity.Collections;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
    public static MusicManager Instance;
    [SerializeField]
    private MusicLibrary musicLibrary;
    [SerializeField]
    private AudioSource musicSource;

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayMusic(string trackname, float fadeDuration = 0.5f)
    {
        StartCoroutine(AnimateMusicCrossfade(musicLibrary.GetTrackFromName(trackname), fadeDuration));
    }
    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        float percent = 0;
        while(percent < 1)
        {
            percent += Time.deltaTime * (1 / fadeDuration);
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
        musicSource.clip = nextTrack;
        musicSource.Play();
        percent = 0;
        while(percent < 1)
        {
            percent += Time.deltaTime * (1 / fadeDuration);
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
    }
}
