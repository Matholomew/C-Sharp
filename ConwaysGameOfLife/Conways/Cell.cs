using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Conways
{
     public class Cell
    {
        //constants 
              
        //fields
        private List <Cell> neighbours;
        private bool currentState;
        private bool nextState;
        private int nNeighbours;
        private int generation;
        
        public Cell()
        {
            neighbours = new List <Cell>();
            currentState = false;
            nextState = false;
            generation = 0;
            nNeighbours = 0;
        }

        public void ComputeNextCellGeneration()
        {
            //count number of live neighbours
            if (currentState)
            {
                if (nNeighbours == 3 || nNeighbours == 2)
                {
                    nextState = true;
                }
                if (nNeighbours == 0 || nNeighbours == 1)
                {
                    nextState = false;
                }
                if (nNeighbours >= 4)
                {
                    nextState = false;
                }
            }
            //implement the rules

        }

        public void UpdateNextCellGeneration()
        {
            // update currState from nextState;    
            // reset generation

            currentState = nextState;

        }

        public void Neighbour(Cell neighbour)
        {
            neighbours.Add(neighbour);
        }
        public bool CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
            }
        }

        public int Generation
        {
            get
            {
                return generation;
            }

            set
            {
                generation = value;
            }
        }

        public bool NextState
        {
            get
            {
                return nextState;
            }

            set
            {
                nextState = value;
            }
        }

        public int NNeighbours
        {
            get
            {
                return nNeighbours;
            }

            set
            {
                nNeighbours = value;
            }
        }
    }
}
