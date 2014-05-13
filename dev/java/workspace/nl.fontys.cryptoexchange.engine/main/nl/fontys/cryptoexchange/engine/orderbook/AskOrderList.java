package nl.fontys.cryptoexchange.engine.orderbook;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 02:01
 */
public class AskOrderList extends OrderList {

	public AskOrderList() {
		super();
		super.bidAskModifier = ASK;

	}

}
