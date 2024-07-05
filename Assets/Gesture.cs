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
        // Получаем текущую позицию объекта
        Vector2 currentPosition = _rectTransform.position;

        // Получаем новую позицию курсора мыши
        Vector2 newPosition = Input.mousePosition;

        // Ограничиваем перемещение по оси Y в пределах от -10 до 10 относительно начальной позиции
        float clampedY = Mathf.Clamp(newPosition.y, 170, 1280);

        // Обновляем позицию объекта, оставляя X координату без изменений
        _rectTransform.position = new Vector2(currentPosition.x, clampedY);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
