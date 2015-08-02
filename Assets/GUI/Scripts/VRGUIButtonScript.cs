using UnityEngine;
using System.Collections;

public class VRGUIButtonScript : MonoBehaviour {
    
    public GameObject LeftObj;
    public GameObject RightObj;

    public bool IsBeingStaredAt;

    public GameObject AnimationControl;
    private GUIController _animScript;

    void Start()
    {
        _animScript = AnimationControl.GetComponent<GUIController>();
        OnStart();
    }

    public virtual void OnStart()
    {
        
    }

    void OnStare()
    {
        if (IsBeingStaredAt)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animScript.CloseCard();
                _animScript.MainActivate();
            }
        }
    }

    public void SetEnabled(bool isEnabled)
    {
        IsBeingStaredAt = isEnabled;
        LeftObj.SetActive(isEnabled);
        RightObj.SetActive(isEnabled);
    }
}
