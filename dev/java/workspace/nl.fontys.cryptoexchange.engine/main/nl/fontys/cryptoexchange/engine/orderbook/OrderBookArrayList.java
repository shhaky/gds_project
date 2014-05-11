package nl.fontys.cryptoexchange.engine.orderbook;

import java.util.List;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderException;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistory;



/**
* @author Tobias Zobrist
* @version 1.0
* @updated 16-Apr-2014 17:48
*/


public class OrderBookArrayList implements OrderBook{

	
	private Logger log = Logger.getLogger(OrderBookArrayList.class);
	private final OrderList askList;
	private final OrderList bidList;
	
	private final TemporaryTradeHistory history;
	
	private final CurrencyPair currencyPair;
	
	
	public OrderBookArrayList(final CurrencyPair currencyPair) {
	
	this.askList = new AskOrderList();
	
	this.bidList = new BidOrderList();
	
	this.currencyPair = currencyPair;
	
	
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
	public void add(Order order) throws IllegalOrderException {
		
		
		
		if(order == null)
		{
			log.trace("Order is null, can not add to Orderbook");
			return;
		}
		
		
		//check type if Order doesn't fit with OrderBook Type it will throw exception
		if(order.getCurrencyPair().equals(this.currencyPair) == false)
		{
			throw new IllegalOrderException();
		}
		
		if(order.getType() == OrderType.BUY)
		{
			bidList.add(order);
			return;
		}
		else if(order.getType() == OrderType.SELL)
		{
			askList.add(order);
			return;
		}
		else
		{
			log.error("unknown Order Type");
		}
		
		throw new IllegalOrderException();
	}
	@Override
	public String toString() {
		
		return "ASK [" + askList.toString() + "], BID ["+ bidList.toString() + "]";
	}

	@Override
	public List<Order> getAskList() {
		
		return askList.toList();
	}

	@Override
	public List<Order> getBidList() {
		
		return bidList.toList();
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

	@Override
	public CurrencyPair getCurrencyPair() {
		return this.currencyPair;
	}


	
	
	
	
}
