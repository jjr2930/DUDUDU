using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Tile : MonoBehaviour
{
    const float DELAY_DELETE_TIME = 10;
    IEnumerator delayDeleteCor = null;
    IEnumerator loadTileCor = null;
    public int indexX { get; set; }
    public int indexY { get; set; }

    [SerializeField]
    List<Tree> trees = new List<Tree>();
    List<Rock> rocks = new List<Rock>();
    List<Water> waters = new List<Water>();

    
    private void OnEnable()
    {
        if(null != delayDeleteCor )
        {
            StopCoroutine( delayDeleteCor );
        }

        loadTileCor = LoadTile();
        StartCoroutine( loadTileCor );
    }

    private void OnDisable()
    {
        delayDeleteCor = DelayDelete();
        StartCoroutine( delayDeleteCor);

    }

    IEnumerator DelayDelete()
    {
        yield return new WaitForSeconds( DELAY_DELETE_TIME );
        if(!gameObject.activeSelf)
        {
            if(null != loadTileCor)
            {
                StopCoroutine( loadTileCor );
            }
            DestroyImmediate( this.gameObject );
        }
    }

    /// <summary>
    /// 타일 로드 프로세스
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadTile()
    {     

        for ( int i = 0 ; i < trees.Count ; i++ )
        {
            yield return null;
        }
        
    }
}
