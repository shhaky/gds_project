package nl.fontys.crytoexchange;

import nl.fontys.cryptoexchange.core.IdGeneratorTest;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.TradeTest;
import nl.fontys.cryptoexchange.engine.MovingAverageCalculationTest;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistoryTest;
import nl.fontys.cryptoexchange.engine.TradeEngineTest;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookTest;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.Suite.SuiteClasses;

/**
 * 
 * @author Tobias Zobrist
 * 
 * this will run all the Test Cases
 *
 */

@RunWith(Suite.class)
@SuiteClasses({ 
OrderBookTest.class,
OrderTest.class,
TradeTest.class, 
IdGeneratorTest.class, 
TemporaryTradeHistoryTest.class,
TradeEngineTest.class,
MovingAverageCalculationTest.class,
})
public class TestAll {

}
