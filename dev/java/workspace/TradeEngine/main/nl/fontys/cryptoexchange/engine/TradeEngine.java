package nl.fontys.cryptoexchange.engine;

import java.util.Iterator;
import java.util.List;

import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;

/**
 * This is the interface to witch is visible for the other components
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 22-Apr-2014 18:41:23
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

	public List<CurrencyPair> getAvailableMarkets();

	/**
	 * 
	 * @param pair
	 */
	public void createMarket(CurrencyPair pair);


}