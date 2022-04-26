using System.Collections;
using UnityEngine;

namespace Sequencing_Patterns.Double_Buffer.Cave
{
    public class GameController : MonoBehaviour
    {
        //Display the pattern on this plane
        public MeshRenderer displayPlaneRenderer;

        //Is used to init the cellular automata by spreading random dots on a grid
        //And from these dots we will generate caves
        //The higher the fill percentage, the smaller the caves
        [Range(0, 1)]
        public float randomFillPercent;

        //The double buffer
        private int[,] _bufferOld;
        private int[,] _bufferNew;

        //The size of the grid
        private const int GridSize = 100;

        //How many steps do we want to simulate?
        private const int SimulationSteps = 20;

        //For how long will we pause between each simulation step so we can look at the result
        private const float PauseTime = 1f;
        
        private void Start()
        {
            _bufferOld = new int[GridSize, GridSize];
            _bufferNew = new int[GridSize, GridSize];

            //To get the same random numbers each time we run the script
            Random.InitState(100);

            //Init the old values so we can calculate the new values
            for (var x = 0; x < GridSize; x++)
            {
                for (var y = 0; y < GridSize; y++)
                {
                    //We dont want holes in our walls, so the border is always a wall
                    if (x == 0 || x == GridSize - 1 || y == 0 || y == GridSize - 1)
                    {
                        _bufferOld[x, y] = 1;
                    }
                    //Random walls and caves
                    else
                    {
                        _bufferOld[x, y] = Random.Range(0f, 1f) < randomFillPercent ? 1 : 0;
                    }
                }
            }
            
            //For testing that init is working
            //GenerateAndDisplayTexture(bufferOld);
            
            //Start the simulation
            StartCoroutine(SimulateCavePattern());
        }
        
        //Do the simulation in a coroutine so we can pause and see what's going on
        private IEnumerator SimulateCavePattern()
        {
            for (int i = 0; i < SimulationSteps; i++)
            {
                //Calculate the new values
                RunCellularAutomataStep();

                //Generate texture and display it on the plane
                GenerateAndDisplayTexture(_bufferNew);

                //Swap the pointers to the buffers
                (_bufferOld, _bufferNew) = (_bufferNew, _bufferOld);

                yield return new WaitForSeconds(PauseTime);
            }

            Debug.Log("Simulation completed!");
        }
        
        //Generate caves by smoothing the data
        //Remember to always put the new results in bufferNew and use bufferOld to do the calculations
        private void RunCellularAutomataStep()
        {
            for (var x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    //Border is always wall
                    if (x == 0 || x == GridSize - 1 || y == 0 || y == GridSize - 1)
                    {
                        _bufferNew[x, y] = 1;

                        continue;
                    }

                    //Uses bufferOld to get the wall count
                    var surroundingWalls = GetSurroundingWallCount(x, y);

                    //Use some smoothing rules to generate caves
                    if (surroundingWalls > 4)
                    {
                        _bufferNew[x, y] = 1;
                    }
                    else if (surroundingWalls == 4)
                    {
                        _bufferNew[x, y] = _bufferOld[x, y];
                    }
                    else
                    {
                        _bufferNew[x, y] = 0;
                    }
                }
            }
        }
        
        //Given a cell, how many of the 8 surrounding cells are walls?
        private int GetSurroundingWallCount(int cellX, int cellY)
        {
            int wallCounter = 0;

            for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX ++)
            {
                for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
                {
                    //We dont need to care about being outside of the grid because we are never looking at the border
                
                    //This is the cell itself and no neighbor!
                    if (neighborX == cellX && neighborY == cellY)
                    {
                        continue;
                    }

                    //This neighbor is a wall
                    if (_bufferOld[neighborX, neighborY] == 1)
                    {
                        wallCounter += 1;
                    }
                }
            }

            return wallCounter;
        }
        
        //Generate a black or white texture depending on if the pixel is cave or wall
        //Display the texture on a plane
        private void GenerateAndDisplayTexture(int[,] data)
        {
            //We are constantly creating new textures, so we have to delete old textures or the memory will keep increasing
            //The garbage collector is not collecting unused textures
            Resources.UnloadUnusedAssets();
            //We could also use 
            //Destroy(displayPlaneRenderer.sharedMaterial.mainTexture);
            //Or reuse the same texture
            
            //These two arrays are always the same so we could init them once at start
            var texture = new Texture2D(GridSize, GridSize);

            texture.filterMode = FilterMode.Point;

            Color[] textureColors = new Color[GridSize * GridSize];

            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    //From 2d array to 1d array
                    textureColors[y * GridSize + x] = data[x, y] == 1 ? Color.black : Color.white;
                }
            }

            texture.SetPixels(textureColors);

            texture.Apply();

            displayPlaneRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}
