using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct MusicTrack
    {
        public string songName;
        public AudioClip clip;
    }
public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] songs;
    
    public AudioClip GetClipFromName(string songName)
    {
        foreach (var song in songs)
        {
            if(song.songName == songName)
            {
                return song.clip;
            }
        }
        return null;
    }
}
