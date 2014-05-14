package nl.fontys.cryptoexchange.engine;

import nl.fontys.cryptoexchange.core.IdGeneratorTest; 
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.TestCoreAll;
import nl.fontys.cryptoexchange.core.TradeTest;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistoryTest;
import nl.fontys.cryptoexchange.engine.TradeEngineTest;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookTest;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.Suite.SuiteClasses;

/**
 * @author Tobias Zobrist this will run all the Engine Test Cases
 */

@RunWith(Suite.class)
@SuiteClasses({ OrderBookTest.class, TemporaryTradeHistoryTest.class, TradeEngineTest.class, AverageTest.class, })
public class TestEngineAll {

}
