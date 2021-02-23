using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperInteractable : Interactable
{
    NewsPaper newsPaper;

    private void Start()
    {
        newsPaper = GetComponentInParent<NewsPaper>();
    }

    public override void HandleAction(Transform transform)
    {
        newsPaper.OpenNewsPaper();
    }
}
