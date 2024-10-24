using SharpNeat.Phenomes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySharpNEAT;
using UnityEngine.SceneManagement;

public class AIControler : UnitController
{
    private Vector3 _initialPosition = default;
    private Quaternion _initialRotation;
    public float SensorRange = 4;
    public float movevelo = 5;
    private Vector3 velocity;
    private Vector3 pos;
    private int score;
    private int id;

    private Jump ai;
    private spawnplatform respawn;

    private static int idCounter = 0;
    public int uniqueID;

    void Awake()
    {
        // Assign a unique ID to this instance
        uniqueID = ++idCounter;
    }
    
    

    
    
    private void Start()
        {
            // cache the inital transform of this Unit, so that when the Unit gets reset, it gets put into its initial state
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
            ai = GetComponent<Jump>();
            respawn = GameObject.FindWithTag("Respawn").GetComponent<spawnplatform>();

            
        }
    protected override void UpdateBlackBoxInputs(ISignalArray inputSignalArray)
    {
        // Called by the base class on FixedUpdate
        float upSensor = 0;
        float leftupSensor = 0;
        float leftSensor = 0;
        float rightupSensor = 0;
        float rightSensor = 0;
        float downSensor = 0;

        // Feed inputs into the Neural Net (IBlackBox) by modifying its InputSignalArray
        // The size of the input array corresponds to NeatSupervisor.NetworkInputCount
        RaycastHit hit;
        
        RaycastHit2D hit2;

        Vector3 origin = transform.position+transform.up * 1.1f ;
        origin.z = 0;  // Force the z-position of the origin to 0, though irrelevant in 2D

        // Set the direction as upwards in local space (along the y-axis)
        Vector2 directionup = Vector2.up;
        Vector2 directionupright =new Vector2(1, -1);
        Vector2 directionupleft = new Vector2(-1, 1);
        Vector2 directiondown = Vector2.down;
        Vector2 directionright =Vector2.right;
        Vector2 directionleft =Vector2.left;


        // Draw the ray for visualization (green line)
        Debug.DrawLine(origin, origin + (Vector3)directiondown * SensorRange, Color.green);

        // Perform a 2D raycast and log the hit information
        hit2 = Physics2D.Raycast(origin, directionup,SensorRange);
        if (hit2){
            //Debug.Log("hit "+hit2.collider.tag);
        if (hit2.collider.CompareTag("platform"))
        {
            upSensor = 1 - hit2.distance / SensorRange;
            //Debug.Log("hit"+upSensor);
        }}
/*
        hit2 = Physics2D.Raycast(origin, directionupleft,SensorRange);
        if (hit2){
        if (hit2.collider.CompareTag("platform"))
        {
            leftupSensor = 1 - hit2.distance / SensorRange;
        }}
*/
        hit2 = Physics2D.Raycast(origin, directionupright,SensorRange);
        if (hit2){
            if (hit2.collider.CompareTag("platform"))
            {
                rightupSensor = 1 - hit2.distance / SensorRange;
            }
        }
/*
        hit2 = Physics2D.Raycast(origin, directiondown,SensorRange);
        if (hit2){
        if (hit2.collider.CompareTag("platform"))
        {
            downSensor = 1 - hit2.distance / SensorRange;
        }}

        hit2 = Physics2D.Raycast(origin, directionright,SensorRange);
        if (hit2){
            if (hit2.collider.CompareTag("platform"))
            {
                rightSensor = 1 - hit2.distance / SensorRange;
            }
        }
        hit2 = Physics2D.Raycast(origin, directionleft,SensorRange);
        if (hit2){
            if (hit2.collider.CompareTag("platform"))
            {
                leftSensor = 1 - hit2.distance / SensorRange;
            }
        }
        
*/
        
        

/*
        if (Physics.Raycast(transform.position + transform.right * 1.1f, transform.TransformDirection(new Vector3(0, 1,0).normalized), out hit, SensorRange)){
            Debug.Log("HIT");
            if (hit.collider.CompareTag("platform")){
                //upSensor = 1 - hit.distance / SensorRange;
                
            }
        }
        if (Physics.Raycast(transform.position + transform.forward * 1.1f, transform.TransformDirection(new Vector3(1, 0,0).normalized), out hit, SensorRange)){
            if (hit.collider.CompareTag("platform")){
                rightSensor = 1 - hit.distance / SensorRange;
            }
        }
        if (Physics.Raycast(transform.position + transform.forward * 1.1f, transform.TransformDirection(new Vector3(-1, 0,0).normalized), out hit, SensorRange)){
            if (hit.collider.CompareTag("platform")){
                leftSensor = 1 - hit.distance / SensorRange;
            }
        }
        if (Physics.Raycast(transform.position + transform.forward * 1.1f, transform.TransformDirection(new Vector3(0, -1,0).normalized), out hit, SensorRange)){
            if (hit.collider.CompareTag("platform")){
                downSensor = 1 - hit.distance / SensorRange;
            }
        }
        if (Physics.Raycast(transform.position + transform.forward * 1.1f, transform.TransformDirection(new Vector3(0.5f, 1,0).normalized), out hit, SensorRange)){
            if (hit.collider.CompareTag("platform")){
                rightupSensor = 1 - hit.distance / SensorRange;
            }
        }
        if (Physics.Raycast(transform.position + transform.forward * 1.1f, transform.TransformDirection(new Vector3(-0.5f, 1,0).normalized), out hit, SensorRange)){
            if (hit.collider.CompareTag("platform")){
                leftupSensor = 1 - hit.distance / SensorRange;
            }
        }

*/
        inputSignalArray[0] = gameObject.transform.position.x;
        inputSignalArray[1] = gameObject.transform.position.y;
        inputSignalArray[2] = GetClosestObject("platform");
        inputSignalArray[3] = GetClosestObject("ennemy");
        inputSignalArray[4] = upSensor;
        inputSignalArray[5] = downSensor;

        
    }

    float GetClosestObject(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag); 
        GameObject closest = null;
        float distance = 0;
        float minDistance = Mathf.Infinity;
        Vector3 playerPosition = gameObject.transform.position;

        foreach (GameObject object1 in objects)
        {
            //if (object1.transform.position.y > playerPosition.y){
                distance = Vector3.Distance(playerPosition, object1.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = object1;
                }
            
        }
        if (closest != null)
            return closest.transform.position.x;
        return 0;
    }

    protected override void UseBlackBoxOutpts(ISignalArray outputSignalArray)
    {
        // Called by the base class after the inputs have been processed

        // Read the outputs and do something with them
        // The size of the array corresponds to NeatSupervisor.NetworkOutputCount
        
        velocity = transform.position;
        velocity.x += (float)outputSignalArray[0]*movevelo*Time.fixedDeltaTime;
        transform.position = velocity;
        //if (uniqueID == 1)
        //Debug.Log("" + outputSignalArray[0]);

        velocity = transform.position;
        velocity.x -= (float)outputSignalArray[1]*movevelo*Time.fixedDeltaTime;
        transform.position = velocity;
   
        
        
        
        /*
        if ((bool)outputSignalArray[0]){
            velocity = transform.position;
            velocity.x -= movevelo*Time.fixedDeltaTime;
            transform.position = velocity;
        }
        if ((bool)outputSignalArray[1]){
            velocity = transform.position;
            velocity.x += movevelo*Time.fixedDeltaTime;
            transform.position = velocity;
        }
        */

        if (transform.position.x > GameObject.Find("wallright").transform.position.x){
            pos = transform.position;
            pos.x = GameObject.Find("wallleft").transform.position.x;
            transform.position = pos;
        }
        else if (transform.position.x < GameObject.Find("wallleft").transform.position.x){
            pos = transform.position;
            pos.x = GameObject.Find("wallright").transform.position.x;
            transform.position = pos;
        }

    }

    public override float GetFitness()
    {
        // Called during the evaluation phase (at the end of each trail)

        // The performance of this unit, i.e. it's fitness, is retrieved by this function.
        // Implement a meaningful fitness function here
        return ai.score;
    }
    
    

    protected override void HandleIsActiveChanged(bool newIsActive)
    {
        // Called whenever the value of IsActive has changed
        if (newIsActive == false){

            

            if (uniqueID == 1){
                respawn.reset();
            }
            transform.position = _initialPosition;
            transform.rotation = _initialRotation;
            //Debug.Log(ai.score);
            ai.score = 0;
            ai.height = 0;
            ai.isdead = false;


            
        }
        
        

        // Since NeatSupervisor.cs is making use of Object Pooling, this Unit will never get destroyed. 
        // Make sure that when IsActive gets set to false, the variables and the Transform of this Unit are reset!
        // Consider to also disable MeshRenderers until IsActive turns true again.
    }
}
