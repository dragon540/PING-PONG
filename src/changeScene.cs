/*
 * @author shobhit
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

    // to change scene
	public void changeMenuScene(string scene)
    {
        Application.LoadLevel(scene);
    }
}
