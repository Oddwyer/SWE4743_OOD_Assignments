/* IPlayer Design:
      - Minimal.
      - Do not expose internal state: no public fields, mutable collections.
      - No UI logic (no printing, no input handling).
      - Represent roles, define behavior - no implementation.
      - Enable polymorphism, dynamic dispatch.
      - If method not required by EVERY implementation, doesn't belong here.
      - Prefer passing a context object over many method parameters. 
*/

namespace CrazyEights.Cards;

using CrazyEights.Domain;

public interface ICard
{
    // Think: What must ICard have that others can view/request from every implementation of ICard?
    Suit Suit { get; }
    Rank Rank { get; }

    // May request if wildcard.
    public bool IsWildCard();
    
    // Must view card.
    public void ViewCard();
}