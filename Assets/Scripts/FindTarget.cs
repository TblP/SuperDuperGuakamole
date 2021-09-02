using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FindTarget : MonoBehaviour
{
    
    public Transform target;
    public List<Collider> _currentTriggers { get; } = new List<Collider>();
    private Dictionary<Collider, bool> _triggerStates = new Dictionary<Collider, bool>();
    private bool _on = true;
    public float distance = 1000;
    public float distance2;
    public int tragerPos;
    public float horizontalInput;
    public float verticalInput;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
        distance = 1000;
       //поиск ближайшего противника из списка
       for ( int i = 0; i < _currentTriggers.Count; i++)
        {
            distance2 = Vector3.Distance(_currentTriggers[i].gameObject.transform.position, transform.position);
            if (distance > distance2)
            {
                distance = distance2;
                tragerPos = i;
                
            }
                
        }
        //наводка на боижайшего противника
   
        target = _currentTriggers[tragerPos].gameObject.transform;
       if(verticalInput == 0 && horizontalInput == 0)
        {
            transform.LookAt(target);
        }
       
        
    }
    private void FixedUpdate()
    {
        for (var i = 0; i < _currentTriggers.Count; i++)
        {
            var trigger = _currentTriggers[i];
            // If the trigger is no more, for whatever reason, remove it.
            if (!trigger)
            {
                _triggerStates.Remove(trigger);
                _currentTriggers.Remove(trigger);
                continue;
            }

            // If _currentTriggers has a collider which _triggerStates doesn't have, something
            // weird has happened (it should not be possible), so default to scrapping it.
            // It'll get added again next FixedUpdate if it is still OnTriggerStay'ing.
            if (!_triggerStates.ContainsKey(trigger))
            {
                _currentTriggers.Remove(trigger);
            }
            else
            {
                // This is the exciting part. FixedUpdate runs before the OnTrigger***, so we can
                // check here what the results are after the last OnTrigger*** calls came in.
                // They all set the state to "true" when adding or stay'ing a trigger, so if its
                // state is false here, then it is no longer stay'ing, and OnTriggerExit has not
                // been called to remove it, so we do it here.
                if (!_triggerStates[trigger])
                {
                    _triggerStates.Remove(trigger);
                    _currentTriggers.Remove(trigger);
                }
                else
                {
                    // Reset state to "false", so the coming OnTrigger*** calls can update them again.
                    _triggerStates[trigger] = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the object is not already in the list
        if (!_triggerStates.ContainsKey(other) && other.gameObject.CompareTag("Enemy"))
        {
            //add the object to the list
            _triggerStates.Add(other, true);
            _currentTriggers.Add(other);
        }
    }

    // Called every FixedUpdate between OnTriggerEnter and OnTriggerExit (or until the trigger is
    // disabled, in which case OnTriggerExit is not called, which is why we're doing all of this ;) ).
    private void OnTriggerStay(Collider other)
    {
        if (!_triggerStates.ContainsKey(other) && other.gameObject.CompareTag("Enemy"))
        {
            //add the object to the list
            _triggerStates.Add(other, true);
            _currentTriggers.Add(other);
        }
        else
        {
            _triggerStates[other] = true;
        }
    }

    // Called when a trigger exits.
    private void OnTriggerExit(Collider other)
    {
        _triggerStates.Remove(other);
        _currentTriggers.Remove(other);
    }

    public void ResetRegisteredTriggers()
    {
        _currentTriggers.Clear();
        _triggerStates.Clear();
    }

    public void Toggle(bool on, bool resetCurrentTriggers = true)
    {
        _on = on;
        if (resetCurrentTriggers)
            ResetRegisteredTriggers();
    }
}
