package nl.fontys.cryptoexchange.engine;
/**
 * TODO Finish test
 */
import static org.junit.Assert.*;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.TradeTest;
import nl.fontys.cyrptoexchange.engine.marketdata.Average;

import org.junit.Before;
import org.junit.Test;

public class AverageTest {

	private static int NUMBER_OF_TRADES_STORED = 200;
	private TemporaryTradeHistory history;
	private double averageMoving;
	private int volume;
	private Average movingAverage;

	
	
	
	@Before
	public void setUp()
	{
		
		history = new TemporaryTradeHistory(NUMBER_OF_TRADES_STORED);
		createTrades();
	}
	
	
	public void createTrades()
	{
		for(int i = 0; i < 11; i++){
			Trade trade = TradeTest.getTradeBuy();
			history.addTrade(trade);
			trade = TradeTest.getTradeSell();
			history.addTrade(trade);
		}
		
		
		
	}
	
	@Test
	public void testGetMovingAverage() {
		
		this.movingAverage = new Average(history, 1);
		averageMoving = movingAverage.getMovingAverage();
		assertEquals(30.0, averageMoving, 0.0);	
		
	}
	
	@Test
	public void testGetVolume() {
		
		this.movingAverage = new Average(history, 1);
		volume = movingAverage.getMarketVolume();
		assertEquals(22, volume);	
		
	}

}
