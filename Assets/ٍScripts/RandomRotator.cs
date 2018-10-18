using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;   //5 كل ما تزود هيلف اسرع
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;	 //angular velocity is how fast the rigidbody object is rotating   //فى كل مرة هنرن فيها الطوب هيلف فى اتجاهات مختلفة عن الى قبلها
	}
	
}
