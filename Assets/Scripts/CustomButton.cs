using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover Start");
        // �������� ���� ������ ��� Hover ���������
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover End");
        // �������� ���� ������ ��� ��������� Hover
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button Pressed");
        animator.SetTrigger("press");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Released");
        animator.SetTrigger("unpress");

        // �������� ���� ������ ��� ���������� ������
    }
}
