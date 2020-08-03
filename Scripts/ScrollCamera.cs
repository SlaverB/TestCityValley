using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    [SerializeField]
    private float m_MaxScrollWight;

    [SerializeField]
    private float m_MaxScrollHeight;

	private Camera m_Camera;

    private float m_MinX;

    private float m_MaxX;

    private float m_MinY;

    private float m_MaxY;

    private Vector2 m_CurrentVelocity = Vector2.zero;

    private Vector2 m_PreviousFingerPosition;

    private Vector2 m_FingerWorldPosition
    {
        get
        {
			//#if (UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE) && !UNITY_EDITOR
			//	if (Input.touchCount == 1 )
			//		return m_Camera.ScreenToWorldPoint(Input.GetTouch(0).position);

			//#else
					return m_Camera.ScreenToWorldPoint(Input.mousePosition);
			//#endif
        }
    }

	public static ScrollCamera Instance;

	public bool CanScroll {get;set;}

	void Awake()
	{
		Instance = this;
	}

	void OnEnable()
	{
		CanScroll = true;
	}
    void Start()
    {
        m_MinX = -m_MaxScrollWight * 0.5f;

        m_MaxX = -m_MinX;

        m_MinY = -m_MaxScrollHeight * 0.5f;

        m_MaxY = -m_MinY;

        m_Camera = Camera.main;
	}

    void Update()
    {
		
		//#if (UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE) && !UNITY_EDITOR
		//if (CanScroll) 
		//{
		//HandleTouchInput();
		//} 
		//#else
		if (CanScroll) 
		{
			MouseInput();
		} 
		//#endif
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
			m_PreviousFingerPosition = m_FingerWorldPosition;
        }
         if (Input.GetMouseButton(0))
        {
            MoveCameraWithDrag();
        }  
    }

	private void TouchInput()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				m_PreviousFingerPosition = m_FingerWorldPosition;
			}
			if (touch.phase == TouchPhase.Moved)
			{
				MoveCameraWithDrag();
			}
		}
	}

    private void MoveCameraWithDrag()
    {
        Vector3 deltaPosition = m_FingerWorldPosition - m_PreviousFingerPosition;

		m_CurrentVelocity = deltaPosition / (Time.deltaTime);

        EditCameraPosition(m_Camera.transform.position - deltaPosition);

        m_PreviousFingerPosition = m_FingerWorldPosition;
    }

    private void EditCameraPosition(Vector2 position)
    {
        Vector2 validatePosition = CheckValidatePosition(position);

		m_Camera.transform.position = new Vector3(validatePosition.x, validatePosition.y, m_Camera.transform.position.z);
    }

    private Vector2 CheckValidatePosition(Vector2 position)
    {
        float cameraHeight = m_Camera.orthographicSize * 2.0f;

        float cameraWidth = ((float)Screen.width/ Screen.height) * cameraHeight;

        position.x = Mathf.Max(position.x, m_MinX + cameraWidth * 0.5f);

        position.y = Mathf.Max(position.y, m_MinY + cameraHeight * 0.5f);

        position.x = Mathf.Min(position.x, m_MaxX - cameraWidth * 0.5f);

        position.y = Mathf.Min(position.y, m_MaxY - cameraHeight * 0.5f);

        return position;
    }
}