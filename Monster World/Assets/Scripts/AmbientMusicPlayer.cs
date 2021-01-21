using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientMusicPlayer : MonoBehaviour
{
    // Public \\
    [Header("Music")]
    public List<SongOptions> songs;

    [Header("Music Settings")]
    [Range(0.0f, 1.0f)]
    public float volume = 1;
    public float minSecsBetweenSongs = 120;
    public float maxSecsBetweenSongs = 300;

    // Private \\
    List<int> playedSongs = new List<int>();
    AudioSource source;

    bool fadeIn;
    float timeUntilPlay;
    int lastPlayed;
    float fadeInTime;

    // Classes \\
    [System.Serializable]
    public class SongOptions
    {
        [SerializeReference]
        public AudioClip song;

        [SerializeReference]
        public float fadeInSeconds;
    }

    static int ChooseSong(List<int> playedSongs, int songsList, int lastPlayed)
    {
        int x = Random.Range(0, songsList);

        while (playedSongs.Contains(x) || x == lastPlayed)
        {
            x = Random.Range(0, songsList);
        }

        return x;
    }

    void Start()
    {
        source = GetComponent<AudioSource>();

        lastPlayed = songs.Count + 1;

        timeUntilPlay = Random.Range(minSecsBetweenSongs, maxSecsBetweenSongs);
    }

    void Update()
    {
        // This check disables song playing if no songs are added ||| Prevent Logical error
        if(songs.Count > 0)
            PlayMusic();
        if(fadeIn)
            MusicFadeIn();
    }

    void PlayMusic()
    {
        int songNumber = 0;

        if(timeUntilPlay < Time.time && !source.isPlaying)
        {
            //This wipes the played list if it is the same length as the song list.
            if(playedSongs.Count == songs.Count)
                playedSongs.Clear();

            // This check disables song selection if no songs are added ||| Prevent Logical error
            if (songs.Count > 1)
                songNumber = ChooseSong(playedSongs, songs.Count, lastPlayed);

            //Assigns songs to prevent #1 same song being played #2 same song being played after list wipe
            playedSongs.Add(songNumber);
            lastPlayed = songNumber;

            //Handles time until next song
            if(songs[songNumber] != null)
            timeUntilPlay = Time.time + songs[songNumber].song.length + Random.Range(minSecsBetweenSongs, maxSecsBetweenSongs);

            // Handle Playing Music
            source.clip = songs[songNumber].song;
            source.Play();

            //Enable Music Fade in
            fadeInTime = songs[songNumber].fadeInSeconds;
            source.volume = 0;
            fadeIn = true;
        }
    }

    void MusicFadeIn()
    {
        if (source.volume < volume)
        {
            source.volume = Mathf.MoveTowards(source.volume, volume, (Time.deltaTime / fadeInTime) * volume);
        }
        else
        {
            fadeIn = false;
        }
    }
}
