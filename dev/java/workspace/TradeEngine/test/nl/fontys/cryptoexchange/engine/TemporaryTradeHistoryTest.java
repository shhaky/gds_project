package nl.fontys.cryptoexchange.engine;

import static org.junit.Assert.assertEquals;

import java.util.Observable;
import java.util.Observer;

import org.junit.Before;
import org.junit.Test;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.TradeTest;

public class TemporaryTradeHistoryTest {
	
	
	private static int NUMBER_OF_TRADES_STORED = 200;
	
	private TemporaryTradeHistory history;
	@Before
	public void setUp()
	{
		history = new TemporaryTradeHistory(NUMBER_OF_TRADES_STORED);
	}
	
	@Test
	public void testAddTrade()
	{
		Trade trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		
		assertEquals(trade, history.getLastTrade());
	}
	
	
	@Test
	public void testGetLastTrade()
	{
		Trade trade = TradeTest.getTradeBuy();
		Trade tradeLast = TradeTest.getTradeSell();
		history.addTrade(trade);
		history.addTrade(tradeLast);
		
		assertEquals(tradeLast, history.getLastTrade());
	}
	
	
	@Test
	public void testMaxTradeSize()
	{
		Trade trade = TradeTest.getTradeBuy();


		for(int i = 0; i<NUMBER_OF_TRADES_STORED*2; i++)
		{
			history.addTrade(trade);
		}
		
		assertEquals(NUMBER_OF_TRADES_STORED, history.size());
	}
	
	@Test
	public void testObserver()
	{
		Trade trade = TradeTest.getTradeBuy();
		SubscriberTest observer = new SubscriberTest();
		history.addObserver(observer);
		history.addTrade(trade);
		assertEquals(trade.getTradeId(), observer.getTrade().getTradeId());
	}
	

}



/**
 * 
 * @author Tobias Zobrist
 * 
 * A class to test the Subscriber mode of the Tradeengine
 *
 */
class SubscriberTest implements Observer{

	private Trade trade;
	
	@Override
	public void update(Observable arg0, Object pushedTrade) {
		
		this.trade = (Trade) pushedTrade;
	}
	
	public Trade getTrade()
	{
		return this.trade;
	}
}
