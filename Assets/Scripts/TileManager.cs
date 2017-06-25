using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileManager
{
    const float CHUNK_FACTOR = 10;
    const float eyeSight = 10;
    public static List<List<Tile>> tiles = new List<List<Tile>>();

    static List<Tile> willShowTile = new List<Tile>();
    static List<Tile> beforeShowedTile = new List<Tile>();

    public static void ListenPlayerMove( object param )
    {
        Vector3 pos = (Vector3)param;

        //showTile
        int chunkIndexX = (int)(pos.x / CHUNK_FACTOR);
        int chunkIndexY = (int)(pos.y / CHUNK_FACTOR);

        //보여줄것 계산
        willShowTile.Clear();
        for ( int y = chunkIndexY - 1 ; y <= chunkIndexY + 1 ; y++ )
        {
            for ( int x = chunkIndexX - 1 ; x <= chunkIndexX + 1 ; x++ )
            {
                willShowTile.Add( tiles[y][x] );
            }
        }

        //보여줄것을 켜주고
        for ( int i = 0 ; i < willShowTile.Count ; i++ )
        {
            willShowTile[i].gameObject.SetActive( true );
        }


        //이전에 보여준것과 비교
        //보여주지 않을 것을 꺼준다.
        for ( int i = 0 ; i < beforeShowedTile.Count ; i++ )
        {
            if ( !willShowTile.Contains( beforeShowedTile[i] ) )
            {
                Tile oldTile = beforeShowedTile[i];
                oldTile.gameObject.SetActive( false );
            }
        }

        //이전에보여준것을 현재에 보여준 데이터를 넣어준다.
        beforeShowedTile.Clear();
        for ( int i = 0 ; i < willShowTile.Count ; i++ )
        {
            beforeShowedTile.Add( willShowTile[i] );
        }
    }
}
