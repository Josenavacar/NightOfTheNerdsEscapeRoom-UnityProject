using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSetupManager : MonoBehaviour
{

    [SerializeField] private AudioMixerSnapshot snapshot;

    void Start()
    {
        snapshot.TransitionTo(0f);
    }
}
