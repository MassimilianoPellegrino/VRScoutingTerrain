using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStar : MonoBehaviour
{
    
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickUpClip, dropClip;

    private bool dragging, placed;

    private Vector2 offset, originalPosition;
    private PuzzleSlot slot;

    public void Init(PuzzleSlot _slot)
    {
        slot = _slot;
    }

    void Awake()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if(placed) return;
        if(!dragging) return;

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition - offset;
    }
    void OnMouseDown()
    {
        dragging = true;
        source.PlayOneShot(pickUpClip);

        offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        if(Vector2.Distance(transform.position, slot.transform.position) < 3)
        {
            transform.position = slot.transform.position;
            slot.Placed();
            placed = true;
        } else {
          transform.position = originalPosition;
          source.PlayOneShot(dropClip);
          dragging = false;
        }      
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
