﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV1
{

    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell hasnt been clicked yet
        /// </summary>
        Free,
        /// <summary>
        /// The cell is a O
        /// </summary>
        Nought,
        /// <summary>
        /// The cell is an X
        /// </summary>
        Cross
    }
}
