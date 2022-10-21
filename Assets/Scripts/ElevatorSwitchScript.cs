using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSwitchScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elevator")]
    [SerializeField] GameObject _elevator;

    Vector3 _elevatorFirstPosition = new Vector3(3f, 27f, -49f);

    Vector3 _elevatorSecondPosition = new Vector3(3f, 21f, -49f);

    void Start()
    {
        _elevator.transform.position = _elevatorFirstPosition;
    }

    public void OnTriggerStay(Collider other)
    {
        if (
            other.GetComponent<FireElement>() != null || other.GetComponent<WaterElement>() != null
        )
        {
            _elevator.transform.position +=
                _elevator.transform.up * -(Time.deltaTime);

            if (_elevator.transform.position.y < _elevatorSecondPosition.y)
            {
                _elevator.transform.position = _elevatorSecondPosition;
            }
        }
    }
}
