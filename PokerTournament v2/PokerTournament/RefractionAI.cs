using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTournament
{
    // AI player implementation from Hatin, Parker, Probeck
    class RefractionAI : Player
    {
        // enum to determine liklihood of getting a particular hand
        enum PossibilityLevel { Have, Likely, Possible, Unlikely, Poor, Impossible }; // based on amount of cards to discard. if have a hand, discard 0

        List<RefractionCard> refHand;
        List<int> rankOfTargetHands;
        int targetHandRank;

        // construct object with super class variables
        public RefractionAI(int playerId, string playerName, int totalMoney) : base(playerId, playerName, totalMoney)
        {
            refHand = new List<RefractionCard>();
            rankOfTargetHands = new List<int>();
        }

        public override PlayerAction BettingRound1(List<PlayerAction> actions, Card[] hand)
        {
            // convert hand to inner class
            refHand = ConvertHandToRefCards(hand);

            // get rank of current hand and highest card
            Card highCard = null;
            int currentRank = Evaluate.RateAHand(hand, out highCard);

            if (currentRank < 2) // check for at least a potential pair
            {
                currentRank = 2;
            }

            // based on current rank, loop through and evaluate all possible hand types and determine most likely
            PossibilityLevel bestChance = PossibilityLevel.Impossible;
            PossibilityLevel currentChance;
            for (int i = currentRank; i < 11; i++)
            {
                currentChance = CheckForHandOfRank(i, refHand); // get chance of current hand

                if (currentChance < bestChance) // if current chance is better than current best, reassign
                {
                    rankOfTargetHands.Clear(); // clear old bests
                    bestChance = currentChance; // overwrite best
                    rankOfTargetHands.Add((int)bestChance); // add new best
                }
                else if (currentChance == bestChance) // if equally as good
                {
                    rankOfTargetHands.Add((int)currentChance); // add both target ranks
                }
            }

            // loop through target hand indices determine which is most likely 
            if (rankOfTargetHands.Count > 1)
            {
                foreach (int targetRank in rankOfTargetHands) // resolve conflict
                {
                    // TODO: determine which rank is more likely -- NPAR
                    // determine based on pot size/money total
                    //Function needed

                    // assign target rank
                    //targetHandRank = targetRank;
                }
            }
            else
            {
                targetHandRank = rankOfTargetHands[0];
            }

            // get total amount of discards
            int discardingTotal = GetTotalDiscardsForHandRank(targetHandRank);

            // TODO: Determine bet/bluff action -- KPAR, NPRO
            // look at the action queue from Game
            //function(int and stuff)

            // TODO: return appropriate PlayerAction object
            return new PlayerAction(Name, "Bet1", "bet", 0);
        }

        public override PlayerAction BettingRound2(List<PlayerAction> actions, Card[] hand)
        {
            // get rank of current hand and highest card
            Card highCard = null;
            int finalRank = Evaluate.RateAHand(hand, out highCard); // final hand rank

            // TODO: determine bet/bluff action based on rank  -- KPAR, NPRO
            //function(int and stuff)

            // TODO: run modified evaluation and return PlayerAction object
            return new PlayerAction(Name, "Bet1", "bet", 0);
        }

        public override PlayerAction Draw(Card[] hand) // TODO: JHAT
        {
            // TODO: Card values to be discarded for target hand

            // TODO: get index of card for deletion

            // TODO: handle cases of discard all and discard none

            // TODO: return PlayerAction object
            return new PlayerAction(Name, "Draw", "draw", 0);
        }

        private int GetTotalDiscardsForHandRank(int rank)
        {
            int discards = 0;
            foreach (RefractionCard card in refHand) // loop through inner class hand
            {
                if (card.HandsThatWouldDiscard.Contains(rank)) // if card property list contains rank, it would be discarded
                {
                    discards++; // increment total
                }
            }

            return discards;
        }

        private List<RefractionCard> ConvertHandToRefCards(Card[] hand)
        {
            List<RefractionCard> aiHand = new List<RefractionCard>();
            foreach (Card baseCard in hand)
            {
                aiHand.Add(new RefractionCard(baseCard));
            }

            return aiHand;
        }

        // generic method to check for possibility of a specific ranked hand
        private PossibilityLevel CheckForHandOfRank(int rank, List<RefractionCard> hand)
        {
            switch (rank)
            {
                case 2:
                    return CheckForPair(rank, hand);
                case 3:
                    return CheckForTwoPair(rank, hand);
                case 4:
                    return CheckForThreeOfAKind(rank, hand);
                case 5:
                    return CheckForStraight(rank, hand);
                case 6:
                    return CheckForFlush(rank, hand);
                case 7:
                    return CheckForFullHouse(rank, hand);
                case 8:
                    return CheckForFourOfAKind(rank, hand);
                case 9:
                    return CheckForStraightFlush(rank, hand);
                case 10:
                    return CheckForRoyalFlush(rank, hand);
                default:
                    return PossibilityLevel.Impossible;
            }
        }

        private PossibilityLevel CheckForRoyalFlush(int rank, List<RefractionCard> hand)//Noah
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForStraightFlush(int rank, List<RefractionCard> hand)//Noah
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForFourOfAKind(int rank, List<RefractionCard> hand)//Kenny
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForFullHouse(int rank, List<RefractionCard> hand)//Kenny
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForFlush(int rank, List<RefractionCard> hand)//Noah
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForStraight(int rank, List<RefractionCard> hand)//Noah
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForThreeOfAKind(int rank, List<RefractionCard> hand)//Kenny
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // TODO: based on amount of cards discarded return 
        }

        private PossibilityLevel CheckForTwoPair(int rank, List<RefractionCard> hand)//Kenny
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // return possible so this hand is only targeted if nothing better available 
        }

        private PossibilityLevel CheckForPair(int rank, List<RefractionCard> hand)//Kenny
        {
            // TODO: add logic that would mark refraction cards for discard in order to possibly get this hand
            // refractionCard.DiscardFromHandWithRank(rank);
            return PossibilityLevel.Possible; // return possible so this hand is only targeted if nothing better available 
        }

        private PossibilityLevel GetPossilityForDiscards(int numDiscarded)
        {
            switch (numDiscarded)
            {
                case 0:
                    return PossibilityLevel.Have;
                case 1:
                    return PossibilityLevel.Likely;
                case 2:
                    return PossibilityLevel.Possible;
                case 3:
                    return PossibilityLevel.Unlikely;
                case 4:
                    return PossibilityLevel.Poor;
                case 5:
                    return PossibilityLevel.Impossible;
                default:
                    return PossibilityLevel.Impossible;
            }
        }

        class RefractionCard // inner class to add property to each card to determine what hands would require it to be discarded
        {
            Card cardValue;
            List<int> handsThatWouldDiscard; // list of ints (hand ranks) that would not want this card

            public RefractionCard(Card baseCard) // store base card object with list reference to hands that would discard
            {
                cardValue = baseCard;
                handsThatWouldDiscard = new List<int>();
            }

            public void DiscardFromHandWithRank(int rank) // function to add hands that would discard this card
            {
                handsThatWouldDiscard.Add(rank);
            }

            /* Properties */
            public List<int> HandsThatWouldDiscard
            {
                get { return handsThatWouldDiscard; }
            }

            public Card CardValue
            {
                get { return cardValue; }
                set { cardValue = value; }
            }
        }
    }
}
