using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float pitch;

    [SerializeField] private EnumAudioName  audioName;

    [SerializeField] private bool randomPitch;
    public EnumAudioName GetAudioName() { return audioName; }

    public void Activate(){
        if(audioClip == null){
            PlaySoundArray(audioClips);
        }
        else{
            PlaySound(audioClip);
        }
    }

    private void PlaySoundArray(AudioClip[] audioClips){
        int n = Random.Range(1, audioClips.Length);
        audioSource.clip = audioClips[n];
        audioSource.pitch = pitch;
        audioSource.Play(0);
        if(randomPitch){
            pitch = Random.Range(0.5f, 1.5f);
        }
        audioClips[n] = audioClips[0];
        audioClips[0] = audioSource.clip;
    }

    private void PlaySound(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.pitch = pitch;
		audioSource.Play(0);
        if(randomPitch){
            pitch = Random.Range(0.5f, 1.5f);
        }
    }
}