using Naninovel;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] markers;
    private ICustomVariableManager _variableManager;
    private RectTransform _mRectTransform;

    private void Start()
    {
        _variableManager = Engine.GetService<ICustomVariableManager>();
        _mRectTransform = GetComponent<RectTransform>();
    }

    public void SetMarker()
    {
        
        var target = int.Parse(_variableManager.GetVariableValue("CurrentTarget"));
        if(target==3)
            gameObject.SetActive(false);
        gameObject.transform.SetParent(markers[target].transform);
        _mRectTransform.anchoredPosition = Vector3.zero;
    }
}