using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OreTypes { Gold, Copper}

public class Ore : MonoBehaviour {
    [SerializeField] OreTypes oreType;

    public void Interact() {
        Debug.Log("Interacting with: " + oreType.ToString());
    }
}
