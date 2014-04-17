package nl.fontys.cryptoexchange.engine.orderbook;

import java.util.Iterator;

import nl.fontys.cryptoexchange.core.Order;
/**
* @author Tobias Zobrist
* @version 1.0
* @updated 16-Apr-2014 17:48
*/
public interface OrderBook {
	
	public boolean add(Order order);
	
	public Order getBestAskOffer();
	
	public Order getBestBidOffer();
	
	public Order peekBestAskOffer();
	
	public Order peekBestBidOffer();

	public Iterator<Order> iteratorAsk();
	
	public Iterator<Order> iteratorBid();
	
	public int getAskOrderLength();
	
	public int getBidOrderLength();
	
	public boolean cancelOrderById(long OrderId);
	@Override
	public String toString();
}
