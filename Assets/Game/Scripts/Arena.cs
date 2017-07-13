﻿using UnityEngine;

public class Arena : MonoBehaviour {
    private ArenaTile[,] _tile;
    private int _maxTileX;
    private int _maxTileY;

    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }
    public int maxTileX { get { return _maxTileX; } private set { _maxTileX = value; } }
    public int maxTileY { get { return _maxTileY; } private set { _maxTileY = value; } }

    void Awake() {
        maxTileX = transform.GetChild(0).childCount;
        maxTileY = transform.childCount;
        tile = new ArenaTile[maxTileX, maxTileY];

        for(int y = 0; y < maxTileY; ++y) {
            for(int x = 0; x < maxTileX; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
            }
        }
    }

    public void checkRow(int y) {
        int counter = 0;

        for(int x = 0; x < maxTileX; ++x) {
            if (tile[x, y].empty) break;
            else ++counter;
        }

        if (counter == maxTileX) {
            //TODO Add points.

            for (int x = 0; x < maxTileX; ++x) tile[x, y].removeTetrominoTile();

            for(int i = y - 1; i >= 0; --i) {
                for (int x = 0; x < maxTileX; ++x) tile[x, i].tetrominoFalldown();
            }
        }
    }
}
