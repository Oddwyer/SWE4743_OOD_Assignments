/* Rank Class Design:
    - Rank possibilities: 2-10, Ace, Jack, King, Queen
    - Generate Rank Method: Generates card rank from possibilities.
*/

namespace CrazyEights.Domain;

using System;

// Using "enum" serves as a fixed set of named values. If using numbers, be sure to specify what number to begin with,
// else Two begins with 0...
public enum Rank
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace,
}