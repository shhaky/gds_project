package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Observable;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.Trade;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 15:56:10 this is a temporary TradeHistory for fast
 *          requests of the last few trades. It is Observable, the subscriber
 *          will be notified if there is a new Trade and is able to Push it to
 *          the Data Base
 */
public class TemporaryTradeHistory extends Observable {

	private Logger log = Logger.getLogger(TemporaryTradeHistory.class);

	private ArrayList<Trade> list;

	private int numberOfTradesStored;

	public TemporaryTradeHistory(int numberOfTradesStored) {

		this.setNumberOfTradesStored(numberOfTradesStored);
		this.list = new ArrayList<Trade>();

	}

	/**
	 * @return the number of stored trades
	 */

	public int size() {
		return list.size();
	}

	public void addTrade(Trade trade) {
		// push data to the observer
		this.setChanged();

		HashMap<String, Object> push = new HashMap<String, Object>();
		//IMPORTANT keyword for the push --> trade
		push.put("trade", trade);
		//TODO create new thread
		this.notifyObservers(push);
		// add it to the temporary storage
		this.list.add(trade);

		while (list.size() > numberOfTradesStored) {
			//remove last element
			list.remove(numberOfTradesStored);
		}

	}

	public Trade getLastTrade() {

		if (list.isEmpty()) {
			log.error("trade history is empty!");

			return null;
		}

		return list.get(list.size() - 1);
	}

	public ArrayList<Trade> getList() {
		return list;
	}

	public int getNumberOfTradesStored() {
		return numberOfTradesStored;
	}

	@Override
	public String toString() {
		return "[Tradehistory size =" + numberOfTradesStored + " " + list.toString() + "]";
	}

	public void setNumberOfTradesStored(int numberOfTradesStored) {
		this.numberOfTradesStored = numberOfTradesStored;
	}
}