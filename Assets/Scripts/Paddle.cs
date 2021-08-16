using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleMin = 1;
    [SerializeField] float paddleMax = 15;


    void Start()
    {
        Vector2 paddlePosition = new Vector2(8f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
       
        Vector2 paddlePosition = new Vector2(transform.position.x,transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, paddleMin, paddleMax);
        transform.position = paddlePosition;
    }
}
