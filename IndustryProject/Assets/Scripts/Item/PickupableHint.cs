using Photon.Pun;
using UnityEngine;

public class PickupableHint : PickUpable
{
    [SerializeField] private PlayersInRoomManager playersInRoomManager;
    [SerializeField] private Material pickedUpHintMaterial;
    [SerializeField] private Material pickedUpHintMaterialMainFrame;

    private Hint hint;  
    
    private void Start()
    {
        base.Start();
        hint = GetComponent<Hint>();               
    }
    public override void HandleAction(Transform transformPlayer)
    {
        CheckWhoGetsTheHint(transformPlayer);
    }

    private void CheckWhoGetsTheHint(Transform transformPlayer)
    {      
        if (hint.Data.Classes.Contains(EnumPlayerClasses.EVERYONE))
        {
            SendHintToEveryone(transformPlayer);
        }
        else if (hint.Data.Classes.Contains(transformPlayer.GetComponent<PlayerClass>().CurrentPlayerClass)){
            SendHintToCharacterAlone(transformPlayer);
        }
        
    }

    private void ChangeHintColor(int hintNumber)
    {
        Hint hint = GetComponentInParent<CodeLockHintManager>().getHintByHintNumber(hintNumber);
       
        foreach(Renderer renderer in hint.GetComponentsInChildren<Renderer>())
        {
            renderer.material = pickedUpHintMaterial;
        }     
        hint.GetComponent<Renderer>().material = pickedUpHintMaterialMainFrame;

    }

    private void SendHintToEveryone(Transform transform)
    {          
        PV.RPC("RPCSendHintToEveryone", RpcTarget.All, hint.HintNumber);                 
       
    }
    [PunRPC]
    private void RPCSendHintToEveryone(int hintNumber)
    {
        foreach (Transform transformPlayer in playersInRoomManager.PlayerTransforms)
        {
            transformPlayer.GetComponentInChildren<HintInventory>().AddHint(HintManager.instance.getHintByHintNumber(hintNumber));
        }
        
        ChangeHintColor(hintNumber);
    }

    private void SendHintToCharacterAlone(Transform transformPlayer)
    {
        transformPlayer.GetComponentInChildren<HintInventory>().AddHint(hint);
    }

}
