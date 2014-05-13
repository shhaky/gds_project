package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.*;
import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;

import org.junit.Before;
import org.junit.Test;


/**
 * 
 * Tests for TradeEngine
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 22-Apr-2014 18:41:23
 */


public class TradeEngineTest {

	private TradeEngine engine;
	
	
	
	@Before
	public void setUp()
	{
		engine = new TradeEngineManualUpdating();
		
	}
	
	
	@Test
	public void testCreateMarket()
	{
		engine.createMarket(CurrencyPair.ZET_BTC);
		
		assertEquals(CurrencyPair.ZET_BTC, engine.getAvailableMarkets().get(0));
		}
	
	
	@Test
	public void testRemoveMarket()
	{
		engine.createMarket(CurrencyPair.ZET_BTC);
		engine.createMarket(CurrencyPair.LTC_BTC);
		engine.createMarket(CurrencyPair.DOGE_BTC);
		
		try {
			engine.removeMarket(CurrencyPair.ZET_BTC);
			engine.removeMarket(CurrencyPair.LTC_BTC);
			engine.removeMarket(CurrencyPair.DOGE_BTC);
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
		
		
		//if all markets have been removed again
		assertEquals(true, engine.getAvailableMarkets().isEmpty());
		
	}
	
	
	//test if MarketNotAvailableExeption is thrown
	@Test
	public void testRemoveNonExistingMarket()
	{
		try {
			engine.removeMarket(CurrencyPair.ZET_BTC);
			fail();
		} catch (MarketNotAvailableException e) {
			assertTrue(true);
		}
	}
	
	
	
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
	public void testGetBidDepthAsJSON() throws MarketNotAvailableException
	{
		
		final String expected = "[{\"price\":";
		
		CurrencyPair market = CurrencyPair.LTC_BTC;
		engine.createMarket(market);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER1);
		engine.placeOrder(OrderTest.ORDER_BUY_LOW_USER1);
		
		String result = engine.getBidDepthAsJSON(market);
		// I can't compare the whole String because of the Date
		assertTrue(result.startsWith(expected));
		
	}
	
	@Test
	public void testGetAskDepthAsJSON() throws MarketNotAvailableException
	{
		
		final String expected = "[{\"price\":";
		
		CurrencyPair market = CurrencyPair.LTC_BTC;
		engine.createMarket(market);
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		engine.placeOrder(OrderTest.ORDER_SELL_LOW_USER1);
		
		String result = engine.getAskDepthAsJSON(market);
		// I can't compare the whole String because of the Date
		assertTrue(result.startsWith(expected));
		
	}
	
	
	
	@Test
	public void testOrderExecutionWithMatchingOrdersAndSameVolume() {
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		//engine.createMarket(CurrencyPair.DOGE_BTC);
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		
		try {
			//if the asks and bid list size is 0 then both orders have been matched and a trade happened
			assertEquals(0, engine.getAskDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
			assertEquals(0, engine.getBidDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	@Test
	public void testOrderExecutionWithMatchingOrdersButDifferentVolume() {
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		//create other market to make it more interesting
		engine.createMarket(CurrencyPair.DOGE_BTC);
		
		engine.placeOrder(OrderTest.ORDER_SELL_LOW_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		try {
					//@Expected rest order volume = bigger volume - lower volume
					assertEquals(OrderTest.ORDER_BUY_HIGH_USER2.getVolume().subtract(OrderTest.ORDER_SELL_LOW_USER1.getVolume()), 
					
					//@Actual the rest orders volume in the Bid list
					engine.getBidDepth(OrderTest.ORDER_SELL_HIGH_USER1.getCurrencyPair()).get(0).getVolume());
					
					//compare also the price of the offer
					assertEquals(OrderTest.ORDER_BUY_HIGH_USER2.getPrice(),engine.getBidDepth(OrderTest.ORDER_SELL_HIGH_USER1.getCurrencyPair()).get(0).getPrice() );
					
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}


	@Test
	public void testAddTwoNonMatchingOrdersOfTheSameMarket()
	{
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		engine.placeOrder(OrderTest.ORDER_BUY_LOW_USER1);
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER2);
		
		try {
			//if the asks and bid list size is 1 then both orders are still in the Orderbook
			assertEquals(1, engine.getAskDepth(CurrencyPair.LTC_BTC).size());
			assertEquals(1, engine.getBidDepth(CurrencyPair.LTC_BTC).size());
			
			//If there is no Last Trade then there was no trade
			assertEquals(null,engine.getLastTrade(CurrencyPair.LTC_BTC));
		
		
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	@Test
	public void testAddTwoMatchingOrdersOfDifferentMarkets()
	{
		
			engine.createMarket(CurrencyPair.LTC_BTC);
			engine.createMarket(CurrencyPair.DOGE_BTC);
		
			engine.placeOrder(OrderTest.ORDER_BUY_OTHER_CURRECNY_USER1);
			
			engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER2);
			
			try {
				assertEquals(1, engine.getAskDepth(CurrencyPair.LTC_BTC).size());
				assertEquals(1, engine.getBidDepth(CurrencyPair.DOGE_BTC).size());
				assertEquals(0, engine.getAskDepth(CurrencyPair.DOGE_BTC).size());
				assertEquals(0, engine.getBidDepth(CurrencyPair.LTC_BTC).size());
				
				//If there is no Last Trade then there was no trade
				assertEquals(null,engine.getLastTrade(CurrencyPair.LTC_BTC));
			
			
			} catch (MarketNotAvailableException e) {
				e.printStackTrace();
				fail();
			}

}
	@Test
	public void testAddManyOrdersSameVolume() {
		int orders = 2000;
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		engine.createMarket(CurrencyPair.DOGE_BTC);
		
		for(int i = 0; i< orders; i++ )
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		for(int i = 0; i< orders; i++ )
			engine.placeOrder(OrderTest.ORDER_BUY_OTHER_CURRECNY_USER1);
		
		for(int i = 0; i< orders; i++ )
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		
		try {
			//if the asks and bid list size is 0 then both orders have been matched and a trade happened
			assertEquals(0, engine.getAskDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
			assertEquals(0, engine.getBidDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
		
			assertEquals(orders, engine.getBidDepth(OrderTest.ORDER_BUY_OTHER_CURRECNY_USER1.getCurrencyPair()).size());
			
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
	
	@Test
	public void testAddManyOrdersDifferentVolume() {
		int orders = 2000;
		
		engine.createMarket(CurrencyPair.LTC_BTC);
		
		engine.createMarket(CurrencyPair.DOGE_BTC);
		
		for(int i = 0; i< orders; i++ )
		{
		engine.placeOrder(OrderTest.ORDER_SELL_LOW_USER1);
		engine.placeOrder(OrderTest.ORDER_SELL_LOW_USER1);
		}
		for(int i = 0; i< orders; i++ )
		{
			engine.placeOrder(OrderTest.ORDER_BUY_OTHER_CURRECNY_USER1);
		}
		for(int i = 0; i< orders; i++ )
		{
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		}
		try {
			
			//if the asks and bid list size is 0 then both orders have been matched and a trade happened
			assertEquals(0, engine.getAskDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
			assertEquals(0, engine.getBidDepth(OrderTest.ORDER_BUY_HIGH_USER2.getCurrencyPair()).size());
		
			assertEquals(orders, engine.getBidDepth(OrderTest.ORDER_BUY_OTHER_CURRECNY_USER1.getCurrencyPair()).size());
			
		} catch (MarketNotAvailableException e) {
			e.printStackTrace();
			fail();
		}
	}
}


	
