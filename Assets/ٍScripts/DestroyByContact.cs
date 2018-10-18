using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;   //to make explosion on bult

    public GameObject playerExplosion;  //to make explosion when the player touch astroid

    public int scoreValue;     // for score after hitting astroid    //10
    private GameController gameController;   //take object from class  //private for no access it from inspector

    //for score
    //when i drag GameController and drop it in script in inspector it can't --> sol : 
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    //we want to destroy the asteroid when the bolt first touches it
    private void OnTriggerEnter(Collider other)
    {
        //to show the game object that the other is attache to --> and we ask to destroy it then it destroy boundry not bult additionall destroing asteroid
        //Debug.Log(other.name);  //befor making tag and befor writing if statement //show boundary down 
        //it remove boundary because the astroid at the middle of boundary then it touch it then it destroid with astroit befor we shot the bult
        //sol : make the boundary tag named --> boundary and write this :
        if (other.tag == "boundary")
        {
            return;     //don't care of boundary
        }

        Instantiate(explosion,transform.position,transform.rotation);  //to make explosion at the same position of astroid 

        if (other.tag == "Player")  //then we go to make player tag on player 
        {
            Instantiate(explosion, transform.position, transform.rotation);  //to make explosion at the same position of other(player) 

            gameController.GameOver();   //call function to game over after player explosion
        }

        gameController.AddScore(scoreValue);   //call function to add score 

        Destroy(other.gameObject);    //to destroy bult
        Destroy(gameObject);    //to destroy asteroid

    }

}

//drag mover script and drop it in astroid and make speed -5 to make astroid drop down