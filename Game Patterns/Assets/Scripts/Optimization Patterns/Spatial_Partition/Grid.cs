using UnityEngine;

namespace Optimization_Patterns.Spatial_Partition
{
    /// <summary>
    /// The grid class which will also handle fighting.
    /// </summary>
    public class Grid
    {
        // How many units do we have on the grid, which should be faster than to iterate through all cells and count them.
        public int UnitCount { get; private set; }
        
        public const int NumCells = 10;
        public const int CellSize = 5;
    
        private readonly Unit[,] _cells = new Unit[NumCells, NumCells];
        
        public Grid()
        {
            // Clear the grid
            for (var x = 0; x < NumCells; x++)
            {
                for (var y = 0; y < NumCells; y++)
                {
                    _cells[x, y] = null;
                }
            }
        }
        
        /// <summary>
        /// Add unit to grid. This is also used when a unit already on the grid is moving into a new cell.
        /// </summary>
        /// <param name="newUnit">Unit/</param>
        /// <param name="isNewUnit">is new Unit?</param>
        public void Add(Unit newUnit, bool isNewUnit = false)
        {
            // Determine which grid cell it's in
            var cellPos = ConvertFromWorldToCell(newUnit.transform.position);

            // Add the unit to the front of list for the cell it's in
            newUnit.prev = null;
            newUnit.next = _cells[cellPos.x, cellPos.y];

            // Associate the cell with this unit
            _cells[cellPos.x, cellPos.y] = newUnit;

            // If there already was a unit in this cell, it should point to the new unit
            if (newUnit.next != null)
            {
                var nextUnit = newUnit.next;
                nextUnit.prev = newUnit;
            }
            
            if (isNewUnit)
            {
                UnitCount += 1;
            }
        }
        
        //Move a unit on the grid = see if it has changed cell
        //Make sure newPos is a valid position inside of the grid
        public void Move(Unit unit, Vector3 oldPos, Vector3 newPos)
        {
            //See what cell it was in before we assign the new position
            Vector2Int oldCellPos = ConvertFromWorldToCell(oldPos);

            //See which cell it's moving to
            Vector2Int newCellPos = ConvertFromWorldToCell(newPos);

            //If it didn't change cell, we are done
            if (oldCellPos.x == newCellPos.x && oldCellPos.y == newCellPos.y)
            {
                return;
            }

            //Unlink it from the list of its old cell
            UnlinkUnit(unit);

            //If this unit is the head of a linked-list in this cell, remove it
            if (_cells[oldCellPos.x, oldCellPos.y] == unit)
            {
                _cells[oldCellPos.x, oldCellPos.y] = unit.next;
            }

            //Add it back to the grid at its new cell
            Add(unit);
        }



        //Unlink a unit from its linked list
        private void UnlinkUnit(Unit unit)
        {
            if (unit.prev != null)
            {
                //The previous unit should get a new next
                unit.prev.next = unit.next;
            }

            if (unit.next != null)
            {
                //The next unit should get a new prev
                unit.next.prev = unit.prev;
            }            
        }

        /// <summary>
        /// Help method to convert from Vector3 to cell pos.
        /// </summary>
        /// <param name="pos">Vector3.</param>
        /// <returns>Vector2Int.</returns>
        private static Vector2Int ConvertFromWorldToCell(Vector3 pos)
        {
            var cellX = Mathf.FloorToInt(pos.x / CellSize);
            var cellY = Mathf.FloorToInt(pos.z / CellSize); //z instead of y because y is up in Unity's coordinate system
            
            var cellPos = new Vector2Int(cellX, cellY);
            
            return cellPos;
        }



        //Test if a position is a valid position (= is inside of the grid)
        public bool IsPosValid(Vector3 pos)
        {
            Vector2Int cellPos = ConvertFromWorldToCell(pos);

            if (cellPos.x >= 0 && cellPos.x < NumCells && cellPos.y >= 0 && cellPos.y < NumCells)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //
        // Fighting
        //

        //Make the units fight
        public void HandleMelee()
        {
            //Loop through all cells
            for (int x = 0; x < NumCells; x++)
            {
                for (int y = 0; y < NumCells; y++)
                {
                    HandleCell(x, y);
                }
            }
        }



        //Handles fight for a single cell
        private void HandleCell(int x, int y)
        {
            Unit unit = _cells[x, y];

            //Make each unit fight all other units once in this cell
            //It works like this: If the units in the cell are linked like: A-B-C-D
            //We always start with the first unit A, which we get from the cells[x, y]
            //Loop 1: A vs B, C, D. Change to unit B
            //Loop 2: B vs C, D. Change to unit C. (A-B where fighting in round 1, so they dont need to fight again)
            //Loop 3: C vs D. Change to unit D (C-A and C-B have already been fighting)
            //Loop 4: unit will be null so the loop will terminate
            while (unit != null)
            {
                //Try to fight other units in this cell
                HandleUnit(unit, unit.next);

                //We also should try to fight units in the 8 surrounding cells because some of them might be within the attack distance
                //But we cant check all 8 cells because then some units might fight each other two times, so we only check half (it doesnt matter which half)
                //We also have to check that there's a surrounding cell because the current cell might be the border
                //This assumes attack distance is less than cell size, or we might have to check more cells
                if (x > 0 && y > 0)
                {
                    HandleUnit(unit, _cells[x - 1, y - 1]);
                }
                if (x > 0)
                {
                    HandleUnit(unit, _cells[x - 1, y - 0]);
                }
                if (y > 0)
                {
                    HandleUnit(unit, _cells[x - 0, y - 1]);
                }
                if (x > 0 && y < NumCells - 1)
                {
                    HandleUnit(unit, _cells[x - 1, y + 1]);
                }

                unit = unit.next;
            }
        }



        //Handles fight for a single unit vs a linked-list of units
        private void HandleUnit(Unit unit, Unit other)
        {
            while (other != null)
            {
                //Make them fight if they have similar position - use square distance because it's faster
                if ((unit.transform.position - other.transform.position).sqrMagnitude < Unit.ATTACK_DISTANCE * Unit.ATTACK_DISTANCE)
                {
                    HandleAttack(unit, other);
                }

                other = other.next;
            }
        }

        

        //Handles attack between two units
        private void HandleAttack(Unit one, Unit two)
        {
            //Insert fighting mechanic
            one.StartFighting();
            two.StartFighting();
        }
    }
}
