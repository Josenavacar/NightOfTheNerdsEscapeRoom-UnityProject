using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalRange : MonoBehaviour {
    public bool boostingSignal;

    void Start() {
        boostingSignal = true;
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "") {
            boostingSignal = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "") {
            boostingSignal = true;
        }
    }
}