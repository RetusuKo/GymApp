using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    private Image _image;
    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }
    public void ChangeObjectColorToGreen()
    {
        if (_image.color != Color.green)
        {
            _toggle.isOn = true;
            _image.color = Color.green;
        }
        else
        {
            _toggle.isOn = false;
            _image.color = Color.white;
        }
    }
    public void ChangeObjectColorToWhite()
    {
        _toggle.isOn = false;
        _image.color = Color.white;
    }
}
