package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;

import org.apache.log4j.Logger;
import org.json.JSONArray;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderCloneExeption;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderException;
import nl.fontys.cryptoexchange.core.exception.IllegalTradeException;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.core.exception.NoMatchingPriceException;
import nl.fontys.cryptoexchange.engine.exception.UnableToDeleteOrderException;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;

/**
 * has a stack of threads and is doing the management of the TradeAgents
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 17-Apr-2014 03:54:54
 */
public class TradeEngineImplementation implements TradeEngine {

	

	/**
	 * this map contains all available trading pairs
	 */
	
	private HashMap <String,OrderBook> orderBookMap;
	
	/**
	 * this set contains all available keys
	 */
	private HashSet<String> keySet;


	private Logger log = Logger.getLogger(TradeEngineImplementation.class);


	public TradeEngineImplementation(){
		
		this.keySet = new HashSet<String>();
		orderBookMap = new HashMap<String, OrderBook>();

	}
	
	
	
	
	
	
/**
	 * @return will return an Iterator of the pending orders by User ID
	 */

//TODO we have to find a better (more efficient) solution for the implementation in version 2
	@Override
	public List<Order> getPendingOrdersByUserId(long userId) {
		
		ArrayList<Order> orderList = new ArrayList<Order>();
	
		
		@SuppressWarnings("unchecked")
		Iterator<Order>[] iterator = new Iterator[2];
		
		ArrayList<OrderBook> orderBooks = new ArrayList<OrderBook>();
		
		Iterator<String> set = keySet.iterator();
		
		//add all OrderBooks to the List
		while(set.hasNext())
		{
			orderBooks.add(orderBookMap.get(set.next()));
		}
		
		//iterate trough all orders
		for(int ii= 0; ii < orderBooks.size(); ii++)
		{
		
		iterator[0] = orderBooks.get(ii).getAskList().iterator();
		
		iterator[1] = orderBooks.get(ii).getBidList().iterator();
		
		for( int i = 0;i < iterator.length; i++)
		{
			
		while(iterator[i].hasNext())
		{
			Order order  = iterator[i].next();
			
			if(order.getUserId() == userId)
			{
				//if ID matches add to return list
				orderList.add(order);
				log.trace("Order found, added to Users Orderlist");
			}
		}
		}
		}
		return orderList;
		
	}

	@Override
	public List<Order> getBidDepth(CurrencyPair pair) throws MarketNotAvailableException {
		
		
		
		OrderBook orderBook = orderBookMap.get(pair.toString());
		
		
		if(orderBook == null)
		{
			throw new MarketNotAvailableException(pair);
		}
		
		
		return orderBook.getBidList();
	}

	@Override
	public List<Order> getAskDepth(CurrencyPair pair) throws MarketNotAvailableException {
		
		OrderBook orderBook = orderBookMap.get(pair.toString());
		
		if(orderBook == null)
		{
			throw new MarketNotAvailableException(pair);
		}
		
		return orderBook.getAskList();
	}

	@Override
	public void cancelOrderByOrder(Order order) throws UnableToDeleteOrderException {
		
		this.cancelOrderByOrderId(order.getOrderId());
	}

	
	@Override
	public void cancelOrderByOrderId(long orderId) throws UnableToDeleteOrderException {
		
		
		
		
		for(String key : keySet)
		{
			if(orderBookMap.get(key).cancelOrderById(orderId) == true)
			{
				log.debug("Order ID: " + orderId + " canceled");
				return;
			}
		}
		
		
		log.debug("Order ID: " + orderId + "not canceled - Order not found");
		
		throw new UnableToDeleteOrderException("Order ID: " + orderId + "not canceled - Order not found");
		
	}
	
	@Override
	public String getAskDepthAsJSON(CurrencyPair pair) throws MarketNotAvailableException {

		JSONArray jsonArray = new JSONArray(this.getAskDepth(pair));
		
		String response = jsonArray.toString();
		
		log.trace("JSON RESPONSE " + response);
		return response;
	}

	@Override
	public String getBidDepthAsJSON(CurrencyPair market) throws MarketNotAvailableException {
JSONArray jsonArray = new JSONArray(this.getBidDepth(market));
		
		String response = jsonArray.toString();
		
		log.trace("JSON RESPONSE " + response);
		return response;
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

		Order restOrder = null;
		OrderBook orderBook = orderBookMap.get(order.getCurrencyPair().toString());
		
		if(orderBook == null)
		{
			log.error("Orderbook " + order.getCurrencyPair().toString() + " does not exist can not place order ID " + order.getOrderId());
			return;
		}
		
		
		if(order.getType() == OrderType.BUY && orderBook.peekBestAskOffer() != null
			//if offer is the same or better
			&& orderBook.peekBestAskOffer().getPrice().subtract(order.getPrice()).signum() < 1)
			{
				Order counterOrder = orderBook.getBestAskOffer();
				
				try {
					restOrder = Order.cloneRestOrder(order, counterOrder);
				} catch (IllegalOrderCloneExeption e1) {
					e1.printStackTrace();
					//can not happen!
					log.fatal("some serious error just happened!");
					
				}
				
				Trade trade = null;
				//create trade
				try {
					trade = new Trade(order, counterOrder);
				} catch (IllegalTradeException | NoMatchingPriceException e) {
					log.error("unable to place Order");
					//put the Order back to the Orderbook
					try {
						orderBook.add(counterOrder);
					} catch (IllegalOrderException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
					e.printStackTrace();
					return;
				}
			
				//add trade to history
				orderBook.getTradeHistory().addTrade(trade);
				
				
				
			}
	
		else if(order.getType() == OrderType.SELL && orderBook.peekBestBidOffer() != null &&
		orderBook.peekBestBidOffer().getPrice().subtract(order.getPrice()).signum() > -1)
			{
				Order counterOrder = orderBook.getBestBidOffer();
				
				
				try {
					restOrder = Order.cloneRestOrder(order, counterOrder);
				} catch (IllegalOrderCloneExeption e1) {
					e1.printStackTrace();
					//can not happen!
					log.fatal("some serious error just happened!");
				}
				
				Trade trade = null;
				//create trade
				try {
					trade = new Trade(order, counterOrder);
				} catch (IllegalTradeException | NoMatchingPriceException e) {
					
					//add order back to OrderBook if Trade failed
					try {
						orderBook.add(counterOrder);
					} catch (IllegalOrderException e1) {
						
						//is not possible to happen
						log.error("unable to place Order");
						e1.printStackTrace();
					}
					log.error("unable to place Order");
					e.printStackTrace();
					return;
				}
				//add trade to history
				orderBook.getTradeHistory().addTrade(trade);
			}
		
		else
		{
			log.debug("orderBook is empty");
			try {
				orderBook.add(order);
			} catch (IllegalOrderException e) {
				// not possible to happen
				e.printStackTrace();
			}
		}
		
		//add rest order to the Orderbook
		if(restOrder!= null)
		{
			this.placeOrder(restOrder);
		}
	}


	/**
	 * this will return you the last executed trade and from the trade you can get the
	 * price
	 */
	@Override
	public Trade getLastTrade(CurrencyPair pair) {
		
		return orderBookMap.get(pair.toString()).getTradeHistory().getLastTrade();
	}


	@Override
	public List<CurrencyPair> getAvailableMarkets() {
		
		ArrayList<CurrencyPair> list = new ArrayList<CurrencyPair>();
		
		Iterator<String> keys = keySet.iterator();
		while (keys.hasNext()) {
			
			list.add(orderBookMap.get(keys.next()).getCurrencyPair());
		}
		return list;
	}
	
	/**
	 * will create a new tradeable Market in the TradeEngine
	 */
	
	@Override
	public void createMarket(CurrencyPair pair) {
		
		//check if already existing
		if(orderBookMap.get(pair.toString()) == null)
		{
		OrderBook newMarket = new OrderBookArrayList(pair);
		orderBookMap.put(pair.toString(), newMarket);
		
		keySet.add(pair.toString());
		
		log.info("Market: " + pair.toString() + " created");
		
		}
		else
		{
			log.info("Market: " + pair.toString() + " is already existing");
		}
		
		
	}


	@Override
	public void removeMarket(CurrencyPair pair)
			throws MarketNotAvailableException {
		
		if(keySet.isEmpty() || orderBookMap.get(pair.toString()) == null)
		{
			throw new MarketNotAvailableException(pair);
		}
		else
		{
			keySet.remove(pair.toString());
			orderBookMap.remove(pair.toString());
			
			log.trace(pair.toString() + " sucsessfully removed from TradeEngine");
		}
		
		
		
	}
	

}

	