using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeAppearance : MonoBehaviour
{
    [SerializeField] NodeInformationController _nodeInformationController;

    //Regular Type Materials
    Material _type1Material;
    Material _type2Material;

    //Transparent Type Materials
    Material _type1TransparentMaterial;
    Material _type2TransparentMaterial;

    //Generation Material
    Material _generationMaterial;

    Renderer _type1Renderer;
    Renderer _type2Renderer;

    Behaviour _halo;
    Light _light;
    SphereCollider _collider;

    //Set default appearance
    public void SetupAppearance()
    {
        var materialHelper = GameObject.Find("SceneController").GetComponent<MaterialHelper>(); //Fine since happens only once per prefab at start.

        //Get Type1 Material
        _type1Material = materialHelper.GetMaterial(_nodeInformationController.Type1, false);
        _type1TransparentMaterial = materialHelper.GetMaterial(_nodeInformationController.Type1, true);

        //Get Type2 Material
        if (_nodeInformationController.Type2 != TypeHelper.Type.None)
        {
            _type2Material = materialHelper.GetMaterial(_nodeInformationController.Type2, false);
            _type2TransparentMaterial = materialHelper.GetMaterial(_nodeInformationController.Type2, true);
        }
        else
        {
            _type2Material = _type1Material;
            _type2TransparentMaterial = _type1TransparentMaterial;
        }

        //Get the child renderers
        _type1Renderer = transform.GetChild(0).GetComponent<Renderer>();
        _type2Renderer = transform.GetChild(1).GetComponent<Renderer>();

        //temp, set the materials
        _type1Renderer.material = _type1Material;
        _type2Renderer.material = _type2Material;

        //Get the halo renderer
        _halo = (Behaviour)GetComponent("Halo");

        //Enable if legendary
        _halo.enabled = _nodeInformationController.IsLegendary;

        //Get the light
        _light = GetComponent<Light>();

        //Get the collider
        _collider = GetComponent<SphereCollider>();
    }

    public void SetTransparent(bool isTransparent)
    {
        if(isTransparent)
        {
            _type1Renderer.material = _type1TransparentMaterial;
            _type2Renderer.material = _type2TransparentMaterial;
            _halo.enabled = false;
            _collider.enabled = false;
        }
        else
        {
            _type1Renderer.material = _type1Material;
            _type2Renderer.material = _type2Material;
            _halo.enabled = _nodeInformationController.IsLegendary;
            _collider.enabled = true;
        }
    }

    public void SetLightActive(bool enabled)
    {
        _light.enabled = enabled;
    }

    public void SetLightColor(Color lightColor)
    {
        _light.color = lightColor;
    }
}
