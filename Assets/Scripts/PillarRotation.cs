using UnityEngine;

public class PillarRotation : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(
            new Vector3(0,-150f * Input.GetAxis("Mouse X")*Time.deltaTime,0),
            Space.Self);
    }
}
