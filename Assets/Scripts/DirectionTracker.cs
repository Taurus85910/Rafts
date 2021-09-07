using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectionTracker : MonoBehaviour, IPointerDownHandler,IDragHandler, IPointerUpHandler
{
    private Vector3 _directionStart; 
    private Vector3 _directionEnd;
    private Vector3 _direction;
    
    public Vector3 GetDirection() => _direction;
        
    public void OnPointerDown(PointerEventData eventData)
    {
        _directionStart = eventData.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _directionEnd = eventData.position;
        _direction = new Vector3(_directionEnd.x - _directionStart.x, 0, _directionEnd.y - _directionStart.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = new Vector3(0,0, 0);
    }

}
