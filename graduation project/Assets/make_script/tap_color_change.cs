using UnityEngine;

namespace Leap.Unity {

  /// <summary>
  /// Use this component on a Game Object to allow it to be manipulated by a pinch gesture.  The component
  /// allows rotation, translation, and scale of the object (RTS).
  /// </summary>
  public class tap_color_change : MonoBehaviour {
      Renderer rend;
      int Rcount = 0;
      int Gcount = 0;
      int Bcount = 0;
      int Bkcount = 0;
    public enum RotationMethod {
      None,
      Single,
      Full
    }
        int test=0;

    [SerializeField]
    private PinchDetector _pinchDetectorA;
    public PinchDetector PinchDetectorA {
      get {
        return _pinchDetectorA;
      }
      set {
        _pinchDetectorA = value;
      }
    }

    [SerializeField]
    private PinchDetector _pinchDetectorB;
    public PinchDetector PinchDetectorB {
      get {
        return _pinchDetectorB;
      }
      set {
        _pinchDetectorB = value;
      }
    }

    [SerializeField]
    private RotationMethod _oneHandedRotationMethod;

    [SerializeField]
    private RotationMethod _twoHandedRotationMethod;

    [SerializeField]
    private bool _allowScale = true;

    [Header("GUI Options")]
    [SerializeField]
    private KeyCode _toggleGuiState = KeyCode.None;

    [SerializeField]
    private bool _showGUI = true;

    private Transform _anchor;

    private float _defaultNearClip;

    void Start() {
        rend = GetComponent<Renderer>();
//      if (_pinchDetectorA == null || _pinchDetectorB == null) {
//        Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
//        enabled = false;
//      }

      GameObject pinchControl = new GameObject("RTS Anchor");
      _anchor = pinchControl.transform;
      _anchor.transform.parent = transform.parent;
      transform.parent = _anchor;
    }

    void Update() {
            
            /*if (Input.GetKeyDown(_toggleGuiState)) {
              _showGUI = !_showGUI;
            }*/
           // Debug.Log(_pinchDetectorB.tag);
      if (test == 1) { 
      bool didUpdate = false;
      if(_pinchDetectorA != null)
        didUpdate |= _pinchDetectorA.DidChangeFromLastFrame;
      if(_pinchDetectorB != null)
        didUpdate |= _pinchDetectorB.DidChangeFromLastFrame;

      if (didUpdate) {
        transform.SetParent(null, true);
      }

      if (_pinchDetectorA != null && _pinchDetectorA.IsActive && 
          _pinchDetectorB != null &&_pinchDetectorB.IsActive) {
        transformDoubleAnchor();
      } else if (_pinchDetectorA != null && _pinchDetectorA.IsActive) {
        transformSingleAnchor(_pinchDetectorA);
      } else if (_pinchDetectorB != null && _pinchDetectorB.IsActive) {
        transformSingleAnchor(_pinchDetectorB);
      }

      if (didUpdate) {
        transform.SetParent(_anchor, true);
      }
     }
     test = 0;
    }
   
    
    private void transformDoubleAnchor() {
      _anchor.position = (_pinchDetectorA.Position + _pinchDetectorB.Position) / 2.0f;

      switch (_twoHandedRotationMethod) {
        case RotationMethod.None:
          break;
        case RotationMethod.Single:
          Vector3 p = _pinchDetectorA.Position;
          p.y = _anchor.position.y;
          _anchor.LookAt(p);
          break;
        case RotationMethod.Full:
          Quaternion pp = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
          Vector3 u = pp * Vector3.up;
          _anchor.LookAt(_pinchDetectorA.Position, u);
          break;
      }

      if (_allowScale) {
        _anchor.localScale = Vector3.one * Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
      }
    }

    private void transformSingleAnchor(PinchDetector singlePinch) {
      _anchor.position = singlePinch.Position;

      switch (_oneHandedRotationMethod) {
        case RotationMethod.None:
          break;
        case RotationMethod.Single:
          Vector3 p = singlePinch.Rotation * Vector3.right;
          p.y = _anchor.position.y;
          _anchor.LookAt(p);
          break;
        case RotationMethod.Full:
          _anchor.rotation = singlePinch.Rotation;
          break;
      }

      _anchor.localScale = Vector3.one;
    }
     
    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "rHand")
        {
            test = 1;
            switch (ColorStatusScript.statnum)
            {
                case 1:
                    Rcount++;
                    if (Rcount > 270)
                    {
                        rend.material.color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                        Rcount = 0;
                    }
                    break;

                case 2:
                    Gcount++;
                    if (Gcount > 270)
                    {
                        rend.material.color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                        Gcount = 0;
                    }
                    break;

                case 3:
                    Bcount++;
                    if (Bcount > 270)
                    {
                        rend.material.color = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
                        Bcount = 0;
                    }
                    break;

                case 4:
                    Bkcount++;
                    if(Bkcount>270)
                    {
                        rend.material.color = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
                        Bkcount = 0;
                    }
                    break;
                default:
                    break;
            }
        }
     }
   }
}
