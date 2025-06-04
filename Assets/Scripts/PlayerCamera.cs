using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = transform.position;
    }
}
