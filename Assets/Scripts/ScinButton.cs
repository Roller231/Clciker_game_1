using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScinButton : MonoBehaviour
{
    public bool isOpened;

    public int cost;

    public Text costText;
    public Image key;

    public Sprite iconToChange;

    private void Start()
    {
        costText.text = cost.ToString();
    }

    private void Update()
    {
        if (isOpened)
        {
            costText.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            GetComponent<Button>().interactable = true;
        }
    }
}
