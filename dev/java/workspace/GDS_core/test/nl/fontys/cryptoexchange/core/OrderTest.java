package nl.fontys.cryptoexchange.core;

import static org.junit.Assert.*;

import java.math.BigDecimal;

import nl.fontys.cryptoexchange.core.exception.IllegalOrderCloneExeption;

import org.junit.Before;
import org.junit.Test;

public class OrderTest {
	
	/**
	 * 
	 * @author Tobias Zobrist
	 * @version 1.0
	 * @created 16-Apr-2014 16:18:14
	 * 
	 *
	 * provides some Test Orders
	 */
	
	//test values
	public final static long USER1_ID = 33333;
	
	public final static long USER2_ID = 44444;
	
	
	
	public static final int LOW_VOLUME = 25;
	public static final int HIGH_VOLUME = 2*LOW_VOLUME;
	
	public static final int PRICE_HIGH = 50;

	public static final int PRICE_LOW = 10;
	//User 1
	public final static Order ORDER_BUY_LOW_USER1 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(PRICE_LOW),USER1_ID);
	public final static Order ORDER_BUY_HIGH_USER1 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER1_ID);
	
	public final static Order ORDER_SELL_LOW_USER1 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(PRICE_LOW),USER1_ID);
	public final static Order ORDER_SELL_HIGH_USER1 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(),  new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER1_ID);
	
	public final static Order ORDER_BUY_OTHER_CURRECNY_USER1 = new BuyOrder(CurrencyPair.DOGE_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER1_ID);
	//User2
	public final static Order ORDER_BUY_LOW_USER2 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(PRICE_LOW),USER2_ID);
	public final static Order ORDER_BUY_HIGH_USER2 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER2_ID);
	
	public final static Order ORDER_SELL_LOW_USER2 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(PRICE_LOW),USER2_ID);
	public final static Order ORDER_SELL_HIGH_USER2 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(),  new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER2_ID);
	
	public final static Order ORDER_BUY_OTHER_CURRECNY_USER2 = new BuyOrder(CurrencyPair.DOGE_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(PRICE_HIGH),USER2_ID);

	
	@Before
	public void setUp()
	{
		
	}
	
	/**
	 * this test will test the comparability of Orders, they actually have to be comparable by price.
	 * 
	 * when 2 Orders have the same price
	 */
	@Test
	public void testComparabilityWith2SamePriceOrders()
	{
		assertEquals(0, ORDER_BUY_HIGH_USER1.compareTo(ORDER_BUY_HIGH_USER2));
	}
	
	
	/**
	 * this test will test the comparability of Orders, they actually have to be comparable by price.
	 * 
	 * when Order1 has a lower price that the compareTo Order
	 */
	@Test
	public void testComparabilityWithLowerOrder()
	{
		assertEquals(-1, ORDER_BUY_LOW_USER1.compareTo(ORDER_BUY_HIGH_USER2));
	}
	/**
	 * this test will test the comparability of Orders, they actually have to be comparable by price.
	 * 
	 * when Order1 has a lower price that the compareTo Order
	 */
	@Test
	public void testComparabilityWithHigherOrder()
	{
		assertEquals(1, ORDER_BUY_HIGH_USER1.compareTo(ORDER_BUY_LOW_USER2));
	}
	
	/**
	 * will create the rest order of 2 Orders with the same volume, there will not be any rest order --> null 
	 */
	@Test
	public void testRestOrderSameVolume()
	{
		try {
			assertEquals(null,Order.cloneRestOrder(ORDER_BUY_HIGH_USER1, ORDER_SELL_HIGH_USER2));
		} catch (IllegalOrderCloneExeption e) {
			e.printStackTrace();
			fail();
		}
	}
	
	
	@Test
	public void testRestOrderSellHighBuyLow()
	{
		
		Order expected = new SellOrder(	ORDER_SELL_HIGH_USER2.getCurrencyPair(),
										ORDER_SELL_HIGH_USER2.getOrderId() , 
										ORDER_SELL_HIGH_USER2.getVolume().subtract(ORDER_BUY_LOW_USER1.getVolume()), 
										ORDER_SELL_HIGH_USER2.getPrice(), 
										ORDER_SELL_HIGH_USER2.getUserId());
		
		Order actual = null;
		try {
			actual = Order.cloneRestOrder(ORDER_BUY_LOW_USER1, ORDER_SELL_HIGH_USER2);
		} catch (IllegalOrderCloneExeption e) {
			e.printStackTrace();
			fail();
		}
		
		
		//cant use equals because Timestamp will be different
				assertEquals(expected.getType(),actual.getType());
				
				assertEquals(expected.getVolume(),actual.getVolume());
				
				assertEquals(expected.getPrice(),actual.getPrice());
				
				assertEquals(expected.getOrderId(),actual.getOrderId());
	}
	
	/**
	 * will create the rest order of 2 Orders with the same volume, there will not be any rest order --> null 
	 */
	@Test
	public void testRestOrderSellLowBuyHigh()
	{
		
		Order expected = new BuyOrder(	ORDER_BUY_HIGH_USER1.getCurrencyPair(),
										ORDER_BUY_HIGH_USER1.getOrderId() , 
										ORDER_BUY_HIGH_USER1.getVolume().subtract(ORDER_SELL_LOW_USER2.getVolume()), 
										ORDER_BUY_HIGH_USER1.getPrice(), 
										ORDER_BUY_HIGH_USER1.getUserId());
		
		
		
		Order actual = null;
		try {
			actual = Order.cloneRestOrder(ORDER_BUY_HIGH_USER1, ORDER_SELL_LOW_USER2);
		} catch (IllegalOrderCloneExeption e) {
			e.printStackTrace();
			fail();
		}
		
		
		//cant use equals because Timestamp will be different
		assertEquals(expected.getType(),actual.getType());
		
		assertEquals(expected.getVolume(),actual.getVolume());
		
		assertEquals(expected.getPrice(),actual.getPrice());
		
		assertEquals(expected.getOrderId(),actual.getOrderId());
	}
	
	/**
	 * should cause an IllegalOrderCloneException
	 */
	@Test
	public void testCloneOrderWithNonMatchingCurrencies()
	{
		
		try {
			Order.cloneRestOrder(ORDER_BUY_HIGH_USER1, ORDER_BUY_OTHER_CURRECNY_USER2);
			fail();
		} catch (IllegalOrderCloneExeption e) {
			
			assertTrue(true);
		}
		
	}
	
	
	
	
}

