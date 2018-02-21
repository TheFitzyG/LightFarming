using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class gridMovement : MonoBehaviour {
    private Direction currentDirection;
    private Vector2   input;
    private bool      isMoving = false;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float t;

    public float walkSpeed = 3f;

    public LayerMask wallLayer;

    public Sprite up, down, left, right;

    private SpriteRenderer spr;

    private Vector3    front;
    public  LayerMask  frontDetectMask;
    public  GameObject jarObject;


    // Use this for initialization
    void Start() {
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    bool checkCollision(Vector3 direction) {
        RaycastHit2D line;
        //LayerMask laya = LayerMask.NameToLayer("Wall");

        line = Physics2D.Linecast(transform.position, direction, wallLayer);
        Debug.DrawLine(transform.position, direction);

        //if (line.collider != null) {

        //Debug.Log (line.collider);

        //}

        return line;
    }


    private bool acceptLock = false;

    void tileDetect() {
        switch (currentDirection) {
            case (Direction.up):


                front = transform.position + Vector3.up;

                break;

            case(Direction.down):


                front = transform.position + Vector3.down;

                break;


            case(Direction.left):


                front = transform.position + Vector3.left;

                break;

            case(Direction.right):


                front = transform.position + Vector3.right;

                break;
        }


        RaycastHit2D line;

        line = Physics2D.Linecast(transform.position, front, frontDetectMask);
        Debug.DrawLine(transform.position, front);

        if (line && line.collider != null) {
            //Debug.Log (line.collider.gameObject.name);

            if (Input.GetAxis("Accept") > 0.2 && !acceptLock) {
                acceptLock = true;

                line.collider.gameObject.GetComponent<Interactable>().interact();

                //Destroy(line.collider.gameObject);
            }
        }

        if (!line) {
            if (Input.GetAxis("Accept") > 0.2 && !acceptLock) {
                acceptLock = true;

                switch (playerInventory.selectedItem) {

                    case(hotbar.jars) :

                        if (playerInventory.inventory["jars"] > 0) {
                            playerInventory.inventory["jars"]--;
                            GameObject newTile = Instantiate(jarObject, front, transform.rotation);
                            newTile.transform.SetParent(transform.parent);
                        }

                        break;
                    
                }
            }
        }


        if (Input.GetAxis("Accept") == 0 && acceptLock) {
            acceptLock = false;
        }
    }


    // Update is called once per frame
    void Update() {
        if (!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                input.y = 0;
            }
            else {
                input.x = 0;
            }


            if (input != Vector2.zero) {
                if (input.x < 0) {
                    currentDirection = Direction.left;
                }

                if (input.x > 0) {
                    currentDirection = Direction.right;
                }

                if (input.y < 0) {
                    currentDirection = Direction.down;
                }

                if (input.y > 0) {
                    currentDirection = Direction.up;
                }

                spr = GetComponentInChildren<SpriteRenderer>();

                switch (currentDirection) {
                    case (Direction.up):

                        spr.sprite = up;
                        //front = transform.position + Vector3.up;

                        break;

                    case(Direction.down):

                        spr.sprite = down;
                        //front = transform.position + Vector3.down;

                        break;


                    case(Direction.left):

                        spr.sprite = left;
                        //front = transform.position + Vector3.left;

                        break;

                    case(Direction.right):

                        spr.sprite = right;
                        //front = transform.position + Vector3.right;

                        break;
                }


                if (Mathf.Abs(input.x) > 0.3f || Mathf.Abs(input.y) > 0.3f) {
                    StartCoroutine(Move(transform));
                }
            }


            tileDetect();
        }
    }

    public IEnumerator Move(Transform entity) {
        isMoving = true;
        startPosition = entity.position;
        t = 0;


        endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x), startPosition.y + System.Math.Sign(input.y), startPosition.z);


        if (checkCollision(endPosition)) {
            Debug.Log("I see a wall");

            isMoving = false;
            t = 1f;

            //yield return null;
        }


        while (t < 1f) {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }


        isMoving = false;


        yield return 0;
    }
}

enum Direction {
    up,
    down,
    left,
    right
}