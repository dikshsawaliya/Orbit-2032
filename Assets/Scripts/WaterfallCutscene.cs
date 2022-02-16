using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallCutscene : MonoBehaviour
{
    public GameObject Player;

    public GameObject CutScene;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutScene.SetActive(true);
        Player.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(7);
        Player.SetActive(true);
        CutScene.SetActive(false);
    }
}
