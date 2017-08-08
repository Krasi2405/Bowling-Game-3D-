using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperBar : MonoBehaviour {
    
    [SerializeField]
    public float raiseValue = 1.3f;
    [SerializeField]
    public float raiseTime = 2f;
    [SerializeField]
    public GameObject[] helperBars;

    private bool isLowered = true;
	

	public void ToggleHelperBarState()
    {
        if(isLowered)
        {
            foreach (GameObject helperBar in helperBars)
            {
                Transform hbTransform = helperBar.transform;
                StartCoroutine(
                    MoveToPosition(
                        hbTransform,
                        new Vector3(hbTransform.position.x, hbTransform.position.y + raiseValue, hbTransform.position.z),
                        raiseTime)
                );
            }
            isLowered = false;
        }
        else
        {
            foreach (GameObject helperBar in helperBars)
            {
                Transform hbTransform = helperBar.transform;
                StartCoroutine(
                    MoveToPosition(
                        hbTransform,
                        new Vector3(hbTransform.position.x, hbTransform.position.y - raiseValue, hbTransform.position.z),
                        raiseTime)
                );
            }
            isLowered = true;
        }
    }

    private IEnumerator MoveToPosition(Transform obj, Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = obj.position;
        while (elapsedTime < time)
        {
            obj.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.position = newPosition;
    }
}
