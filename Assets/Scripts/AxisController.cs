using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisController : MonoBehaviour
{
    [SerializeField] TextMesh x_axisText;
    [SerializeField] TextMesh y_axisText;
    [SerializeField] TextMesh z_axisText;

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
