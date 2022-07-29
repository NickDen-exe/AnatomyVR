using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] private int defaultLength = 50;
    private LineRenderer lineRenderer = null;

    private GameObject hittedObject;
    private RaycastHit hit;

    public GameObject GetHittedObject()
    {
        return hittedObject;
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit;
        hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if (hit.collider)
        {
            endPosition = hit.point;
            hittedObject = hit.collider.gameObject;
        }
        else
            hittedObject = null;
        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);
        return hit;  
    }

    private Vector3 DefaultEnd(int length)
    {
        return transform.position + (transform.forward * length);
    }
}
