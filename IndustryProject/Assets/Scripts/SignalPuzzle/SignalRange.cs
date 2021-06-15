﻿using System.Collections;
using System.Collections.Generic;
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
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "JammerArea") {
            boostingSignal = true;
            currentMaterial.material = enabledMaterial;
        }
    }
}