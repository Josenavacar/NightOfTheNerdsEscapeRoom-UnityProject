using UnityEngine;

public class SignalRange : MonoBehaviour {
    public bool boostingSignal;
    public bool receivingSignal;
    public Material enabledMaterial;
    public Material disabledMaterial;

    private MeshRenderer currentMaterial;

    void Start() {
        boostingSignal = true;
        currentMaterial = GetComponent<MeshRenderer>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "JammerArea") {
            boostingSignal = false;
            currentMaterial.material = disabledMaterial;
        }
        if(other.gameObject.tag == "BoosterArea") {
            if(other.gameObject.GetComponent<SignalRange>().receivingSignal == true) {
                receivingSignal = true;
                Debug.Log("Getting signal.");
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "JammerArea") {
            boostingSignal = true;
            currentMaterial.material = enabledMaterial;
        }
        if (other.gameObject.tag == "BoosterArea") {
            receivingSignal = false;
            Debug.Log("Signal disconnected.");
        }
    }
}