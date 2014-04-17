package nl.fontys.cryptoexchange.engine;




import nl.fontys.cryptoexchange.core.OrderTest;
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
		this.orderbook = new OrderBookArrayList();
	}
	


	@Test
	public void testAddOrders() {
		
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER_1);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER2);
		
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER_2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		
		this.orderbook.add(OrderTest.ORDER_BUY_HIGH_USER_2);
		this.orderbook.add(OrderTest.ORDER_SELL_HIGH_USER1);
		
		System.out.println(orderbook);
		
		
	}

}
