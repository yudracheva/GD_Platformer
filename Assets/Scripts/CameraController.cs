using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float _minimumGround = -0.94f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        var position = player.transform.position + offset;
        var y = position.y < _minimumGround ? _minimumGround : position.y;
        transform.position = new Vector3(position.x, y, position.z);
    }
}
