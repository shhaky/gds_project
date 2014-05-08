package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.*;
import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;

import org.junit.Before;
import org.junit.Test;

public class TradeEngineTest {

	private TradeEngine engine;
	
	
	@Before
	public void setUp()
	{
		engine = new TradeEngineImplementation();
		
	}
	
	
	@Test
	public void testCreateMarket()
	{
		engine.createMarket(CurrencyPair.ZET_BTC);
		
		assertEquals(CurrencyPair.ZET_BTC, engine.getAvailableMarkets().get(0));}
	
	@Test
	public void testAddBidOrder() {
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER1);
		
		try {
			assertEquals(
					OrderTest.ORDER_BUY_HIGH_USER1, 
					engine.getBidDepth(OrderTest.ORDER_BUY_HIGH_USER1.getCurrencyPair()).get(0));
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	@Test
	public void testAddAskOrder() {
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		try {
			assertEquals(OrderTest.ORDER_SELL_HIGH_USER1, engine.getAskDepth(OrderTest.ORDER_SELL_HIGH_USER1.getCurrencyPair()).get(0));
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	@Test
	public void testOrderExecutionWithMatchingOrders() {
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		engine.createMarket(CurrencyPair.DOGE_BTC);
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		
		try {
			assertEquals(false, engine.getAskDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).get(0));
			assertEquals(false, engine.getBidDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).get(0));
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	//@Test
	public void testOrderExecutionWithMatchingOrdersButDifferentVolume() {
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_LOW_USER2);
		
		//System.err.println(engine.getAskDepth().next());
		
		//System.err.println(engine.getBidDepth().next());
		
		
		try {
			assertEquals(false, engine.getAskDepth(OrderTest.ORDER_SELL_HIGH_USER1.getCurrencyPair()).get(0));
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}

}


	
