package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.*;
import nl.fontys.cryptoexchange.core.OrderType;

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

	private OrderBook bidOrderBook;
	
	private OrderBook askOrderBook;
	
	 @Before
	  public void setUp() throws Exception {

		bidOrderBook = new BidOrderBook();
		askOrderBook = new AskOrderBook();
		
			

	  }
	
	
	

	@Test
	public void test() {
	}

}