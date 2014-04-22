package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.*;


import nl.fontys.cryptoexchange.core.OrderTest;

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
	public void testAddBidOrder() {
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER1);
		
		assertEquals(OrderTest.ORDER_BUY_HIGH_USER1, engine.getBidDepth().next());
	}
	
	@Test
	public void testAddAskOrder() {
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		assertEquals(OrderTest.ORDER_SELL_HIGH_USER1, engine.getAskDepth().next());
	}
	
	@Test
	public void testOrderExecutionWithMatchingOrders() {
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_HIGH_USER2);
		
		assertEquals(false, engine.getAskDepth().hasNext());
		assertEquals(false, engine.getBidDepth().hasNext());
	}
	
	//@Test
	public void testOrderExecutionWithMatchingOrdersButDifferentVolume() {
		
		engine.placeOrder(OrderTest.ORDER_SELL_HIGH_USER1);
		
		engine.placeOrder(OrderTest.ORDER_BUY_LOW_USER2);
		
		//System.err.println(engine.getAskDepth().next());
		
		//System.err.println(engine.getBidDepth().next());
		
		
		assertEquals(false, engine.getAskDepth().hasNext());
	}

}


	
