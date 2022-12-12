using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	public AudioClip music1;
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		
		if (Instance == null)
		{
			Instance = this;
		}
		
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
	}
    // Play a single clip through the sound effects source.

    private void Start()
    {
		PlayMusic(music1);
    }

    public void Play(AudioClip clip)
	{
		AudioSource tempAudioSource = Instantiate(EffectsSource);
		tempAudioSource.clip = clip;
		tempAudioSource.Play();
		Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		AudioSource tempAudioSource = Instantiate(MusicSource);
		tempAudioSource.clip = clip;
		tempAudioSource.Play();
		Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
	}
	// Play a random clip from an array, and randomize the pitch slightly.
	
}
