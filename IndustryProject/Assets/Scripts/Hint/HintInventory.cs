using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Photon.Pun;

public class HintInventory : MonoBehaviourPunCallbacks
{
   
    private string text;   
    private List<Hint> hints = new List<Hint>();
 

    public void AddHint(Hint hint){
        if (!hints.Contains(hint))
        {
            hints.Add(hint);
            Debug.Log("Added hint");
        }     
    
    }
    
    public List<Hint> Hints { get => hints; }

}
