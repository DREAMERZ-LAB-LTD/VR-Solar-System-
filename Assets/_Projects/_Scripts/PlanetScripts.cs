using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;
public class PlanetScripts : MonoBehaviour
{
    [SerializeField] public Solar _solar;
    [SerializeField] public TextMeshProUGUI _title;
    [SerializeField] public RotateAround targetObject;
    [SerializeField] public bool isGrabe = false;
    [SerializeField] Transform targetTransform;

    public bool isStay = false;
    
    public InfoPanel _infoPanel;

   

    Vector3 _startRotation;
    Vector3 _localScale;
    private void Awake()
    {

        targetTransform = targetObject.transform;
        _startRotation = transform.localEulerAngles;
        _localScale = transform.localScale;
        targetTransform = transform.parent;
        transform.parent.gameObject.name = this._solar.ToString();
        if (_title != null) _title.text = this._solar.ToString();
    
    }
    void Start(){

        if(targetObject !=null)
        {
            targetObject.speed = SolarController.instance.SetOrbitalSpeed(_solar);
        }
    }
    public void OnGrabed()
    {
        if (!isGrabe)
        { 
            isGrabe = true;
            transform.SetParent(null);
            if (_title != null) _title.transform.parent.gameObject.SetActive(false);
        }
    }

    public void ReleseGrabe()
    {
        if(isGrabe)
        {
            isGrabe = false;
            // Invoke("WaitForReset", 0.1f);
            WaitForReset();
        }
    }



    private void WaitForReset()
    {
        CancelInvoke("WaitForReset");
        if (isStay && _infoPanel != null)
        {
            MoveToTargetPosition(_infoPanel._iteamPosition);
            Debug.Log("Move to UI Pose ");
            SolarController.instance.OnEventCall(_solar);
            if (_title != null) _title.transform.parent.gameObject.SetActive(false);

        }
        else
        {
          
            MoveToTargetPosition(targetObject.transform);
            if (_title != null) _title.transform.parent.gameObject.SetActive(true);

        }
    }
    public void MoveToTargetPosition(Transform _target)
    {
        transform.SetParent(_target);
        transform.DOScale(_localScale,0.3f);
        transform.DOLocalRotate(_startRotation,0.3f);
        transform.DOLocalMove(Vector3.zero, 0.3f).OnComplete(() => {
            transform.DOKill();
            transform.localEulerAngles = _startRotation;
            transform.localScale = _localScale;
        });
    }

 

}
