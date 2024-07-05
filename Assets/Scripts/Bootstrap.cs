using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WebManager _webManager;
    [SerializeField] private DataParser _dataParser;

    private void Awake()
    {
        _webManager.Initialize();
        _dataParser.Initialize(_webManager.Data);
    }
}
