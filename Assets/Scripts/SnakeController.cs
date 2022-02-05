using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    public List<Transform> segments;
    public Transform segmentPrefab;


    private void Awake()
    {
        Debug.Log("Snake controller awake");
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0f);

    }
    
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
    }
}
