using UnityEngine;
[System.Serializable]
    public struct MusicTrack
    {
        public string trackName;
        public AudioClip audioClip;
    }
public class MusicLibrary:MonoBehaviour
{
    public MusicTrack[] tracks;

    public AudioClip GetTrackFromName(string name)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == name)
            {
                return track.audioClip;
            }
        }
        //Debug.LogWarning($"Track with name {name} not found in MusicLibrary.");
        return null;
    }

    //MUZYKA MA MIEC PRZYPISANA WARTOSC STREAMING!!!! bo jak nie to cpu wam umrze
}
