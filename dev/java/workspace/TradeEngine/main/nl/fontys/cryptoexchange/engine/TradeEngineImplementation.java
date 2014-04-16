package nl.fontys.cryptoexchange.engine;

import java.util.Arrays;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import org.apache.log4j.Logger;
import org.json.JSONArray;
import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;
import nl.fontys.cryptoexchange.core.Trade;

/**
 * has a stack of threads and is doing the management of the TradeAgents
 * @author Ratidzo Zvirawa, Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 15:53:09
 */
public class TradeEngineImplementation implements TradingEngine {

	/**
	 * collection of ask orders
	 */
	private AskOrderBook askOrderBook;
	/**
	 * This is a collection of the bidOrders
	 */
	private BidOrderBook bidOrderBook;
	
	private OrderBook marketDephtOrderBook;
	
	
	private Trade trade;
	
	private TemporaryTradeHistory temporaryTradeHistory;
	
	private Logger log = Logger.getLogger(TradeEngineImplementation.class);


	public TradeEngineImplementation(){

	}

	/**
	 * Returns the users pending orders as an Iterator
	 */
	@Override
	public Iterator<Order> getPendingOrdersByUserId(long userId) {
		Order cancelOrder;
		Iterator<Order> iteratorBid = bidOrderBook.list.iterator();
		Iterator<Order> iteratorAsk = askOrderBook.list.iterator();
		while(iteratorBid.hasNext()){
			cancelOrder = iteratorBid.next();
			if(cancelOrder.getUserId() == userId){
				marketDephtOrderBook.add(iteratorBid.next());
			}
			while(iteratorAsk.hasNext()){
				cancelOrder = iteratorAsk.next();
				if(cancelOrder.getUserId() == userId){
					marketDephtOrderBook.add(iteratorAsk.next());
			}
			}
			}
			Iterator<Order> iteratorMarketDepth = marketDephtOrderBook.list.iterator();
				
			return iteratorMarketDepth;	
	}
	

	/**
	 * Returns the Bid market depth as a JSONObject
	 */
	@Override
	public Iterator<Order> getBidDepth() {
		Iterator<Order> iterator = bidOrderBook.list.iterator();
		return iterator;
	}

	/**
	 * Returns the Ask market depth as an iterator
	 */
	@Override
	public Iterator<Order> getAskDepth() {
		Iterator<Order> iterator = askOrderBook.list.iterator();
		return iterator;
	}

	/**
	 * Cancels order and returns a boolean of true if successful
	 */
	@Override
	public boolean cancelOrderByOrder(Order order) {
		Order cancelOrder;
		if(order.getType() == OrderType.ASK){
			Iterator<Order> iterator = askOrderBook.list.iterator();
			while(iterator.hasNext()){
				cancelOrder = iterator.next();
				if(order == cancelOrder){
					iterator.remove();
					return true;
				}
			}
		}
		else if(order.getType() == OrderType.BID){
			
			Iterator<Order> iterator = bidOrderBook.list.iterator();
			while(iterator.hasNext()){
				cancelOrder = iterator.next();
				if(order == cancelOrder){
					iterator.remove();
					return true;
				}
				
			}
			
		}
			
		// TODO Auto-generated method stub
		return false;
	}

	/**
	 * Returns the Ask market depth as a JSONObject
	 */
	@Override
	public JSONObject getAskDepthAsJSON() {

		JSONArray askDepthJSONArray = new JSONArray(Arrays.asList(askOrderBook.list));
		JSONObject askDepthJSON = new JSONObject(askDepthJSONArray);
		
		return askDepthJSON;
	}
	
	
	/**
	 * Returns the Bid market depth as a JSONObject
	 */
	@Override
	public JSONObject getBidDEpthAsJSON() {
		JSONArray bidDepthJSONArray = new JSONArray(Arrays.asList(bidOrderBook));
		JSONObject bidDepthJSON = new JSONObject(bidDepthJSONArray);
		
		return bidDepthJSON;
	}
	/**
	 * Place an order into the order book
	 */
	@Override
	public void placeOrder(Order order) {
	try{
		if(order.getType() == OrderType.ASK){
			askOrderBook.add(order);
			log.trace("New AskOrder added. Order is " + order.toString());
		}
		else{
			bidOrderBook.add(order);
			log.trace("New BOdOrder added. Order is " + order.toString());
		}
		
	}
	catch(NullPointerException e){}
	}
	
	
	/*
	 * Cancels orders by OrderId and returns true if successful
	 */
	@Override
	public boolean cancelOrderById(long orderId) {
		try{
			int val = 0;
			Order cancelOrder;
			Iterator<Order> iterator = bidOrderBook.list.iterator();
			while(iterator.hasNext()){
				cancelOrder = iterator.next();
				if(cancelOrder.getId() == orderId){
					iterator.remove();
					log.trace("bid Order removed at " + val);
					return true;
				}
				val++;
			}
			Iterator<Order> iteratorAsk = askOrderBook.list.iterator();
			val = 0;
			while(iteratorAsk.hasNext()){
				cancelOrder = iteratorAsk.next();
				if(cancelOrder.getId() == orderId){
					iteratorAsk.remove();
					log.trace("bid Order removed at " + val);
					return true;
				}
				val++;
			}
			return false;
			
		}
		catch(Exception e){
			
		}
		return false;
	}

	@Override
	public Trade getLastTrade() {
			trade = temporaryTradeHistory.getLastTrade();
			return trade;
	}
	
	/*
	 * Gets the orders in the Bid and Ask order books and returns them to the user
	 */
	@Override
	public Iterator<Order> getMarketDepth() {
		Iterator<Order> iteratorBid = bidOrderBook.list.iterator();
		Iterator<Order> iteratorAsk = bidOrderBook.list.iterator();
		while(iteratorBid.hasNext()){
			marketDephtOrderBook.add(iteratorBid.next());
		}
		while(iteratorAsk.hasNext()){
			marketDephtOrderBook.add(iteratorAsk.next());
		}
		Iterator<Order> iteratorMarketDepth = marketDephtOrderBook.list.iterator();
		
		return iteratorMarketDepth;
	}
}//end TradeEngineImplementation