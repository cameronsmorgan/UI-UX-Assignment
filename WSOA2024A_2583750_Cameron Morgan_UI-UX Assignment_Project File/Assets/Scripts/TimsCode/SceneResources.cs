using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneResources : Singleton<SceneResources>
{
    [SerializeField]
    private GraphicRaycaster chestCanvasRaycaster;
    public GraphicRaycaster ChestCanvasRaycaster { get { return chestCanvasRaycaster;} }
}
