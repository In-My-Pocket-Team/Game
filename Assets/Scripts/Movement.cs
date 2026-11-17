using System.Collections;using System.Collections.Generic;using TMPro;using UnityEngine;public class Movement : MonoBehaviour{
    //Input & Sequence Fields
    [SerializeField] private List<string> inputHistory = new List<string>();    private bool allow_input = true;    public int currentInputIndex = 0;
    public int allocatedmoves = 0;
    public int O_Route = 0;
    public int Leeway = 0;
    public int Square_N = 0;


    [SerializeField] TextMeshProUGUI inputQueue;
    private string originalQueueText;

    //Movement & Component Fields
    private Rigidbody rb;    private CapsuleCollider body;    private Vector3 direction = Vector3.forward;    private float movespeed = 5f;    

    //State Machine
    public enum State { right, up, down, left, idle }    [SerializeField] public State currentState = State.idle;    void Start()    {        rb = GetComponent<Rigidbody>();        body = GetComponent<CapsuleCollider>();        allocatedmoves = O_Route + Leeway + (Square_N / O_Route);    }    void Update()    {        if (allow_input == true)        {            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                inputHistory.Add("Up");
                originalQueueText = originalQueueText + "Up\n";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputHistory.Add("Right");
                originalQueueText = originalQueueText + "Right\n";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                inputHistory.Add("Down");
                originalQueueText = originalQueueText + "Down\n";
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputHistory.Add("Left");
                originalQueueText = originalQueueText + "Left\n";
            }        }        if (Input.GetKeyDown(KeyCode.Space) && allow_input == true)        {            allow_input = false;            ExecuteNextInput();        }        inputQueue.text = originalQueueText;    }    private void OnTriggerEnter(Collider other)    {        if (!allow_input && other.CompareTag("StateUpdate"))        {            ExecuteNextInput();        }    }    void FixedUpdate()    {        switch (currentState)        {
            // the players movements
            case State.right:                direction = Vector3.forward;                rb.linearVelocity = direction * movespeed;                break;            case State.up:
                direction = Vector3.left;                rb.linearVelocity = direction * movespeed;                break;            case State.down:
                direction = Vector3.right;                rb.linearVelocity = direction * movespeed;
                break;            case State.left:                direction = Vector3.back;                rb.linearVelocity = direction * movespeed;                break;            case State.idle:                rb.linearVelocity = Vector3.zero;                allow_input = true;                break;        }    }    public void ExecuteNextInput()    {        if (currentInputIndex < inputHistory.Count)        {            string currentAction = inputHistory[currentInputIndex];            Debug.Log($"Executing step {currentInputIndex + 1}: {currentAction}");            switch (currentAction)            {
                //update to the next state to preform the player movement.
                case "Up":                    currentState = State.up;                    break;                case "Down":                    currentState = State.down;                    break;                case "Right":                    currentState = State.right;                    break;                case "Left":                    currentState = State.left;                    break;                default:                    currentState = State.idle;                    break;            }            currentInputIndex++;        }        else        {            Debug.Log("All stored inputs have been successfully executed!");            currentState = State.idle;        }    }}