package nl.fontys.cryptoexchange.engine;

import java.util.List;

import org.json.JSONObject;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.engine.exception.UnableToDeleteOrderException;

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
	public List<Order> getPendingOrdersByUserId(long userId);

	public List<Order> getBidDepth(CurrencyPair pair) throws MarketNotAvailableException;

	public List<Order> getAskDepth(CurrencyPair pair) throws MarketNotAvailableException;

	public void cancelOrderByOrderId(long orderId) throws UnableToDeleteOrderException;

	/**
	 * 
	 * @param order
	 */
	public void cancelOrderByOrder(Order order) throws UnableToDeleteOrderException;

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
	public Trade getLastTrade(CurrencyPair pair);

	public List<CurrencyPair> getAvailableMarkets();

	/**
	 * 
	 * @param pair
	 */
	public void createMarket(CurrencyPair pair);


}