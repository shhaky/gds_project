package nl.fontys.cryptoexchange.engine;

import java.util.List;



import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.engine.exception.UnableToDeleteOrderException;

/**
 * This is the interface to witch is visible for the other components
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 22-Apr-2014 18:41:23
 */
public interface TradeEngine {

	/**
	 * @param userId
	 */
	public List<Order> getPendingOrdersByUserId(long userId);

	public List<Order> getBidDepth(CurrencyPair pair) throws MarketNotAvailableException;

	public List<Order> getAskDepth(CurrencyPair pair) throws MarketNotAvailableException;
	
	public List<Order> getBidDepth(String pair) throws MarketNotAvailableException;

	public List<Order> getAskDepth(String pair) throws MarketNotAvailableException;
	
	public String getAskDepthAsJSON(String market) throws MarketNotAvailableException;

	public String getBidDepthAsJSON(String market) throws MarketNotAvailableException;
	
	public String getAskDepthAsJSON(CurrencyPair market) throws MarketNotAvailableException;

	public String getBidDepthAsJSON(CurrencyPair market) throws MarketNotAvailableException;

	public void cancelOrderByOrderId(long orderId) throws UnableToDeleteOrderException;


	public void cancelOrderByOrder(Order order) throws UnableToDeleteOrderException;



	/**
	 * @param order
	 *            the order to place
	 * 
	 * @return the order ID
	 * @throws MarketNotAvailableException
	 * 
	 */
	
	
	public long placeOrder(Order order) throws MarketNotAvailableException;

	/**
	 * this will return you the last executed trade and from the trade you can get
	 * the price
	 */
	public Trade getLastTrade(CurrencyPair pair);

	public List<CurrencyPair> getMarkets();

	/**
	 * will create a new Market to trade in,
	 * 
	 * @param pair
	 *          the Currency Pair you can trade in this market, for instance
	 *          LTC/BTC
	 */
	public void createMarket(CurrencyPair pair) throws InvalidCurrencyPairException;
	/**
	 * will create a new Market to trade in,
	 * 
	 * @param pair
	 *          the Currency Pair you can trade in this market, for instance
	 *          LTC/BTC
	 * @throws InvalidCurrencyPairException 
	 */
	public void createMarket(String pair) throws InvalidCurrencyPairException;

	/**
	 * will remove an existing Market to trade in
	 * 
	 * @exception if
	 *              the Market to remove does not exist it will throw a
	 *              MarketNotAvailableExeption
	 * @param pair
	 */

	public void removeMarket(CurrencyPair pair) throws MarketNotAvailableException;
	/**
	 * will remove an existing Market to trade in
	 * 
	 * @exception if
	 *              the Market to remove does not exist it will throw a
	 *              MarketNotAvailableExeption
	 * @param pair
	 */
	public void removeMarket(String pair) throws MarketNotAvailableException;
	public String getVersion();

}