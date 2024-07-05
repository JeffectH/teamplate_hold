using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gesture : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Image _image;


    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �������� ������� ������� �������
        Vector2 currentPosition = _rectTransform.position;

        // �������� ����� ������� ������� ����
        Vector2 newPosition = Input.mousePosition;

        // ������������ ����������� �� ��� Y � �������� �� -10 �� 10 ������������ ��������� �������
        float clampedY = Mathf.Clamp(newPosition.y, 170, 1280);

        // ��������� ������� �������, �������� X ���������� ��� ���������
        _rectTransform.position = new Vector2(currentPosition.x, clampedY);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
