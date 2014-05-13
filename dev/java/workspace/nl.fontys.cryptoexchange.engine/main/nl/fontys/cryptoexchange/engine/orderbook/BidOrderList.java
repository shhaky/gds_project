package nl.fontys.cryptoexchange.engine.orderbook;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 02:01
 */
public class BidOrderList extends OrderList {

	public BidOrderList() {
		super();
		super.bidAskModifier = BID;
	}

}
