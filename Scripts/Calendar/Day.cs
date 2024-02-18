using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Day : MonoBehaviour
{
    private int _dayNumber;
    private Color _dayColor;
    private GameObject _dayObject;
    public Day(int dayNumber, Color dayColor, GameObject dayObject)
    {
        _dayNumber = dayNumber;
        _dayColor = dayColor;
        _dayObject = dayObject;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        _dayObject.GetComponent<Image>().color = _dayColor;
        UpdateDayText();
    }

    private void UpdateDayText()
    {
        if (_dayColor == Color.white || _dayColor == Color.green)
            _dayObject.GetComponentInChildren<TextMeshProUGUI>().text = (_dayNumber + 1).ToString();
        else
            _dayObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void UpdateColor(Color newColor)
    {
        _dayObject.GetComponent<Image>().color = newColor;
        _dayColor = newColor;
    }

    public void UpdateDay(int newDayNumber)
    {
        _dayNumber = newDayNumber;
        UpdateDayText();
    }
}