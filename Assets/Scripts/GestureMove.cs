using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GestureMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action BeginDrag;
    public event Action EndDrag;
    public event Action ReturnOnDefaultPos;
    public event Action HitTarget;

    [SerializeField] private Image _gestureTarget;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _minDistanceOnDefaultPos = 0.01f;
    [SerializeField] private float _minDistanceOnTarget = 251f;

    private RectTransform _rectTransform;
    private Vector3 _positionDefault;
    private Vector3 _positionTarget;
    private float _minPositionY;
    private float _maxPositionY;
    private bool _isMove;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        _positionDefault = transform.position;
        _minPositionY = _positionDefault.y;

        _positionTarget = _gestureTarget.transform.position;
        _maxPositionY = _positionTarget.y;
    }

    private void Update()
    {
        if (_isMove)
        {
            MoveGestureBack();

            if (IsGestureBack())
            {
                _isMove = false;
                ReturnOnDefaultPos?.Invoke();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isMove = false;
        BeginDrag?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Получаем текущую позицию объекта
        Vector2 currentPosition = _rectTransform.position;

        // Получаем новую позицию курсора мыши
        Vector2 newPosition = Input.mousePosition;

        // Ограничиваем перемещение по оси Y в пределах от -10 до 10 относительно начальной позиции
        float clampedY = Mathf.Clamp(newPosition.y, _minPositionY, _maxPositionY);

        // Обновляем позицию объекта, оставляя X координату без изменений
        _rectTransform.position = new Vector2(currentPosition.x, clampedY);

        if (IsGesdtureOnTarget())
            HitTarget?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isMove = true;
        EndDrag?.Invoke();
    }

    private void MoveGestureBack()
        => transform.position = Vector3.MoveTowards(transform.position, _positionDefault, _speedMove * Time.deltaTime);

    private bool IsGestureBack()
        => Vector3.Distance(transform.position, _positionDefault) <= _minDistanceOnDefaultPos;

    private bool IsGesdtureOnTarget()
        => Vector3.Distance(transform.position, _positionTarget) <= _minDistanceOnTarget;

}
