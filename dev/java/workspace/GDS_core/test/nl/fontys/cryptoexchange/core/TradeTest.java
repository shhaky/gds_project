package nl.fontys.cryptoexchange.core;

import static org.junit.Assert.*;


import nl.fontys.cryptoexchange.core.exception.IllegalTradeExeption;
import nl.fontys.cryptoexchange.core.exception.NoMatchingPriceExeption;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;


/**
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:18:14
 * 
 * 
 * This Case will thest the class Trade
 * 
 */
public class TradeTest {

	private Trade trade;
	
	
	private Logger log = Logger.getLogger(TradeTest.class);
	
	
	
	@Before
	public void setUp()
	{
		
	
	}
	
	@Test
	public void testConstructorBuyOrderInMarket() {
		
		try {
			trade = new Trade(OrderTest.ORDER_BUY_HIGH_USER_1,OrderTest.ORDER_SELL_LOW_USER2);
		} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
			
			e.printStackTrace();
		}
		
		log.info(trade);
		
		assertEquals(OrderTest.LOW_VOLUME, trade.getVolume().toBigInteger().intValue());
		assertEquals(OrderType.BUY, trade.getType());
		
	}
	
	
	@Test
	public void testConstructorSellOrderInMarket() {
		
		try {
			trade = new Trade(OrderTest.ORDER_SELL_LOW_USER1,OrderTest.ORDER_BUY_HIGH_USER_2);
		} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
			
			e.printStackTrace();
		}
		
		log.info(trade);;
		
		assertEquals(OrderTest.LOW_VOLUME, trade.getVolume().toBigInteger().intValue());
		assertEquals(OrderType.SELL, trade.getType());
		
	}
	
	@Test
	public void testIllegalTradeWrongCurrencyPair() {
		
		try {
			trade = new Trade(OrderTest.ORDER_SELL_LOW_USER1,OrderTest.ORDER_BUY_OTHER_CURRECNY_USER2);
		} catch (IllegalTradeExeption e) {
			assertTrue(true);
		} catch (NoMatchingPriceExeption e) {
			e.printStackTrace();
			assertTrue(false);
		}
		
	}
	
	@Test
	public void testIllegalTradeNoMatchingPricesSell() {
		
		try {
			trade = new Trade(OrderTest.ORDER_SELL_HIGH_USER1,OrderTest.ORDER_BUY_LOW_USER_2);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}
	
	@Test
	public void testIllegalTradeNoMatchingPricesBuy() {
		
		try {
			trade = new Trade(OrderTest.ORDER_BUY_LOW_USER_1,OrderTest.ORDER_SELL_HIGH_USER2);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}	catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}
	
	@Test
	public void testIllegalOrders2BuyOrders() {
		
		try {
			trade = new Trade(OrderTest.ORDER_BUY_LOW_USER_1,OrderTest.ORDER_BUY_HIGH_USER_2);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}	catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}
	
	@Test
	public void testIllegalOrders2SellOrders() {
		
		try {
			trade = new Trade(OrderTest.ORDER_SELL_HIGH_USER1,OrderTest.ORDER_SELL_LOW_USER2);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}	catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}

}
