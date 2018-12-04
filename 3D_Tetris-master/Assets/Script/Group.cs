using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Group : MonoBehaviour {

    public static int gameDifficulty = 1;
    public static int stage = 0;
    public static int numberOfBlocksLeft = 0;
    public int flag_F = 0;
    // Time since last gravity tick
    float lastFall = 0;
    int fallSpeed = 1; 

    //find each child block's position in the group
    //and find out whether the next moving position is aviliale.
    bool isValidGridPos()
    {
        foreach(Transform child in transform)
        {
            Vector3 v = Grid.roundVec3(child.position);

            //if not inside the border
            if (!Grid.insideBorder(v))
                return false;

            //block in grid cell (and not part of the same group)
            if (Grid.grid[(int)v.x, (int)v.y, (int)v.z] != null && Grid.grid[(int)v.x, (int)v.y, (int)v.z].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        //Remove old children from Grid
        for(int y = 0; y < Grid.h; ++y)
        {
            for(int x = 0; x < Grid.w; ++x)
            {
                for(int z = 0; z < Grid.l; ++z)
                {
                    if (Grid.grid[x, y, z] != null) 
                        if (Grid.grid[x, y, z].parent == transform)
                            Grid.grid[x, y, z] = null;
                }
            }
        }

        //add new children to grid
        foreach (Transform child in transform)
        {
            Vector3 v = Grid.roundVec3(child.position);
            Grid.grid[(int)v.x, (int)v.y, (int)v.z] = child;
        }
    }

    // Update is called once per frame
    void Update () {

        //Accelerometer input
        Vector3 dir = Vector3.zero;
        dir.y = -Input.acceleration.y;
        dir.z = Input.acceleration.z;

        if (Input.GetKeyDown(KeyCode.F))
        {
            /*
            if (flag_F == 1)
                flag_F = 0;
            else
                flag_F = 1;
                */

        }

        //Move left
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            if (flag_F == 0)
                transform.position += new Vector3(-1, 0, 0);
            else
                transform.position += new Vector3(1, 0, 0);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                //If not valid, reverse the process.
                if (flag_F == 0)
                    transform.position += new Vector3(1, 0, 0);
                else
                    transform.position += new Vector3(-1, 0, 0);
            }
        }
        //Move right
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            if (flag_F == 0)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position += new Vector3(-1, 0, 0);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                //If not valid, reverse the process.
                if (flag_F == 0)
                    transform.position += new Vector3(-1, 0, 0);
                else
                    transform.position += new Vector3(1, 0, 0);
            }
        }
        //Move forward
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            if (flag_F == 0)
                transform.position += new Vector3(0, 0, 1);
            else
                transform.position += new Vector3(0, 0, -1);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                //If not valid, reverse the process.
                if (flag_F == 0)
                    transform.position += new Vector3(0, 0, -1);
                else
                    transform.position += new Vector3(0, 0, 1);
            }
        }
        //Move backward
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            if (flag_F == 0)
                transform.position += new Vector3(0, 0, -1);
            else
                transform.position += new Vector3(0, 0, 1);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                //If not valid, reverse the process.
                if (flag_F == 0)
                    transform.position += new Vector3(0, 0, 1);
                else
                    transform.position += new Vector3(0, 0, -1);
            }
        }
        //Rotate
        //Z Axis
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            transform.Rotate(0, 0, -90);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
                //If not valid, reverse the process.
                transform.Rotate(0, 0, 90); ;
        }
        //X Axis
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            transform.Rotate(-90, 0, 0);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
                //If not valid, reverse the process.
                transform.Rotate(90, 0, 0); ;
        }
        //Y Axis
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            transform.Rotate(0, -90, 0);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
                //If not valid, reverse the process.
                transform.Rotate(0, 90, 0); ;
        }
        //Fall && move downwards
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - lastFall >= 1)
        {
            if (GamePlayButton.isPaused == true) return;
            //Modify position
            transform.position += new Vector3(0, -1, 0);
            //Check the validity
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                //Update gameScore.
                Grid.gameScore += 50;

                //If not valid, reverse the process.
                transform.position += new Vector3(0, 1, 0);

                numberOfBlocksLeft--;

                if (numberOfBlocksLeft > 0)
                {
                    //Check filled plane
                    Grid.checkFullPlane();

                    // Spawn next Group
                    FindObjectOfType<Spawner>().NextSpawner();
                }

                //Disable script
                enabled = false;
            }
            lastFall = Time.time;
        }
        //Accelerate drop with accelerometer
        else if (dir.sqrMagnitude > 2) 
        {
            if (GamePlayButton.isPaused == true) return;
            // Modify position
            transform.position += new Vector3(0, -fallSpeed, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                //Update gameScore.
                Grid.gameScore += 50;

                // It's not valid. revert.
                transform.position += new Vector3(0, fallSpeed, 0);

                numberOfBlocksLeft--;

                if (numberOfBlocksLeft > 0)
                {
                    //Check filled plane
                    Grid.checkFullPlane();

                    // Spawn next Group
                    FindObjectOfType<Spawner>().NextSpawner();
                }

                // Disable script
                enabled = false;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = gameDifficulty;
        //If default position is not valid, Game over.
        if (!isValidGridPos())
        {
            Grid.lastGameScore = Grid.gameScore;
            Grid.gameScore = 0;
            System.Array.Clear(Grid.isFilled, 0, Grid.h);
            stage = 1;
            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }
    }

    public static int GetNumberOfBlocksForStage(int stage)
    {
        return stage * 2 + 8;
    }
}
