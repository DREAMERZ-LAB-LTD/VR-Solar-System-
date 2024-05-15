using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PassthroughScripts : MonoBehaviour
{
    public OVRPassthroughLayer passthroughLayer;
    void Start()
    {
        if (OVRManager.IsPassthroughRecommended())
        {
            passthroughLayer.enabled = true;

            // Set camera background to transparent
            OVRCameraRig ovrCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
            var centerCamera = ovrCameraRig.centerEyeAnchor.GetComponent<Camera>();
            centerCamera.clearFlags = CameraClearFlags.SolidColor;
            centerCamera.backgroundColor = Color.clear;

            // Ensure your VR background elements are disabled
        }
        else
        {
            passthroughLayer.enabled = false;

            // Ensure your VR background elements are enabled
        }
    }

    void EnableSelectivePassthrough(OVRPassthroughLayer layer, Renderer punchHoleRenderer)
    {
        layer.enabled = true;
        layer.hidden = false;

        // punchHoleRenderer punches holes in VR by writing non-one values into alpha.
        // We keep that renderer disabled until passthrough is ready.
        punchHoleRenderer.enabled = false;
        layer.PassthroughLayerResumed += onPassthroughLayerResumed;

        void onPassthroughLayerResumed()
        {
            punchHoleRenderer.enabled = true;
            layer.PassthroughLayerResumed -= onPassthroughLayerResumed;

        }

    }

}
