package nl.fontys.cryptoexchange.engine;

import java.util.Iterator;

import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;

/**
 * This is the interface to witch is visible for the other components
 * @author Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 15:53:19
 */
public interface TradeEngine {

	/**
	 * 
	 * @param userId
	 */
	public Iterator<Order> getPendingOrdersByUserId(long userId);

	public Iterator<Order> getBidDepth();

	public Iterator<Order> getAskDepth();

	boolean cancelOrderByOrderId(long orderId);

	/**
	 * 
	 * @param order
	 */
	public boolean cancelOrderByOrder(Order order);

	public JSONObject getAskDepthAsJSON();

	public JSONObject getBidDEpthAsJSON();

	/**
	 * 
	 * @param order
	 */
	public void placeOrder(Order order);

	/**
	 * this will return you the last executed trade and from the trade you can get the
	 * price
	 */
	public Trade getLastTrade();


}