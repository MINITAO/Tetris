﻿using UnityEngine;
using System.Collections;

public class blockController_T : blockController
{
    override public void rotate()
    {
        if(actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 9 && tile[0].arenaTile.posY > 0) //DOWN -> RIGHT
        {
            actitveRotation = rotation.RIGHT;
            rotateTiles(1, 0, 1, 1, 1, -1);
        }
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posX > 0) //RIGHT -> UP
        {
            actitveRotation = rotation.UP;
            rotateTiles(0, -1, 1, -1, -1, -1);
        }
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 0 && tile[0].arenaTile.posY < 19) //UP -> LEFT
        {
            actitveRotation = rotation.LEFT;
            rotateTiles(-1, 0, -1, -1, -1, 1);
        }
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX < 9) //LEFT -> DOWN
        {
            actitveRotation = rotation.DOWN;
            rotateTiles(0, 1, -1, 1, 1, 1);
        }
    }

    override public void turnLeft()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[1] { 2 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[1] { 0 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.UP && canTurn(new int[1] { 3 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[3] { 1, 2, 3 }, -1)) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[1] { 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[3] { 1, 2, 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.UP && canTurn(new int[1] { 2 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[1] { 0 }, 1)) moveTilesHorizontal(1);
    }

    override public void fallDown()
    {
        if (actitveRotation == rotation.DOWN && canFallDown(new int[3] { 1, 2, 3 }, 1)) moveTilesVertical(1);
        else if (actitveRotation == rotation.RIGHT && canFallDown(new int[2] { 0, 2 }, 2)) moveTilesVertical(1);
        else if (actitveRotation == rotation.UP && canFallDown(new int[3] { 0, 2, 3 }, 0)) moveTilesVertical(1);
        else if (actitveRotation == rotation.LEFT && canFallDown(new int[2] { 0, 3 }, 3)) moveTilesVertical(1);
        //else canFall = false;
        else
        {
            canFall = false;
            foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }
}
