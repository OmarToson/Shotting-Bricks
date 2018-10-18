using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]     //because variables in class so it don't show in unity
public class Boundary
{
    public float xMin, xMax, zMin, zMax ;    //-7 , 7 , -4 , 8
}

public class PlayerController : MonoBehaviour {  //this mean that playercontroller inherit from monobehaviour
    //instance = object
    //public override void func1 (){} //this func in class inherit from other class

    //polymorphism
    // parentClass myclass = new childClass();
    //myclass.parentMethod();
    //if we want to call childMethod :
    //childClass mychild = (childClass)myclass;
    //mychild.childMethod();

    //Classes
    //public class stuff {}
    //public stuff mystuff = new stuff();  //taking object from class (default constructor)

    public Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;     //game object mean we can drag somthing from hirarchy and put it in this in script
    public Transform shotSpawn;  //transform not game object

    public float fireRate;   //how long we must wait between shots   //0.25
    public float nextFire;   //when in the game we can fire next shot  //امتا هيضرب لو عملنت 3 هيستنا 3 ثوانى بعدين يضرب انما 0 همش هيستنى حاجة

    //for audio
    AudioSource AS;

    void Update()
    {
        //edit-->project setting-->input (fire1 for left click mouse)
        //jump --> space     ,    submit --> enter
        //bool held = Input.GetButton("Jump");   ==========     bool held = Input.GetKey(KeyCode.Space);
        //Input.GetButton   or    Input.GetButtonUp    or     Input.GetButtonDown
        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > nextFire)  // if(he press key && time in the game > 0طول ما اللعبة شغالة )  
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);     //instantiate(object , position , rotation)  //to make bult in the same position of shotspawn
            AS = GetComponent<AudioSource>();
            AS.Play();    //to play audio
        }
    }

    void FixedUpdate()  //use in physics and rigidbody of the object
    {
        rb = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //to move up down right left
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //for don't go out the scene
        rb.position = new Vector3 (
            Mathf.Clamp(rb.position.x , boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        //to make player rotate while moving right and left
        rb.rotation = Quaternion.Euler(0.0f , 0.0f , rb.velocity.x * -tilt);
    }
}



