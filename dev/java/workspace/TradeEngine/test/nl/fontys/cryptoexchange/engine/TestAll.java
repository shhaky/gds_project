package nl.fontys.cryptoexchange.engine;

import nl.fontys.cryptoexchange.core.IdGeneratorTest;
import nl.fontys.cryptoexchange.core.TradeTest;

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
OrderBookTest.class,TradeTest.class, IdGeneratorTest.class
})
public class TestAll {

}
