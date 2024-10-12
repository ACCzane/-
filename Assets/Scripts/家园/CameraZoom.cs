using UnityEngine;
using Cinemachine;
using Baracuda.Monitoring;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraZoom : MonitoredBehaviour
{
    // Cinemachine Virtual Camera 引用
    [Monitor]
    public CinemachineVirtualCamera virtualCamera;

    // 缩放相关参数
    [Header("Zoom Settings")]
    public float defaultOrthoSize = 5f;
    public float minOrthoSize = 2f;
    public float maxOrthoSize = 10f;
    public float zoomSpeed = 2f;
    public float smoothTime = 0.1f;
    private float targetOrthoSize;
    private float zoomVelocity = 0f;

    // 平移相关参数
    [Header("Pan Settings")]
    public float panSpeed = 20f;
    [Range(0f, 1f)]
    public float edgeThreshold = 0.05f; // 屏幕边缘阈值（0-1）
    public float panSmoothTime = 0.1f;
    private Vector3 panVelocity = Vector3.zero;

    // 相机移动边界（可选）
    [Header("Camera Bounds")]
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        // 获取 CinemachineVirtualCamera 组件
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // 确保相机是正交投影
        if (!virtualCamera.m_Lens.Orthographic)
        {
            Debug.LogWarning("Cinemachine Virtual Camera 不是正交投影。请将 Projection 设置为 Orthographic。");
        }

        // 设置默认正交大小
        if (virtualCamera.m_Lens.OrthographicSize == 0)
        {
            virtualCamera.m_Lens.OrthographicSize = defaultOrthoSize;
        }

        targetOrthoSize = virtualCamera.m_Lens.OrthographicSize;
    }

    void Update()
    {
        HandleZoom();
        HandlePan();
    }

    void HandleZoom()
    {
        // 获取鼠标滚轮输入
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            // 计算目标正交大小
            targetOrthoSize -= scrollInput * zoomSpeed;

            // 限制目标正交大小在最小和最大值之间
            targetOrthoSize = Mathf.Clamp(targetOrthoSize, minOrthoSize, maxOrthoSize);
        }

        // 平滑过渡到目标正交大小
        virtualCamera.m_Lens.OrthographicSize = Mathf.SmoothDamp(
            virtualCamera.m_Lens.OrthographicSize,
            targetOrthoSize,
            ref zoomVelocity,
            smoothTime
        );
    }

    [Monitor]
    Vector2 mouseNorm;
    void HandlePan()
    {
        // 获取鼠标位置（归一化）
        Vector3 mousePos = Input.mousePosition;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        mouseNorm = new Vector2(mousePos.x / screenSize.x, mousePos.y / screenSize.y);

        // 计算平移方向
        Vector3 panDirection = Vector3.zero;

        if (mouseNorm.x >= 1f - edgeThreshold)
        {
            panDirection += Vector3.right;
        }
        else if (mouseNorm.x <= edgeThreshold)
        {
            panDirection += Vector3.left;
        }

        if (mouseNorm.y >= 1f - edgeThreshold)
        {
            panDirection += Vector3.up;
        }
        else if (mouseNorm.y <= edgeThreshold)
        {
            panDirection += Vector3.down;
        }

        if (panDirection != Vector3.zero)
        {
            // 归一化方向并乘以速度
            panDirection = panDirection.normalized * panSpeed * Time.deltaTime;

            // 计算新的相机位置
            Vector3 newPosition = virtualCamera.transform.position + panDirection;

            // 限制相机位置（可选）
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

            // 平滑移动相机位置
            virtualCamera.transform.position = Vector3.SmoothDamp(
                virtualCamera.transform.position,
                newPosition,
                ref panVelocity,
                panSmoothTime
            );
        }
    }
}
