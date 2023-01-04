using UnityEngine;

public class GridController : MonoBehaviour
{
    private static GridController _instance;

    public static GridController Instance => _instance;

    private Building[,] _grid;

    public Building[,] Grid
    {
        get => _grid;
        set => _grid = value;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }
}
