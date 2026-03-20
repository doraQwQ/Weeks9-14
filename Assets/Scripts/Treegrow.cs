using System;
using System.Collections;
using UnityEngine;


public class TreeGrow : MonoBehaviour
{
    public AnimationCurve growCurve;
    public Transform branchesTransform;
    public float maxSpawnDistance;

    public float duration;
    public float appleGrowDuration;
    public GameObject applePrefab;

    private Coroutine treeGrowCoroutine;
    private Coroutine appleCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0f;

        //The contents of the while loop run while the condition is true
        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;

            //Relinquishes control of Unity so that everything else can run
            //For the rest of this frame
            Debug.Log("How long has it been since the last frame?: " + Time.deltaTime);
            yield return null;
        }
        //IMPORTANT!!!!

        //relinguish control of Unity so everything can run
        appleCoroutine = StartCoroutine(AppleGrowUpdate());  //grows 3 apples

        //Wait until the appleCoroutine is done before moving on to the next line of code
        yield return appleCoroutine;

        //waits for the appleGrowDuration to elapse before starting the next apple grow
        //yield return new WaitForSeconds( appleGrowDuration);  //delay --> appleGrowDuration
        appleCoroutine = StartCoroutine(AppleGrowUpdate());

        yield return appleCoroutine;

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        
    }

    private IEnumerator AppleGrowUpdate()
    {
        Vector3 spawnPosition = branchesTransform.position;
        spawnPosition += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnDistance;

        GameObject spawnedApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        spawnedApple.transform.localScale = Vector3.zero;
        float progress = 0f;

        while (progress < appleGrowDuration)
        {
            progress += Time.deltaTime;

            spawnedApple.transform.localScale = growCurve.Evaluate(progress / appleGrowDuration) * Vector3.one;

            //Relinquishes control of Unity so that everything else can run
            //For the rest of this frame
            Debug.Log("How long has it been since the last frame?: " + Time.deltaTime);
            yield return null;
        }
    }
    //IMPORTANT!!!!
    public void OnGrowPress()
    {
        treeGrowCoroutine = StartCoroutine(TreeGrowUpdate());
    }
    //IMPORTANT!!!!
    public void OnStopPress()
    {
        //Instead of stopping the instance of Coroutine.
        //We stop the coroutine that is currently running the tree grow update.
        if(treeGrowCoroutine != null)
        {
            StopCoroutine(treeGrowCoroutine);
        }
        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
    }
}