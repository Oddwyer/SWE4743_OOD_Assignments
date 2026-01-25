/* Rank Class Design:
    - Rank possibilities: 2-10, Ace, Jack, King, Queen
    - Generate Rank Method: Generates card rank from possibilities.
*/

namespace CrazyEights.Domain;

using System;

public class Rank
{
    private readonly string[] ranks = {"2","3","4","5","6","7","8","9", "10", "J", "Q", "K", "A" };

    public Rank();
}