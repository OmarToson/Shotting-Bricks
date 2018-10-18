using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float lifeTime;

    //we want if the hazard touch the player --> the player and hazer will die
    void Start()
    {
        Destroy(gameObject , lifeTime);
    }
}
//explosion --> first and second and third explosion  --> add component --> script --> choose DestroyByTime    //to destroy when the explosion happend
//make life time 2
