package nl.fontys.cryptoexchange.engine;

/**
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 02:01
 */
public class BidOrderBook extends OrderBook{

	public BidOrderBook() {
		super();
		super.bidAskModifier = BID;
	}

}
