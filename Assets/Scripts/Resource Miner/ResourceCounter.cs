using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private int resources;
    [SerializeField] private TMP_Text recourcesText;

    private static ResourceCounter _instance;

    public static ResourceCounter Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ReceiveResources(int resourceCount)
    {
        resources += resourceCount;
        recourcesText.text = resources.ToString();
    }
}
