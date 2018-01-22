using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour {

    public float offset = 1.0f;
    private Collider2D _collider;
    private Vector3
        bottomCorner,
        topCorner;
    private float
        colliderHeight,
        colliderWidth;
	void Start () {
        _collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        calculateWidthAndHeigth();
        calculateRayOrigin();
        horizontalPosition();
        verticalPosition();
	}

    private void calculateRayOrigin() {

        var size = new Vector3(_collider.bounds.size.x * Mathf.Abs(transform.localScale.x), _collider.bounds.size.y * Mathf.Abs(transform.localScale.y), 0f) / 2;
        var center = new Vector3(_collider.offset.x * transform.localScale.x, _collider.offset.y * transform.localScale.y, 0f);

        bottomCorner = new Vector3(center.x + size.x, center.y - size.y, center.z);
        topCorner = new Vector3(center.x, center.y + size.y, center.z);

    }
    //casts eight rays starting in top corner
    /*
     * TODO:
     * add movement
     * add correction if moving to left
     */
    private void horizontalPosition() {

        var verticalDistanceBetweenRays = colliderHeight / 7;

        for (int i = 0; i < 8; i++) {
            var rayVector = new Vector3(topCorner.x + offset, topCorner.y - (i * verticalDistanceBetweenRays), topCorner.z);
            Debug.DrawRay(rayVector, transform.right, Color.red);
        }


    }
    /*
     * TODO:
     * add jumping
     * handle collision from above
     */
    
    private void verticalPosition() {
        var horizontalDistanceBetweenRays = colliderWidth / 3;

        for (int i = 0; i < 4; i++) {
            var rayVector = new Vector3(bottomCorner.x - (i * horizontalDistanceBetweenRays), bottomCorner.y, bottomCorner.z);
            Debug.DrawRay(rayVector, -transform.up, Color.green);
        }
    }

    private void calculateWidthAndHeigth() {
        colliderWidth = _collider.bounds.size.x * Mathf.Abs(transform.localScale.x);
        colliderHeight = _collider.bounds.size.y * Mathf.Abs(transform.localScale.y);
    }
}
