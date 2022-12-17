using UnityEngine;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour
{
    [SerializeField] private Health health;
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = health.GetPercentageOfCurrentHealth();
    }
}
