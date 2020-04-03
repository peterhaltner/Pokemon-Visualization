using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisController : MonoBehaviour
{
    [SerializeField] TextMesh x_axisText;
    [SerializeField] TextMesh y_axisText;
    [SerializeField] TextMesh z_axisText;
    [SerializeField] Transform z_axisLabels;

    public enum Axises
    {
        X,
        Y,
        Z
    }

    public void SetAxisText(string text, Axises axis)
    {
        var textMesh = GetTextMesh(axis);
        textMesh.text = "\n\n" + text;      //Two new lines for spacing purposes
    }

    public void SetZLabelFlipped(bool isFlipped)
    {
        if(isFlipped)
        {
            z_axisText.transform.localEulerAngles = new Vector3(45f, 270f, 0);

            foreach( Transform trans in z_axisLabels.GetComponentsInChildren<Transform>() )
            {
                if (trans == z_axisLabels.transform) { continue; } //Skip the parent, only do children

                trans.localEulerAngles = new Vector3(45f, 270f, 0);
            }
        }
        else
        {
            z_axisText.transform.localEulerAngles = new Vector3(45f, 90f, 0);

            foreach (Transform trans in z_axisLabels.GetComponentsInChildren<Transform>())
            {
                if(trans == z_axisLabels.transform) { continue; } //Skip the parent, only do children

                trans.localEulerAngles = new Vector3(45f, 90f, 0);
            }
        }
    }

    TextMesh GetTextMesh(Axises axis)
    {
        switch(axis)
        {
            case Axises.X:
                return x_axisText;
            case Axises.Y:
                return y_axisText;
            case Axises.Z:
                return z_axisText;
            default:
                Debug.LogError("Axis not found");
                return null;
        }
    }
}
