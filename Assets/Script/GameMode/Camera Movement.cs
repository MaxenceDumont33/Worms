using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     private static CameraMovement instance;
    
    public static CameraMovement Instance => instance;
    
    public enum CameraMode
    {
        Player,
        Bullet,
        Flight
    }
    
    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private CameraMode cameraMode = CameraMode.Player;

    public CameraMode CurrentCameraMode
    {
        get => cameraMode;
        set
        {
            cameraMode = value;
            switch (cameraMode)
            {
                case CameraMode.Player:
                    StartCoroutine(CameraFollowPlayer());
                    break;
                case CameraMode.Bullet:
                    StartCoroutine(CameraFollowBullet());
                    break;
                case CameraMode.Flight:
                    StartCoroutine(CameraFreeFlight());
                    break;
            }
        }
    }
    
    IEnumerator CameraFollowPlayer()
    {
        
        while (CurrentCameraMode == CameraMode.Player)
        {
            Vector3 MovePosition = GetCameraPlayerPosition();
            CameraMove(MovePosition);
            yield return null;
        }
    }

    IEnumerator CameraFollowBullet()
    {
        
        while (CurrentCameraMode == CameraMode.Bullet)
        {
            Vector3 MovePosition = GetBulletPosition();
            CameraMove(MovePosition);
            yield return null;
        }
    }

    IEnumerator CameraFreeFlight()
    {
        yield return null;
        while (CurrentCameraMode == CameraMode.Flight)
        {
            yield return null;
        }
    }

    IEnumerator CameraTransition()
    {
        yield return null;
    }

    void CameraMove(Vector3 CameraPosition)
    {
        transform.position = CameraPosition;
    }

    Vector3 GetCameraPlayerPosition()
    {
        Vector3 cameraPosition;
        Vector3 CameraNewPosition = Versus.Instance.currentBear.transform.position;


        cameraPosition.x = CameraNewPosition.x;
        cameraPosition.y = CameraNewPosition.y +1.1f;
        cameraPosition.z = -14;
        
        return cameraPosition;
    }

    Vector3 GetBulletPosition()
    {
        Vector3 cameraPosition;
        Vector3 CameraNewPosition;
        CameraNewPosition.x = 0;
        CameraNewPosition.y = 1;
        CameraNewPosition.z = -14;
        if (Versus.Instance.currentBear.GetComponent<Shot>().bulletFired != null)
        {
             CameraNewPosition= Versus.Instance.currentBear.GetComponent<Shot>().bulletFired.transform.position;
        }
        
        cameraPosition.x = CameraNewPosition.x;
        cameraPosition.y = CameraNewPosition.y;
        cameraPosition.z = -2;

        return cameraPosition;
    }
}
