using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinexplosion : MonoBehaviour {

    private float ExplosionTime = 0.7f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ExplosionTime -= Time.deltaTime;
        if (ExplosionTime < 0) {
            Destroy(this.gameObject);
        }
    }
}
