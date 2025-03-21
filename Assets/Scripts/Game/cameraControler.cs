using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    public static cameraControler instance;

    private Transform _target;

    [SerializeField] private float _smooth = 2.00001f;
    private Vector3 _velocity;

    [SerializeField] private Vector3 _offset = new Vector3(0f, 5.01f, -4f);

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        Work();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Work()
    {
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _velocity, _smooth);
        transform.position = newPosition;
    }
    // а я иван

    //круто 
    /* скажи мне дядя
     * ведь не даром
     * москва спаленая пожаром
     * французу отдана
     * ведь были схватки боевые
     * да говорят еще какие
     * ведь не даром помнит вся Россия 
     * про день Бородина
     */
}
