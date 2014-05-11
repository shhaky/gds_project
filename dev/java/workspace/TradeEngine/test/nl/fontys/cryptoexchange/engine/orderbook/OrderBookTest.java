package nl.fontys.cryptoexchange.engine.orderbook;




import static org.junit.Assert.assertEquals;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.exception.IllegalOrderException;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;

import org.junit.Before;
import org.junit.Test;


/**
 * 
 * @author Tobias Zobrist
 * 
 * will test the class nl.fontys.cyrptoexchange.engine.OrderBook
 *
 */
public class OrderBookTest {

	private OrderBook orderbook;
	
	
	@Before
	public void setUp()
	{
		this.orderbook = new OrderBookArrayList(OrderTest.ORDER_BUY_HIGH_USER1.getCurrencyPair());
		
	}
	


	@Test
	public void testAddOrders() throws IllegalOrderException {
		
		//7 BUY AND 6 SELL ORDERS
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
		
		assertEquals(7,orderbook.getBidOrderLength());
		assertEquals(6, orderbook.getAskOrderLength());
		
	}
	
	@Test
	public void testGetBestBidOrder() throws IllegalOrderException
	{
		orderbook.add(OrderTest.ORDER_BUY_HIGH_USER1);
		orderbook.add(OrderTest.ORDER_BUY_LOW_USER1);
		
		assertEquals(OrderTest.PRICE_LOW, orderbook.getBestBidOffer().getPrice().intValue());
	}
	@Test
	public void testGetBestAskOrder() throws IllegalOrderException
	{
		orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		orderbook.add(OrderTest.ORDER_SELL_LOW_USER1);
		
		assertEquals(OrderTest.PRICE_HIGH, orderbook.getBestAskOffer().getPrice().intValue());
	}

}
