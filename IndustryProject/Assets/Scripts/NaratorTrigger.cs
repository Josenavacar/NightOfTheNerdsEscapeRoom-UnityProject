using TMPro;
using UnityEngine;
using Photon.Pun;

public class NaratorTrigger : MonoBehaviour
{
    [SerializeField]
    private NaratorController naratorController;

    public void StartController()
    {
        naratorController.StartCoroutine();
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.HOLOGRAM_OPEN);
    }

    public void StopController()
    {
        naratorController.Stop();
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.HOLOGRAM_CLOSE);
    }

    public void OnTriggerEnter(Collider other)
    {
        PhotonView tempPhotonView = other.gameObject.GetComponent<PhotonView>();

        if (tempPhotonView != null)
        {
            if (tempPhotonView.IsMine)
            {
                StartController();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PhotonView tempPhotonView = other.gameObject.GetComponent<PhotonView>();

        if (tempPhotonView != null)
        {
            if (tempPhotonView.IsMine)
            {
                StopController();
            }
        }
    }
}
