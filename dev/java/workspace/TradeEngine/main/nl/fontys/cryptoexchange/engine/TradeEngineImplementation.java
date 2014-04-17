package nl.fontys.cryptoexchange.engine;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Iterator;

import org.apache.log4j.Logger;
import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.BuyOrder;
import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;
import nl.fontys.cryptoexchange.core.SellOrder;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.exception.IllegalTradeExeption;
import nl.fontys.cryptoexchange.core.exception.NoMatchingPriceExeption;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;

/**
 * has a stack of threads and is doing the management of the TradeAgents
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 17-Apr-2014 03:54:54
 */
public class TradeEngineImplementation implements TradingEngine {

	
	public TradeEngineImplementation(){
		
		this.orderBook = new OrderBookArrayList();
		this.history = new TemporaryTradeHistory(200);

	}
public static void main(String[] args) {
	TradingEngine t = new TradeEngineImplementation();
	Order order = new BuyOrder(CurrencyPair.DOGE_BTC,46464,new BigDecimal(5646), new BigDecimal(44),1);
	
	
	Order orderSell = new SellOrder(CurrencyPair.DOGE_BTC,46464,new BigDecimal(5646), new BigDecimal(44),1);
	
	t.placeOrder(order);
	t.placeOrder(order);
	t.placeOrder(order);
	t.placeOrder(order);
	t.placeOrder(order);
	t.placeOrder(order);
	t.placeOrder(order);
	
	t.placeOrder(order);
	t.placeOrder(order);

	t.placeOrder(orderSell);
	t.placeOrder(orderSell);
	
	t.placeOrder(orderSell);
	
	t.placeOrder(orderSell);
	
	t.placeOrder(orderSell);
	
	
	Iterator<Order> orders = t.getPendingOrdersByUserId(1);
	
	while(orders.hasNext())
	System.err.println(orders.next());
	
	
}
	
	/**
	 * @return will return an Iterator of the pening orders by User ID
	 */

//TODO we have to find a better (more efficient) solution for the implementation in version 2
	@Override
	public Iterator<Order> getPendingOrdersByUserId(long userId) {
		
		ArrayList<Order> orderList = new ArrayList<Order>();
		
		@SuppressWarnings("unchecked")
		Iterator<Order>[] iterator = new Iterator[2];
		
		iterator[0] = orderBook.iteratorAsk();
		
		iterator[1] = orderBook.iteratorBid();
		
		for( int i = 0;i < iterator.length; i++)
		{
			
		while(iterator[i].hasNext())
		{
			Order order  = iterator[i].next();
			
			if(order.getUserId() == userId)
			{
				orderList.add(order);
				log.trace("Order found, added to Users Orderlist");
			}
		}
		}
		
		return orderList.iterator();
		
	}

	@Override
	public Iterator<Order> getBidDepth() {
		return orderBook.iteratorBid();
	}

	@Override
	public Iterator<Order> getAskDepth() {
		return orderBook.iteratorAsk();
	}

	@Override
	public boolean cancelOrderByOrder(Order order) {
		
		return this.cancelOrderByOrderId(order.getOrderId());
	}

	
	@Override
	public boolean cancelOrderByOrderId(long orderId) {
		
		
		return orderBook.cancelOrderById(orderId);
	}
	
	@Override
	public JSONObject getAskDepthAsJSON() {

		/**
		 * example
		 
		JSONArray array = new JSONArray(collection)
		
		JSONObject object = new JSONObject(array);
		
		object.toString();
		*/
		log.error("not implementet yet");
		return null;
	}

	@Override
	public JSONObject getBidDEpthAsJSON() {
		log.error("not implementet yet");
		return null;
	}

	/**
	 * if a matching Order is in the Orderbook it will execute it and add the trade to the History
	 * 
	 * else it will add the Order to the Orderbook
	 * 
	 * if only a part of the volume of the order is executable then it will execute the part and clone the Order and add the Order with the remaining volume to the Orderbook
	 */
	
	@Override
	public void placeOrder(Order order) {

		
		
		if(order.getType() == OrderType.BUY && orderBook.peekBestAskOffer() != null)
		{
			
			if(orderBook.peekBestAskOffer().getPrice().subtract(order.getPrice()).signum() > -1)
			{
				Order counterOrder = orderBook.getBestAskOffer();
				
				Order restOrder = Order.cloneRestOrder(order, counterOrder);
				
				Trade trade = null;
				//create trade
				try {
					trade = new Trade(order, counterOrder);
				} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
					log.error("unable to place Order");
					e.printStackTrace();
				}
			
				//add trade to history
				history.addTrade(trade);
				
				//add restorder to the Orderbook
				orderBook.add(restOrder);
				
			}
			else
			{
				orderBook.add(order);
			}
		}
		else if(order.getType() == OrderType.SELL && orderBook.peekBestBidOffer() != null)
		{
			if(orderBook.peekBestBidOffer().getPrice().subtract(order.getPrice()).signum() > -1)
			{
				Order counterOrder = orderBook.getBestBidOffer();
				
				Order restOrder = Order.cloneRestOrder(order, counterOrder);
				
				Trade trade = null;
				//create trade
				try {
					trade = new Trade(order, counterOrder);
				} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
					log.error("unable to place Order");
					e.printStackTrace();
				}
			
				//add trade to history
				history.addTrade(trade);
				
				//add restorder to the Orderbook
				if(restOrder != null)
				orderBook.add(restOrder);
				
			}
		
		}
		else
		{
			
			log.debug("orderBook is empty");
			orderBook.add(order);
		}
		
		
		
	}


	/**
	 * this will return you the last executed trade and from the trade you can get the
	 * price
	 */
	@Override
	public Trade getLastTrade() {
		
		return history.getLastTrade();
	}


	private TemporaryTradeHistory history;


	private OrderBook orderBook;


	private Logger log = Logger.getLogger(TradeEngineImplementation.class);

}