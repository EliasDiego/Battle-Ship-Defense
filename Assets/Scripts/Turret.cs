using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YergoScripts;

public class Turret : MonoBehaviour
{
    [SerializeField] float _CoolDownTime = 0f;
    [SerializeField] Transform _LaserOrigin;
    [SerializeField] KeyCode _Keybind;
    LineRenderer _LineRenderer;

    float _LaserWidth = 0.1f;

    Camera _Camera;
    bool _IsCoolDown = false;
    Vector2 _MousePosition;

    void Awake()
    {
        _LineRenderer = GetComponent<LineRenderer>();
        _Camera = Camera.main;

        _LineRenderer.positionCount = 3;
        
        ResetLines(0, _LaserOrigin.position);
    }

    void Update()
    {
        _MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = _MousePosition - (Vector2)transform.position;
        
        _LaserWidth = _LaserWidth > 0 ? _LaserWidth - 0.1f * Time.deltaTime : 0;

        _LineRenderer.endWidth = _LaserWidth;
        _LineRenderer.startWidth = _LaserWidth;

        if(Input.GetKeyDown(_Keybind) && !_IsCoolDown)
        {
            RaycastHit2D hit;
            Vector2 dir = MathY.DegreeToVector2(transform.eulerAngles.z + 90f);
            Vector2 origin = _LaserOrigin.position;
            Missile missile;
            Collider2D collider = null;

            _LaserWidth = 0.1f;

            ResetLines(0, _LaserOrigin.position);
            StartCoroutine(CoolDown());

            for(int i = 1; i < 10; i++) // Bounces
            {
                hit = Physics2D.Raycast(origin, dir, 20);

                if(collider)
                    collider.enabled = true; //Renable collider after casting new ray
                    
                if(hit)
                {
                    origin = hit.point;
                    collider = hit.collider;
                    missile = collider.gameObject.GetComponent<Missile>();

                    ResetLines(i, hit.point);

                    if(missile)
                    {
                        missile.Health--;

                        if(missile is ReflectorMissile) 
                            dir = hit.normal; // Deflect 

                        else if(missile is SwarmMissile)
                            collider.enabled = false; // Pass through

                        else // Heavy Missile
                        {
                            collider.enabled = true; // Enable previous collided object
                            break; // Stop
                        }
                    }
                    
                    else // Asteroid
                    {
                        collider.enabled = true; // Enable previous collided object
                        break; // Stop
                    }
                }

                else
                    ResetLines(i, origin + dir * 20);
            }
        }
    }

    IEnumerator CoolDown()
    {
        _IsCoolDown = true;
        yield return new WaitForSeconds(_CoolDownTime);
        _IsCoolDown = false;
    }

    void ResetLines(int startIndex, Vector3 position)
    {
            for(int i = startIndex; i < _LineRenderer.positionCount; i++)
                _LineRenderer.SetPosition(i, position - Vector3.forward);
    }

    void ReflectLine(RaycastHit2D hit, int maxBounces)
    {

    }
}
