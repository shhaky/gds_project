package nl.fontys.cryptoexchange.engine;
/**
 * TODO Finish test
 */
import static org.junit.Assert.*;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.TradeTest;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;

import org.junit.Before;
import org.junit.Test;

public class MovingAverageCalculationTest {

	private static int NUMBER_OF_TRADES_STORED = 200;
	private TemporaryTradeHistory history;
	
	
	
	@Before
	public void setUp()
	{
		createTrades();
		history = new TemporaryTradeHistory(NUMBER_OF_TRADES_STORED);
		
	}
	
	
	public void createTrades()
	{
		Trade trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeBuy();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		trade = TradeTest.getTradeSell();
		history.addTrade(trade);
		
		
	}
	
	@Test
	public void testGetMovingAverage() {
		fail("create test");
		
		
		
	}

}
