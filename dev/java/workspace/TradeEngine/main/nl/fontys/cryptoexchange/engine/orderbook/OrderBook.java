package nl.fontys.cryptoexchange.engine.orderbook;

import java.util.Iterator;
import java.util.List;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderException;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistory;
/**
* @author Tobias Zobrist
* @version 1.0
* @updated 16-Apr-2014 17:48
*/
public interface OrderBook {
	
	public void add(Order order) throws IllegalOrderException;
	
	public Order getBestAskOffer();
	
	public Order getBestBidOffer();
	
	public Order peekBestAskOffer();
	
	public Order peekBestBidOffer();

	public List<Order> getAskList();
	
	public List<Order> getBidList();
	
	public int getAskOrderLength();
	
	public int getBidOrderLength();
	
	public TemporaryTradeHistory getTradeHistory();
	
	public boolean cancelOrderById(long OrderId);
	@Override
	public String toString();
	
	public CurrencyPair getCurrencyPair();
}
