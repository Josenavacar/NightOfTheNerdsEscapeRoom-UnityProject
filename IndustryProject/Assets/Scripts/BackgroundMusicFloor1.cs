using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicFloor1 : MonoBehaviour
{
    private void Start()
    {
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.BACKGROUNDMUSIC_FLOOR1);
    }
}
