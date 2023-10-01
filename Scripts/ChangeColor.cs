using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private Image _image;
    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }
    public void ChangeObjectColorToGreen()
    {
        if(_image.color != Color.green)
            _image.color = Color.green;
        else
            _image.color = Color.white;
    }
}
