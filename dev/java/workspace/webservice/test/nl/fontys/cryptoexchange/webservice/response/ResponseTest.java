package nl.fontys.cryptoexchange.webservice.response;

import static org.junit.Assert.*;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.TradeTest;

import org.junit.Test;

public class ResponseTest {
	@Test
	public void testGetAttatchment()
	{
		Response<Order> response = new Response<Order>(OrderTest.ORDER_BUY_HIGH_USER2);
		assertEquals(OrderTest.ORDER_BUY_HIGH_USER2, response.getAttachment());
	}

	
	@Test
	public void testGetAttatchmentType()
	{
		Response<Order> responseOrder = new Response<Order>(OrderTest.ORDER_BUY_HIGH_USER2);
		
		Response<Trade> responseTrade = new Response<Trade>(TradeTest.getTradeBuy());
		
		
		assertEquals("BuyOrder", responseOrder.getAttatchmentType());
		assertEquals("Trade", responseTrade.getAttatchmentType());
		
	}
	
	
}
