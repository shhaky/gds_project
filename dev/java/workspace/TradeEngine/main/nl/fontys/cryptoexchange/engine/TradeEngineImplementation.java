package nl.fontys.cryptoexchange.engine;

import java.util.Iterator;

import org.json.JSONArray;
import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;

/**
 * has a stack of threads and is doing the management of the TradeAgents
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 17:54:54
 */
public class TradeEngineImplementation implements TradingEngine {

	/**
	 * collection of ask orders
	 */
	private OrderList askOrderBook;
	/**
	 * This is a collection of the bidOrders
	 */
	private OrderList bidOrderBook;
	
	private TemporaryTradeHistory temporaryTradeHistory;
	/**
	 * This is a collection of the bidOrders
	 */
	private OrderBook orderBook;

	public TradeEngineImplementation(){

	}

	@Override
	public Iterator<Order> getPendingOrdersByUserId(long userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Iterator<Order> getBidDepth() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Iterator<Order> getAskDepth() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean cancelOrderByOrder(Order order) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public JSONObject getAskDepthAsJSON() {

		/**
		 * example
		 
		JSONArray array = new JSONArray(collection)
		
		JSONObject object = new JSONObject(array);
		
		object.toString();
		*/
		return null;
	}

	@Override
	public JSONObject getBidDEpthAsJSON() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void placeOrder(Order order) {

		
		
		
		
		
	}

	@Override
	public boolean cancelOrderById(long orderId) {
		// TODO Auto-generated method stub
		return false;
	}

	/**
	 * this will return you the last executed trade and from the trade you can get the
	 * price
	 */
	@Override
	public Trade getLastTrade() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Iterator<Order> getMarketDepth() {
		// TODO Auto-generated method stub
		return null;
	}
}//end TradeEngineImplementation