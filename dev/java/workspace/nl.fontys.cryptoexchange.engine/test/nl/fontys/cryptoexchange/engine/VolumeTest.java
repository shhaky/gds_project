package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.*;

import java.util.ArrayList;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.TradeTest;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderException;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;

import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;
/**
 * 
 * @author Ratidzo Zvirawa
 *
 */
public class VolumeTest {

	private static int NUMBER_OF_TRADES_STORED = 200;
	private TemporaryTradeHistory history;
	private MovingAverageCalculation movingAverage;
	private OrderBookArrayList orderBookArrayList;
	private OrderBookArrayList orderbook;
	private ArrayList<MovingAverage> movingAverages;
	private Volume volumeCalculation;
	private double volume;

	
	
	
	@Before
	public void setUp()
	{
		this.orderbook = new OrderBookArrayList(CurrencyPair.LTC_BTC);
		
		createTrades();
		
	}
	
	
	public void createTrades()
	{
		try {
			this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER1);
		
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER1);
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER1);
		this.orderbook.add(OrderTest.ORDER_SELL_LOW_USER2);
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		this.orderbook.add(OrderTest.ORDER_SELL_LOW_USER2);
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		} catch (IllegalOrderException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		Trade trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		
		
		
	}
	
	@Ignore
	@Test
	public void testGetMovingAverage() {
		
		volumeCalculation = new Volume(orderbook, 1);
		volume =  volumeCalculation.getVolume();
		assertNotNull(volume);
		
		
		
	}

}
