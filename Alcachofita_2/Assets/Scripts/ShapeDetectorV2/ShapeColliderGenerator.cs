using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeColliderGenerator : MonoBehaviour
{
    PolygonCollider2D[] polygonColliders;
    [SerializeField]
    GameObject shape;


    private void Start()
    {

    }

    public bool AllPointsCollided(Vector3[][] puntillismo)
    {
        Collider2D lastCollider = null;
        int collidersDiferentes = 0;

        //Comprueba una colision cada ciertos puntos
        for (int i = 0; i < puntillismo.Length; i++)
        {
            for (int j = 0; j < puntillismo[i].Length; j++)
            {
                Collider2D pColl = Raycast(puntillismo[i][j]);
                if (lastCollider != null)
                {

                    if (pColl != null && pColl != lastCollider)
                    {
                        collidersDiferentes++;
                        lastCollider = pColl;
                        Debug.Log("Collider Nuevo");
                    }
                }
                else if(pColl != null)
                {
                    collidersDiferentes++;
                    lastCollider = pColl;
                }

                Debug.Log("i: " + i + " j: " + j);
                Debug.Log("\nlastCollider: " + lastCollider);
                Debug.Log("\npColl: " + pColl);
            }
        }
        Debug.Log("Collider con los que colisiona" + collidersDiferentes);


        return collidersDiferentes > polygonColliders.Length;
    }

    private Collider2D Raycast(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        //Colision en general, habra que comprobar con el collider concreto mediante layers (?)
        if (hit.collider != null)
        {
            //Debug.Log(pos);

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(pos, forward, Color.green);
            return hit.collider;
        }
        // Debug.Log("not collidea");
        return null;
    }

    public void GenerateShape(ShapeSO _shape)
    {
        //Debug.Log(_shape);
        shape = _shape.runa;

        GameObject sasda = Instantiate(shape);

        //Debug.Log(sasda.transform.GetChild(0).GetComponent<PolygonCollider2D>());

        polygonColliders = new PolygonCollider2D[sasda.transform.childCount];

        polygonColliders[0] = sasda.transform.GetChild(0).GetComponent<PolygonCollider2D>();
        for (int i = 0; i < sasda.transform.childCount; i++)
        {
            Debug.Log(i);
        }
    }

}
