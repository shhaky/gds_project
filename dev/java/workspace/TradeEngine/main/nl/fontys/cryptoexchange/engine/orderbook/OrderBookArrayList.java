package nl.fontys.cryptoexchange.engine.orderbook;

import java.util.Iterator;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistory;



/**
* @author Tobias Zobrist
* @version 1.0
* @updated 16-Apr-2014 17:48
*/


public class OrderBookArrayList implements OrderBook{

	
	private Logger log = Logger.getLogger(OrderBookArrayList.class);
	private OrderList askList;
	private OrderList bidList;
	
	private TemporaryTradeHistory history;
	
	
	public OrderBookArrayList() {
	
	this.askList = new AskOrderList();
	
	this.bidList = new BidOrderList();
	
	
	this.history = new TemporaryTradeHistory(200);
	
}
	
	@Override
	public Order getBestAskOffer() {
		
		return askList.getBestOffer();
		
	}

	@Override
	public Order getBestBidOffer() {

		return bidList.getBestOffer();
	}

	@Override
	public Order peekBestAskOffer() {
		
		return askList.peekBestOffer();
	}

	@Override
	public Order peekBestBidOffer() {
		
		return bidList.peekBestOffer();
	}

	@Override
	public boolean add(Order order) {
		
		if(order.getType() == OrderType.BUY)
		{
			bidList.add(order);
			return true;
		}
		else if(order.getType() == OrderType.SELL)
		{
			askList.add(order);
			return true;
		}
		else
		{
			log.error("unknown Order Type");
		}
		
		return false;
	}
	@Override
	public String toString() {
		
		return "ASK [" + askList.toString() + "], BID ["+ bidList.toString() + "]";
	}

	@Override
	public Iterator<Order> iteratorAsk() {
		
		return askList.iterator();
	}

	@Override
	public Iterator<Order> iteratorBid() {
		
		return bidList.iterator();
	}

	@Override
	public boolean cancelOrderById(long orderId) {
		
		boolean state = false;
		state = askList.removeOrderById(orderId);
		
		if(!state)
			state = bidList.removeOrderById(orderId);
			
		return state;
	}

	@Override
	public int getAskOrderLength() {
		return askList.size();
	}

	@Override
	public int getBidOrderLength() {
		return bidList.size();
	}

	@Override
	public TemporaryTradeHistory getTradeHistory() {
		return history;
	}


	
	
	
	
}
