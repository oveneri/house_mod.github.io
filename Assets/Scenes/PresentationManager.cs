using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationManager : MonoBehaviour
{
    public List<Camera> m_cameraArray = new List<Camera>();
    Camera m_currentCamera = null;
    public Material m_defaultMaterial = null;
    public Material m_grassMaterial = null;
    public GameObject m_terrainRoot = null;
    MeshRenderer[] m_meshRendererArray = null;
    bool m_showGrassMaterial = false;

    // Start is called before the first frame update
    void Start()
    {
        m_meshRendererArray = m_terrainRoot.GetComponentsInChildren<MeshRenderer>(true);
        updateTerrainMaterial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void activateCamera(int index)
    {
        if (m_currentCamera != null)
        {
            m_currentCamera.enabled = false;
        }

        m_currentCamera = m_cameraArray[index];

        if (m_currentCamera != null)
        {
            m_currentCamera.enabled = true;
        }
    }

    void updateTerrainMaterial()
    {
        for (int i = 0; i < m_meshRendererArray.Length; i++)
        {
            if (m_showGrassMaterial)
            {
                m_meshRendererArray[i].material = m_grassMaterial;
            }
            else
            {
                m_meshRendererArray[i].material = m_defaultMaterial;
            }
        }
        
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 1000));


        if (GUILayout.Button("Toggle ground texture"))
        {
            m_showGrassMaterial = !m_showGrassMaterial;
            updateTerrainMaterial();
        }

        for (int i = 0; i < m_cameraArray.Count; i++)
        {
            if (GUILayout.Button("Cam " + (i + 1)))
            {
                activateCamera(i);
            }
        }

        GUILayout.EndArea();
    }
}
