using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] MeshRenderer meshRenderer;
    

    Vector2 meshOffset;

    // Start is called before the first frame update
    void Start()
    {
        meshOffset = meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = meshOffset;
    }
    // Update is called once per frame
    void Update()
    {
        var y = Mathf.Repeat(Time.time * speed, 1);
        var offset = new Vector2(meshOffset.x, y);

        meshRenderer.sharedMaterial.mainTextureOffset = offset;

    }
}
