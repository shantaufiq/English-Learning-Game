using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnim : MonoBehaviour
{
    public AnimateUIPRO _anim;

    private void OnEnable()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    public void EnableGameObject()
    {

    }

    public void DisableGameObject()
    {
        _anim.ExecuteAnimation();
        _anim.afterAnimationIsOver.AddListener(() => this.gameObject.SetActive(false));
    }
}
