using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversiRestAPI {
    public class Game : IGame {
        public int ID { get; set; }
        public string Description { get; set; }

        //The unique token of the game
        public string Token { get; set; }
        public string Player1Token { get; set; }
        public string Player2Token { get; set; }
        public Colour[,] Board { get; set; }
        public Colour Turn { get; set; }

        public Game() {
            SetUp();
        }

        private void SetUp() {
            Board = new Colour[8, 8];
            for (int row = 0; row < Board.GetLength(0); row++) {
                for (int col = 0; col < Board.GetLength(1); col++) {
                    Board[row, col] = Colour.None;
                }
            }
            Board[3, 3] = Colour.White;
            Board[4, 4] = Colour.White;
            Board[3, 4] = Colour.Black;
            Board[4, 3] = Colour.Black;
        }

        public Colour DominantColour() {
            int whiteCount = 0, blackCount = 0;
            for (int row = 0; row < Board.GetLength(0); row++) {
                for (int col = 0; col < Board.GetLength(1); col++) {
                    switch (Board[row, col]) {
                        case Colour.White:
                            whiteCount++;
                            break;
                        case Colour.Black:
                            blackCount++;
                            break;
                    }
                }
            }
            if (whiteCount > blackCount)
                return Colour.White;
            else if (whiteCount < blackCount)
                return Colour.Black;
            else
                return Colour.None;
        }

        public bool DoMove(int row, int column) {
            //Get possible move
            bool isPossible = PossibleMove(row, column);
            if (!isPossible) return false;
            //Flip pieces to be taken
            var toBeTaken = GetPiecesToBeTaken(new Coordinates(column, row));
            toBeTaken.ForEach(coord => Board[coord.Y, coord.X] = Turn);
            Board[row, column] = Turn;

            if (Turn == Colour.White)
                Turn = Colour.Black;
            else
                Turn = Colour.White;

            return true;
        }

        public bool GameOver() {
            bool checkTurn = Pass();
            bool checkOpponent = Pass();

            return checkTurn && checkOpponent;
        }

        public bool Pass() {
            for (int row = 0; row < Board.GetLength(0); row++) {
                for (int col = 0; col < Board.GetLength(1); col++) {
                    if (PossibleMove(row, col))
                        return false;
                }
            }

            if (Turn == Colour.White)
                Turn = Colour.Black;
            else
                Turn = Colour.White;
            return true;
        }

        public bool PossibleMove(int row, int column) {
            if (row < 0 || column < 0 || row >= Board.GetLength(0) || column >= Board.GetLength(1)) return false;
            if (Board[row, column] != Colour.None) return false;
            bool willPieceBeTaken = WillPieceBeTaken(row, column); //Calculate shit here
            bool hasAdjacentPiece = HasAdjacentPiece(row, column);
            return willPieceBeTaken && hasAdjacentPiece;
        }

        private bool WillPieceBeTaken(int row, int column) {
            var piecesToBeTaken = GetPiecesToBeTaken(new Coordinates(column, row));
            return piecesToBeTaken.Count > 0;
        }

        private List<Coordinates> GetPiecesToBeTaken(Coordinates coordinates) {
            List<Coordinates> returnList = new List<Coordinates>();

            //Look in all 8 directions
            List<Coordinates> currList = new List<Coordinates>();
            Colour oppositeColour = Turn == Colour.White ? Colour.Black : Colour.White;

            //Look in row
            bool westFound = false;
            bool eastFound = false;

            //West
            for (int x = 0; x < coordinates.X; x++) {
                if (Board[coordinates.Y, x] == Colour.None && !westFound)
                    continue;
                else if (Board[coordinates.Y, x] == Colour.None && westFound) {
                    westFound = false;
                    break;
                }
                if (Board[coordinates.Y, x] == Turn)
                    westFound = true;
                else if (westFound)
                    currList.Add(new Coordinates(x, coordinates.Y));
            }

            currList = currList.Where(coord => Board[coord.Y, coord.X] == oppositeColour).ToList();
            if (westFound)
                returnList.AddRange(currList);
            else
                currList.Clear();

            //East
            for (int x = Board.GetLength(1) - 1; x > coordinates.X; x--) {
                if (Board[coordinates.Y, x] == Colour.None && !eastFound)
                    continue;
                else if (Board[coordinates.Y, x] == Colour.None && eastFound) {
                    eastFound = false;
                    break;
                }

                if (Board[coordinates.Y, x] == Turn)
                    eastFound = true;
                else if (eastFound)
                    currList.Add(new Coordinates(x, coordinates.Y));
            }

            currList = currList.Where(coord => Board[coord.Y, coord.X] == oppositeColour).ToList();
            if (eastFound)
                returnList.AddRange(currList);
            else
                currList.Clear();

            //Look in column
            bool northFound = false;
            bool southFound = false;

            //South
            for (int y = 0; y < coordinates.Y; y++) {
                if (Board[y, coordinates.X] == Colour.None && !southFound)
                    continue;
                else if (Board[y, coordinates.X] == Colour.None && southFound) {
                    southFound = false;
                    break;
                }

                if (Board[y, coordinates.X] == Turn)
                    southFound = true;
                else if (southFound)
                    currList.Add(new Coordinates(coordinates.X, y));
            }

            currList = currList.Where(coord => Board[coord.Y, coord.X] == oppositeColour).ToList();
            if (southFound)
                returnList.AddRange(currList);
            else
                currList.Clear();

            //North
            for (int y = Board.GetLength(0) - 1; y > coordinates.Y; y--) {
                if (Board[y, coordinates.X] == Colour.None && !northFound)
                    continue;
                else if (Board[y, coordinates.X] == Colour.None && northFound) {
                    northFound = false;
                    break;
                }

                if (Board[y, coordinates.X] == Turn)
                    northFound = true;
                else if (northFound)
                    currList.Add(new Coordinates(coordinates.X, y));
            }

            currList = currList.Where(coord => Board[coord.Y, coord.X] == oppositeColour).ToList();
            if (northFound)
                returnList.AddRange(currList);
            else
                currList.Clear();


            //Look in diagonals
            bool NWfound = false;
            bool NWlock = false;
            bool NEfound = false;
            bool NElock = false;
            bool SEfound = false;
            bool SElock = false;
            bool SWfound = false;
            bool SWlock = false;
            List<Coordinates> diagonals = GetDiagonals(coordinates);
            diagonals = diagonals.OrderBy(coord => coord.X).ThenBy(coord => coord.Y).ToList();
            foreach (var coord in diagonals) {
                Colour colour = Board[coord.Y, coord.X];

                if (coord.X < coordinates.X && coord.Y < coordinates.Y) {
                    //North West
                    Console.WriteLine($"NW: [X:{coord.X}, Y:{coord.Y}] Colour: {colour}");
                    if (NWlock) continue;
                    if (colour == Colour.None && !NWfound) continue;

                    if (colour == Turn && !NWfound)
                        NWfound = true;
                    else if (colour == Turn && NWfound)
                        NWlock = true;
                    else if (colour == Colour.None && NWfound)
                        NWlock = true;
                    else if (NWfound)
                        currList.Add(coord);
                } else if (coord.X > coordinates.X && coord.Y < coordinates.Y) {
                    //North East
                    Console.WriteLine($"NE: [X:{coord.X}, Y:{coord.Y}] Colour: {colour}");
                    if (NElock) continue;
                    if (colour == Colour.None && !NEfound) continue;

                    if (colour == Turn && !NEfound)
                        NEfound = true;
                    else if (colour == Turn && NEfound)
                        NElock = true;
                    else if (colour == Colour.None && NEfound)
                        NElock = true;
                    currList.Add(coord);
                } else if (coord.X > coordinates.X && coord.Y > coordinates.Y) {
                    //South East
                    Console.WriteLine($"SE: [X:{coord.X}, Y:{coord.Y}] Colour: {colour}");
                    if (SElock) continue;
                    if (colour == Colour.None && !SEfound) continue;

                    if (colour == Turn && !SEfound)
                        SEfound = true;
                    else if (colour == Turn && SEfound)
                        SElock = true;
                    else if (colour == Colour.None && SEfound)
                        SElock = true;
                    currList.Add(coord);
                } else {
                    //South West
                    Console.WriteLine($"SW: [X:{coord.X}, Y:{coord.Y}] Colour: {colour}");
                    if (SWlock) continue;
                    if (colour == Colour.None && !SWfound) continue;

                    if (colour == Turn && !SWfound)
                        SWfound = true;
                    else if (colour == Turn && SWfound)
                        SWlock = true;
                    else if (colour == Colour.None && SWfound)
                        SWlock = true;
                    else
                        currList.Add(coord);
                }
            }

            currList = currList.Where(coord => Board[coord.Y, coord.X] == oppositeColour).ToList();

            if (NWfound && !NWlock)
                returnList.AddRange(currList.Where(coord => coord.X < coordinates.X && coord.Y < coordinates.Y));
            if (NEfound)
                returnList.AddRange(currList.Where(coord => coord.X > coordinates.X && coord.Y < coordinates.Y));
            if (SEfound)
                returnList.AddRange(currList.Where(coord => coord.X > coordinates.X && coord.Y > coordinates.Y));
            if (SWfound && !SWlock)
                returnList.AddRange(currList.Where(coord => coord.X < coordinates.X && coord.Y > coordinates.Y));
            currList.Clear();

            return returnList;
        }

        private List<Coordinates> GetDiagonals(Coordinates coordinates) {
            List<Coordinates> returnList = new List<Coordinates>();
            for (int irow = 0; irow < Board.GetLength(0); irow++) {
                for (int col = 0; col < Board.GetLength(1); col++) {
                    if (!IsDiagonal(coordinates.Y, coordinates.X, irow, col)) continue;
                    returnList.Add(new Coordinates(col, irow));
                }
            }
            return returnList;
        }


        private bool IsDiagonal(int row1, int col1, int row2, int col2) {
            return (Math.Abs(row1 - col1) == Math.Abs(row2 - col2) || row1 + col1 == row2 + col2) && !(row1 == row2 && col1 == col2);
        }

        private bool HasAdjacentPiece(int row, int column) {
            //Constraints check
            int[] allowedRows = { row - 1, row, row + 1 };
            int[] allowedCols = { column - 1, column, column + 1 };
            if (row - 1 < 0)
                allowedRows[0] = row;
            if (row + 1 >= Board.GetLength(0))
                allowedRows[2] = row;

            if (column - 1 < 0)
                allowedCols[0] = column;
            if (column + 1 >= Board.GetLength(1))
                allowedCols[2] = column;

            allowedRows = allowedRows.Distinct().ToArray();
            allowedCols = allowedCols.Distinct().ToArray();

            //Actual check
            for (int irow = 0; irow < allowedRows.Length; irow++) {
                for (int col = 0; col < allowedCols.Length; col++) {
                    if (Board[allowedRows[irow], allowedCols[col]] != Colour.None) return true;
                }
            }

            return false;
        }

        public bool HasWaitingPlayer() {
            bool player1Empty = string.IsNullOrEmpty(Player1Token);
            bool player2Empty = string.IsNullOrEmpty(Player2Token);
            return player1Empty ^ player2Empty;
        }
    }
}
