using UnityEngine;
using UnityEngine.EventSystems;

public class ImageController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(GetName(eventData.pointerClick.transform));
    }

    private string GetName(Transform trans)
    {
        return trans.gameObject.name;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _playerMovement.Move(0, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.delta;

        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y) )
        {
            _playerMovement.Move(eventData.delta.x, false);
        }
    }
}
