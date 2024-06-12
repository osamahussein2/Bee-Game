using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player_Movement_Controller : MonoBehaviour
{

    // Neede vectors 
    private Vector2 input;

    private Vector3 direction;
    private bool isMoving;

    private int gameWidth = 11; //How far (each direction) the game goes, in tiles. 
    public Vector3 worldPosition;


    // Start is called before the first frame update
    //void Start()
    //{
    //}

    // Update is called once per frame
    void Update()
    {   
        

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        input = new Vector2(inputX, inputY);

        // if(input.x == 0 && input.y == 0){ // Haven't moved yet
        //     hasMoved = false;
        // }

        if((input.x != 0 || input.y != 0) ){

            if(!isMoving){
            StartCoroutine(GetMovementDirection());
            }
        }
    }
    private IEnumerator GetMovementDirection(){
        isMoving = true;


        Vector3 worldPosition = transform.position;

        double diffToWhole = Math.Abs(worldPosition.x - Math.Round(worldPosition.x));
        double diffToHalf = Math.Abs(.5 - (worldPosition.x - Math.Floor(worldPosition.x)));
        
        if(input.x > 0){ //Going right. . .
            direction = new Vector3(1f, 0, 0);
        }

        else if(input.x < 0){ //Going left. . .
            direction = new Vector3(-1f, 0, 0);
        }


        else if(input.y > 0){ //Going up! . . .
        //Need to check which way we will go up. . .

        if (diffToHalf < diffToWhole){ //Go right and up
            direction = new Vector3(0.5f, .75f);
        }
        else{ //Go left and down
            direction = new Vector3(-0.5f, .75f);
        }
        }


        else if(input.y < 0){ //Going Down! . . .
        //Need to check which way we will go up. . .

        if (diffToHalf < diffToWhole){ //Go right and down
            direction = new Vector3(0.5f, -.75f);
        }
        else{ //Go left and down
            direction = new Vector3(-0.5f, -.75f);
        }
        }

        if(worldPosition.x + direction.x < gameWidth && worldPosition.x + direction.x >= (gameWidth * -1) ){ //Move if it wont take us out of bounds
            
        if(worldPosition.y + direction.y < 3.5 && worldPosition.y + direction.y > -3){ //Move if it wont take us out of bounds

            transform.position += direction;
            }
            }

        CheckCameraMovement(transform.position + direction); //Check if the camera needs to move
        
        yield return new WaitForSeconds(.2f);
        isMoving = false;
        }

    public void CheckCameraMovement(Vector3 currentPlayerPosition){
        Camera mainCamera = Camera.main; //Grab main camera
        Vector3 cameraMovement; //3d vector for camera movement. May be left null. . .
        Vector3 cameraPosition = mainCamera.transform.position;

        if(Math.Abs(cameraPosition.x+5 - currentPlayerPosition.x) < 1.5 ){ // When reaching right bounds of camera
            cameraMovement = new Vector3(1f, 0);

            if(cameraPosition.x + 5 < 20){
            mainCamera.transform.position += cameraMovement;
            }
        
        }
        else if(Math.Abs(cameraPosition.x-5 - currentPlayerPosition.x) < 2 && (currentPlayerPosition.x < cameraPosition.x)){ // When reaching left bounds of camera
            cameraMovement = new Vector3(-1f, 0);
            
            if(cameraPosition.x - 5 > -20){
            mainCamera.transform.position += cameraMovement;
            }
        }
        

    //     if(Math.Abs(cameraPosition.y+3.75 - currentPlayerPosition.y) < .25 ){ // When reaching top bounds of camera
    //         cameraMovement = new Vector3(0, .75f);

    //         mainCamera.transform.position += cameraMovement;
        
    //     }
    //     else if(Math.Abs(cameraPosition.y-3.75 - currentPlayerPosition.y) < 1 && (currentPlayerPosition.y < cameraPosition.y)){ // When reaching bottom bounds of camera
    //         cameraMovement = new Vector3(0, -.75f);
            
    //         mainCamera.transform.position += cameraMovement;
        
    // }
    }
        }



